using System;
using System.IO;
using Common.Extentions;

namespace PCUITCommon.Configs
{
    /// <summary>
    /// PCUITの設定クラス.
    /// </summary>
    public class PCUITConf
    {
        /// <summary>
        /// 設定ファイルパス.
        /// </summary>
        private const string PCUITConfFile = @".\PCUIT.conf";

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public PCUITConf()
        {
            SetDefault();
        }

        /// <summary>
        /// デフォルトをセット.
        /// </summary>
        private void SetDefault()
        {
            // デフォルトはここで与える.
            this.IsDebug = false;

            this.EnableWeb = true;
            this.ProxyUse = false;
            this.ProxyId = string.Empty;
            this.ProxyPassword = string.Empty;
        }

        /// <summary>
        /// デバッグモードかどうか.
        /// </summary>
        public bool IsDebug { get; set; }

        /// <summary>
        /// Webの有効/無効.
        /// </summary>
        public bool EnableWeb { get; set; }

        /// <summary>
        /// Proxyを使用するかどうか.
        /// </summary>
        public bool ProxyUse { get; set; }

        /// <summary>
        /// ProxyのID
        /// </summary>
        public string ProxyId { get; set; }

        /// <summary>
        /// ProxyのPassword
        /// </summary>
        public string ProxyPassword { get; set; }


        /// <summary>
        /// ロード処理.
        /// </summary>
        /// <remarks>失敗時にはNULLを返す</remarks>
        /// <returns>正答テーブル</returns>
        public static PCUITConf Load()
        {
            var config = new PCUITConf();

            // ファイルの存在をチェックし、存在する場合のみ読み込む。
            if (File.Exists(PCUITConfFile))
            {
                try
                {
                    config = PCUITConfFile.JsonLoad<PCUITConf>();
                }
                catch (Exception ex)
                {
                    ex.ShowMessageBox(@"ファイル[{0}]の読み込みに失敗しました".Fmt(PCUITConfFile));
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
                this.JsonSave(PCUITConfFile);
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox(@"ファイル[{0}]の保存に失敗しました".Fmt(PCUITConfFile));
                return false;
            }

            return true;
        }
    }
}
