using Common.Web;
using PCUITCommon.Configs;
using PCUITCommon.Users;
using System.Collections.Generic;
using System.Drawing;
using System.Net;

namespace PCUITCommon
{
    /// <summary>
    /// メインクラス.
    /// </summary>
    public class PCUIT
    {
        /// <summary>
        /// シングルトンインスタンス.
        /// </summary>
        static private PCUIT instance = new PCUIT();

        /// <summary>
        /// 設定.
        /// </summary>
        public static PCUITConf Conf { get; set; }

        /// <summary>
        /// ユーザーデータ管理.
        /// </summary>
        public static UserDataManager UserDataManager { get; set; }

        /// <summary>
        /// フォントマップ.
        /// </summary>
        private Dictionary<int, Font> FontMap { get; set; }


        /// <summary>
        /// 共通初期化処理.
        /// </summary>
        /// <returns>成否</returns>
        public static bool CommonInit()
        {
            Conf = PCUITConf.Load();

            // ユーザーデータ管理を生成.
            UserDataManager = new UserDataManager();

            // ユーザーデータをロード.
            if (!UserDataManager.LoadUserDataAll())
            {
                return false;
            }

            // Fontのコレクレクション.
            instance.FontMap = new Dictionary<int, Font>();

            return true;
        }

        /// <summary>
        /// フォントを取得する.
        /// </summary>
        /// <param name="size">フォントサイズ</param>
        /// <returns>フォント</returns>
        public static Font GetFont(int size)
        {
            if (instance.FontMap.ContainsKey(size))
            {
                return instance.FontMap[size];
            }

            var font = new Font("HGP創英角ﾎﾟｯﾌﾟ体", size);
            instance.FontMap.Add(size, font);

            return font;
        }

        /// <summary>
        /// WebClientを取得します.
        /// </summary>
        /// <returns></returns>
        public static WebClient CreateWebClient()
        {
            return WebClientCreator.Create(Conf.ProxyUse, Conf.ProxyId, Conf.ProxyPassword);
        }
    }
}
