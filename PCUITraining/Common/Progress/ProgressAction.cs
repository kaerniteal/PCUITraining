using System;
using System.Threading;
using System.Threading.Tasks;
using static Common.Progress.ProgressAction;

namespace Common.Progress
{
    /// <summary>
    /// 進捗管理付き非同期処理クラス.
    /// </summary>
    /// <remarks>
    /// 進捗管理コントロール[ProgressCtl]を引数とした非同期処理を実施する
    /// </remarks>
    public class ProgressAction : IProgressParent
    {
        /// <summary>
        /// 進捗管理者.
        /// </summary>
        private IProgressObserver Observer { get; set; }

        /// <summary>
        /// 進捗管理クラス.
        /// </summary>
        private ProgressCtl ProgressCtl { get; set; }

        /// <summary>
        /// 処理継続フラグ.
        /// </summary>
        private bool ContinueFlg { get; set; }

        /// <summary>
        /// コンソールに進捗レポートを出力するかどうか.
        /// </summary>
        public bool ConsoleReport
        {
            get
            {
                return this.ProgressCtl.PutReport;
            }

            set
            {
                this.ProgressCtl.PutReport = value;
            }
        }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ProgressAction(IProgressObserver observer)
        {
            this.Observer = observer;
            this.ProgressCtl = new ProgressCtl(this);
            this.ContinueFlg = true;
        }

        /// <summary>
        /// 非同期処理開始.
        /// </summary>
        public async Task Start(Action<ProgressCtl> action)
        {
            await Task.Run(() =>
            {
                try
                {
                    this.ContinueFlg = true;
                    action(this.ProgressCtl);
                }
                finally
                {
                    this.ProgressCtl.Finish();
                    Thread.Sleep(500);
                }
            });
        }

        /// <summary>
        /// 非同期処理停止.
        /// </summary>
        public void Stop()
        {
            this.ContinueFlg = false;
        }

        /// <summary>
        /// IProgressParentの実装(外から呼ぶ意味はない).
        /// </summary>
        /// <remarks>コンストラクタに渡されたIProgressObserverに現状を通知する</remarks>
        public void Notify()
        {
            var progress = this.ProgressCtl.GetProgress();
            this.Observer.ProgressNotify(progress);
        }

        /// <summary>
        /// IProgressParentの実装(外から呼ぶ意味はない).
        /// </summary>
        /// <remarks>非同期処理継続フラグの状態を返す</remarks>
        /// <returns>true：継続 false：中断</returns>
        public bool Continue()
        {
            return this.ContinueFlg;
        }

        /// <summary>
        /// IProgressParentの実装(外から呼ぶ意味はない).
        /// </summary>
        /// <remarks>ProgressCtl用のI/Fなため、ここでは無用な処理</remarks>
        /// <returns>進捗管理コントロールのID(常に空文字列)</returns>
        public string GetId()
        {
            return string.Empty;
        }

        /// <summary>
        /// 進捗管理 I/F.
        /// </summary>
        public interface IProgressParent
        {
            /// <summary>
            /// 進捗更新イベント.
            /// </summary>
            void Notify();

            /// <summary>
            /// 処理継続可否判定.
            /// </summary>
            /// <returns>true：継続 false：中断</returns>
            bool Continue();

            /// <summary>
            /// 自身のIDを返す.
            /// </summary>
            /// <returns>ID</returns>
            string GetId();
        }
    }
}
