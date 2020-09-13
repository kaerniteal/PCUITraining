using Common.Conf;

namespace TextInputExercise.Configs
{
    /// <summary>
    /// TIExcの設定.
    /// </summary>
    public class TIExcConf : JsonConfBase<TIExcConf>
    {
        /// <summary>
        /// 設定ファイルパスを返す.
        /// </summary>
        /// <returns>設定ファイルのパス</returns>
        public override string GetConfFilePath()
        {
            return @".\Conf\TIExcConf.conf";
        }

        /// <summary>
        /// デフォルトをセット.
        /// </summary>
        public override void SetDefault()
        {
            // デフォルトはここで与える.
            this.NnumberOfQuestions = 5;
            this.MarqueeUpdateInterval = 50;
            this.MarqueeAmountOfMovement = 2;

            this.EnableAnimePokemon = true;
            this.EnableAnimeNaruto = true;
            this.EnableAnimeBoruto = true;
            this.EnableAnimeKimetsu = true;
            this.EnableAnimeCellsAtWork = true;
        }

        /// <summary>
        /// 1プレイの問題数.
        /// </summary>
        public int NnumberOfQuestions { get; set; }

        /// <summary>
        /// Marqueeの更新頻度(ms).
        /// </summary>
        public int MarqueeUpdateInterval { get; set; }

        /// <summary>
        /// Marqueeの移動量.
        /// </summary>
        public int MarqueeAmountOfMovement { get; set; }

        /// <summary>
        /// ポケモンが有効かどうか.
        /// </summary>
        public bool EnableAnimePokemon { get; set; }

        /// <summary>
        /// Narutoが有効かどうか.
        /// </summary>
        public bool EnableAnimeNaruto { get; set; }

        /// <summary>
        /// Borutoが有効かどうか.
        /// </summary>
        public bool EnableAnimeBoruto { get; set; }

        /// <summary>
        /// 鬼滅の刃が有効かどうか.
        /// </summary>
        public bool EnableAnimeKimetsu { get; set; }

        /// <summary>
        /// 働く細胞が有効かどうか.
        /// </summary>
        public bool EnableAnimeCellsAtWork { get; set; }
    }
}
