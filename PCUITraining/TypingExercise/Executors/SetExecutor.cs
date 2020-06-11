using System.Collections.Generic;
using TypingExercise.Interfaces;
using TypingExercise.WordSet;

namespace TypingExercise.Executors
{
    /// <summary>
    /// 入力結果.
    /// </summary>
    public enum EXEC_RESULT
    {
        CONTINUE,
        NEXT,
    }

    /// <summary>
    /// セット実行クラス.
    /// </summary>
    public class SetExecutor : IExecutor
    {
        /// <summary>
        /// 文字列リスト.
        /// </summary>
        private List<WordBase> WordList { get; set; }

        /// <summary>
        /// 現在実行中のIndex
        /// </summary>
        private int CurrentIndex { get; set; }

        /// <summary>
        /// 表示インタフェース.
        /// </summary>
        private IViewer Viewer { get; set; }

        /// <summary>
        /// 文字列実行クラス.
        /// </summary>
        private WordExecutor WordExecutor { get; set; }

        /// <summary>
        /// 実行結果.
        /// </summary>
        private SetResult SetResult { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="WordList">実施する文字列リスト</param>
        /// <param name="viewer">表示インタフェース</param>
        public SetExecutor(List<WordBase> WordList, IViewer viewer)
        {
            this.WordList = WordList;
            this.CurrentIndex = 0;
            this.Viewer = viewer;
            this.WordExecutor = null;
            this.SetResult = new SetResult();
        }

        /// <summary>
        /// 開始.
        /// </summary>
        public void Start()
        {
            this.Reset();
        }

        /// <summary>
        /// 最初から始める.
        /// </summary>
        public void Reset()
        {
            this.CurrentIndex = 0;
            this.SetResult = new SetResult();
            this.Exec(this.CurrentIndex);
        }

        /// <summary>
        /// 入力されたKEYの通知.
        /// </summary>
        /// <param name="key">入力KEY</param>
        public void InputKey(char key)
        {
            if (null == this.WordExecutor)
            {
                return;
            }

            // 小文字に変換.
            var lower = char.ToLower(key);

            // 単語実行クラスへ通知し、結果を得る.
            var status = this.WordExecutor.InputKey(lower);

            // 全て入力が済んだ場合.
            if (EXEC_RESULT.NEXT == status)
            {
                // 結果を取得してセット結果に追加.
                var result = this.WordExecutor.GetResult();
                this.SetResult.WordResultList.Add(result);

                // 連続成功数を格納.
                result.ConsecutiveNoMissCount = this.SetResult.GetCountConsecutiveNoMiss();

                // 表示へ反映.
                this.Viewer.ShowWordResult(result);

                // 次へ進める.
                this.CurrentIndex++;
                this.Exec(this.CurrentIndex);
            }
        }

        /// <summary>
        /// 終了
        /// </summary>
        public void Stop()
        {
            // 現状処理はない.
        }

        /// <summary>
        /// 実施.
        /// </summary>
        /// <param name="index">実施対象Index</param>
        private void Exec(int index)
        {
            if (null == this.Viewer)
            {
                return;
            }

            // 処理継続.
            if (index < WordList.Count)
            {
                this.WordExecutor = new WordExecutor(this.Viewer, WordList[index]);
            }
            else
            {
                // 終了処理.
                this.Stop();
                if (null != this.Viewer)
                {
                    this.Viewer.ShowSetResult(this.SetResult);
                }
            }
        }
    }
}
