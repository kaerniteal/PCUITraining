using System;
using System.Collections.Generic;
using TextInputExercise.Interfaces;
using TextInputExercise.TextSet;

namespace TextInputExercise.Executors
{
    /// <summary>
    /// セット実行クラス.
    /// </summary>
    public class SetExecutor : ITIExcExecutor
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
        /// 文字列リスト.
        /// </summary>
        private List<TextBase> TextList { get; set; }

        /// <summary>
        /// 現在実行中のIndex
        /// </summary>
        private int CurrentIndex { get; set; }

        /// <summary>
        /// 表示インタフェース.
        /// </summary>
        private ITIExcViewer Viewer { get; set; }

        /// <summary>
        /// 文字列実行クラス.
        /// </summary>
        private TextExecutor TextExecutor { get; set; }

        /// <summary>
        /// 実行結果.
        /// </summary>
        private SetResult SetResult { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="textList">実施する文字列リスト</param>
        /// <param name="viewer">表示インタフェース</param>
        public SetExecutor(List<TextBase> textList, ITIExcViewer viewer)
        {
            this.TextList = textList;
            this.CurrentIndex = 0;
            this.Viewer = viewer;
            this.TextExecutor = null;
            this.SetResult = new SetResult();
        }

        /// <summary>
        /// 開始.
        /// </summary>
        public void Start()
        {
            this.CurrentIndex = 0;
            this.SetResult = new SetResult();
            this.Exec(this.CurrentIndex);
        }

        /// <summary>
        /// 入力されたTEXT
        /// </summary>
        /// <param name="text">入力文字列</param>
        public void InputText(string text)
        {
            if (null == this.TextExecutor)
            {
                return;
            }

            // テキスト実行クラスへ通知し、結果を得る.
            var status = this.TextExecutor.InputText(text);

            // 全て入力が済んだ場合.
            if (EXEC_RESULT.NEXT == status)
            {
                // 結果を取得してセット結果に追加.
                var result = this.TextExecutor.GetResult();
                this.SetResult.TextResultList.Add(result);

                // 表示へ反映.
                this.Viewer.ShowTextResult(result);

                // 次へ進める.
                this.CurrentIndex++;
                this.Exec(this.CurrentIndex);
            }
        }

        /// <summary>
        /// 終了.
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
            if (index < this.TextList.Count)
            {
                this.TextExecutor = new TextExecutor(this.Viewer, this.TextList[index]);
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
