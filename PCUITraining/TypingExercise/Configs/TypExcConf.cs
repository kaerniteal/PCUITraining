using Common.Conf;

namespace TypingExercise.Configs
{
    /// <summary>
    /// TypExcの設定.
    /// </summary>
    public class TypExcConf : ConfBase<TypExcConf>
    {
        /// <summary>
        /// 設定ファイルパスを返す.
        /// </summary>
        /// <returns>設定ファイルのパス</returns>
        public override string GetConfFilePath()
        {
            return @".\Conf\TypExc.conf";
        }

        /// <summary>
        /// デフォルトをセット.
        /// </summary>
        public override void SetDefault()
        {
            // デフォルトはここで与える.
            this.BaseCaptureProbability = 20;
            this.KeyBoardFontSize = 20;
            this.NnumberOfQuestions = 10;
            this.ShowLogCaptureJudg = false;
        }

        /// <summary>
        /// 捕獲確率.
        /// </summary>
        public int BaseCaptureProbability { get; set; }

        /// <summary>
        /// キーボードナビゲーションのフォントサイズ.
        /// </summary>
        public int KeyBoardFontSize { get; set; }

        /// <summary>
        /// 1プレイの問題数.
        /// </summary>
        public int NnumberOfQuestions { get; set; }

        /// <summary>
        /// 捕獲判定ログを表示するかどうか.
        /// </summary>
        public bool ShowLogCaptureJudg { get; set; }
    }
}
