using Common.Logger;
using Common.Values;
using Common.Web;
using PCUITCommon.Configs;
using PCUITCommon.Users;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Reflection;

namespace PCUITCommon
{
    /// <summary>
    /// メインクラス.
    /// </summary>
    public class PCUIT
    {
        /// <summary>
        /// ログ.
        /// </summary>
        private static Log4netLogger Log = new Log4netLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
        public static Result CommonInit()
        {
            // 設定ロード.
            Conf = PCUITConf.Load();

            // ユーザーデータ管理を生成.
            UserDataManager = new UserDataManager();

            // ユーザーデータをロード.
            var result = UserDataManager.LoadUserDataAll();
            if (result.IsNG)
            {
                var message = "ユーザーデータのロードに失敗しました。";
                Log.Error(message);
                return Result.NG(message, result);
            }

            // Fontのコレクレクション.
            instance.FontMap = new Dictionary<int, Font>();

            return Result.OK();
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

            var font = new Font(Def.FONT, size);
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
