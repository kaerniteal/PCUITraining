using Common.Extentions;
using System;
using System.IO;

namespace TextInputExercise.Configs
{
    /// <summary>
    /// TIExcの設定.
    /// </summary>
    public class TIExcConf
    {
        /// <summary>
        /// 設定ファイルパス.
        /// </summary>
        private const string TIExcConfFile = @".\TIExcConf.conf";

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public TIExcConf()
        {
            SetDefault();
        }

        /// <summary>
        /// デフォルトをセット.
        /// </summary>
        public void SetDefault()
        {
            // デフォルトはここで与える.
            this.NnumberOfQuestions = 5;
            this.MarqueeUpdateInterval = 50;
            this.MarqueeAmountOfMovement = 2;

            this.EnableAnimePokemon = true;
            this.EnableAnimeNaruto = true;
            this.EnableAnimeBoruto = true;
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
        /// ロード処理.
        /// </summary>
        /// <remarks>失敗時にはNULLを返す</remarks>
        /// <returns>正答テーブル</returns>
        public static TIExcConf Load()
        {
            var config = new TIExcConf();

            // ファイルの存在をチェックし、存在する場合のみ読み込む。
            if (File.Exists(TIExcConfFile))
            {
                try
                {
                    config = TIExcConfFile.JsonLoad<TIExcConf>();
                }
                catch (Exception ex)
                {
                    ex.ShowMessageBox(@"ファイル[{0}]の読み込みに失敗しました".Fmt(TIExcConfFile));
                }
            }

            // 下記の２ケースを想定して毎回出力する
            // ・読み込んだ設定ファイルに項目が不足している場合.
            // ・設定ファイルが存在しない場合.
            config.Save();

            return config;
        }

        /// <summary>
        /// セーブ処理.
        /// </summary>
        public bool Save()
        {
            try
            {
                this.JsonSave(TIExcConfFile);
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox(@"ファイル[{0}]の保存に失敗しました".Fmt(TIExcConfFile));
                return false;
            }

            return true;
        }
    }
}
