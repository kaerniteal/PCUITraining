using Common.Logger;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Common.Progress.ProgressAction;

namespace Common.Progress
{
    /// <summary>
    /// 進捗管理クラス.
    /// </summary>
    /// <remarks>ProgressActionから呼び出される非同期処理の引数</remarks>
    public class ProgressCtl : IProgressParent
    {
        /// <summary>
        /// ログクラス.
        /// </summary>
        private static Log4netLogger Log = new Log4netLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// デフォルトスケール.
        /// </summary>
        public const int DEFAULT_SCALE = 100;

        /// <summary>
        /// 進捗管理親クラス
        /// </summary>
        protected IProgressParent Parent { get; set; }

        /// <summary>
        /// 子進捗管理クラス.
        /// </summary>
        protected List<ProgressCtl> Children { get; set; }

        /// <summary>
        /// 自身の要素Index
        /// </summary>
        public int Index { get; protected set; }

        /// <summary>
        /// 自身のネストLv
        /// </summary>
        public int NestLv { get; protected set; }

        /// <summary>
        /// 自身の進捗の最大.
        /// </summary>
        public int Max { get; protected set; }

        /// <summary>
        /// 自身の進捗.
        /// </summary>
        public int Cur { get; protected set; }

        /// <summary>
        /// 自身の進捗の重み.
        /// </summary>
        public int Ratio { get; protected set; }

        /// <summary>
        /// レポートをLog(Info)に出力するかどうか.
        /// </summary>
        public bool PutReport { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="parent">親</param>
        public ProgressCtl(IProgressParent parent)
        {
            this.Parent = parent;
            this.Children = new List<ProgressCtl>();
            this.Index = 0;
            this.NestLv = 0;
            this.Max = DEFAULT_SCALE;
            this.Cur = 0;
            this.Ratio = DEFAULT_SCALE;
            this.PutReport = false;
        }

        /// <summary>
        /// 均等な重みで子管理を生成する.
        /// </summary>
        /// <remarks>子要素を生成した時点で自身の進捗は子要素のサマリとなる.</remarks>
        /// <param name="num">生成する要素数</param>
        /// <returns>生成した子要素</returns>
        public List<ProgressCtl> CreateChildren(int num)
        {
            // 重みが均等なint配列にして子要素生成.
            return this.CreateChildren((new int[num])
                .Select(ch => DEFAULT_SCALE / num)
                .ToArray());
        }

        /// <summary>
        /// 重みを指定して子管理を生成する.
        /// </summary>
        /// <remarks>子要素を生成した時点で自身の進捗は子要素のサマリとなる.</remarks>
        /// <param name="ratios">重みリスト</param>
        /// <returns>生成した子要素</returns>
        public List<ProgressCtl> CreateChildren(int[] ratios)
        {
            var ratioList = ratios.ToList();

            // トータルがDEFAULT_SCALE(100)でない場合、重みをDEFAULT_SCALE(100)分率に再計算.
            var totalRatio = ratioList.Sum();
            if (DEFAULT_SCALE != totalRatio)
            {
                ratioList = ratios
                    .Select(ratio => ratio * DEFAULT_SCALE / totalRatio)
                    .ToList();
            }

            // 重みをつけて子管理を生成.
            for (var ii = 0; ii < ratioList.Count; ii++)
            {
                this.Children.Add(new ProgressCtl(this)
                {
                    Index = ii,
                    NestLv = this.NestLv + 1,
                    Ratio = ratioList[ii],
                    PutReport = this.PutReport,
                });
            }

            this.Report($"CreateChildren({ratioList.Count})");

            // リストは複製して返す.
            return this.Children.ToList();
        }

        /// <summary>
        /// 現在の進捗をセット.
        /// </summary>
        /// <param name="cur">現在の進捗</param>
        protected void SetCur(int cur)
        {
            if (this.Cur != cur)
            {
                this.Cur = cur;
                this.Parent.Notify();
            }
        }

        /// <summary>
        /// 開始する.
        /// </summary>
        /// <remarks>ここでセットしたMax回数分Incrementを呼ぶことで、進捗が100%になる</remarks>
        /// <param name="max">進捗の最大値</param>
        public void Begin(int max = 100)
        {
            this.Max = max;
            this.SetCur(0);
            this.Report("Begin");
        }

        /// <summary>
        /// 進捗を１進める.
        /// </summary>
        public void Increment()
        {
            this.SetCur(this.Cur + 1);
        }

        /// <summary>
        /// 完了にする.
        /// </summary>
        public void Finish()
        {
            this.InnterFinish();
            this.Report("Finish");
        }

        /// <summary>
        /// Finishの実体(Reportを再帰呼び出ししないようにする苦肉の策)
        /// </summary>
        protected void InnterFinish()
        {
            if (0 < this.Children.Count)
            {
                this.Children.ForEach(child => child.InnterFinish());
            }
            else
            {
                this.SetCur(this.Max);
            }
        }

        /// <summary>
        /// 進捗を取得(0～DEFAULT_SCALE).
        /// </summary>
        /// <returns>進捗(%)</returns>
        public int GetProgress()
        {
            return (DEFAULT_SCALE * this.Cur) / this.Max;
        }

        /// <summary>
        /// 自身の進捗をLog(Info)に出力するかどうか.
        /// </summary>
        /// <param name="prefix">接頭文字列</param>
        public void Report(string prefix)
        {
            if (this.PutReport)
            {
                Log.Info($"Progress({this.GetId()}):{prefix}:[{this.Cur}/{this.Max}]");
            }
        }

        /// <summary>
        /// IProgressParentの実装(自身の子要素から呼ばれる).
        /// </summary>
        public void Notify()
        {
            // 子要素の進捗リストを生成.
            var childProgressList = this.Children
                .Select(child => new { ratio = child.Ratio, progress = child.GetProgress() })
                .ToList();

            // 完了している場合.
            // ※ 例外：子要素ゼロで呼ばれた場合も完了とみなす.
            if (childProgressList.All(child => DEFAULT_SCALE == child.progress))
            {
                this.Cur = this.Max;
                this.Parent?.Notify();
                return;
            }

            // 未完了の場合.

            // 自身の子要素の進捗をサマリする.
            var myProgress = childProgressList
                .Sum(child =>
                {
                    return (child.progress * child.ratio) / DEFAULT_SCALE;
                });

            // 自身の進捗に反映.
            this.Cur = (this.Max * myProgress) / DEFAULT_SCALE;

            // 親へイベントを伝播する.
            this.Parent?.Notify();
        }

        /// <summary>
        /// 処理継続可否判定.
        /// </summary>
        /// <returns>true：継続 false：中断</returns>
        public bool Continue()
        {
            return this.Parent.Continue();
        }

        /// <summary>
        /// 自身のIDを返す.
        /// </summary>
        /// <returns>ID</returns>
        public string GetId()
        {
            return 0 == this.NestLv
                ? $"{this.Index}"
                : $"{this.Parent.GetId()}-{this.Index}";
        }
    }
}
