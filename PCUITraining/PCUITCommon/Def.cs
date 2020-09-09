using Common.Versions;

namespace PCUITCommon
{
    /// <summary>
    /// PCUITの静的定義クラス.
    /// </summary>
    public static class Def
    {
        /// <summary>
        /// バージョン.
        /// </summary>
        public static readonly Ver Ver = new Ver(1, 2, 1);

        /// <summary>
        /// APP名.
        /// </summary>
        public static readonly string APP_NAME = @"PCUITraining";

        /// <summary>
        /// Web Site URL
        /// </summary>
        public static readonly string URL = @"http://kaerniteal.oops.jp/";

        /// <summary>
        /// APP URL
        /// </summary>
        public static readonly string APP_URL = $@"{URL}{APP_NAME}/";

        /// <summary>
        /// アップデート確認URL
        /// </summary>
        public static readonly string UPDATE_URL = $@"{APP_URL}Latest/";

        /// <summary>
        /// 更新ツール名
        /// </summary>
        public static readonly string UPDATER_NAME = @"UpdaterManager";

        /// <summary>
        /// 更新ツール名
        /// </summary>
        public static readonly string UPDATER_URL = $@"{URL}{UPDATER_NAME}/Latest/";

        /// <summary>
        /// メインフォント.
        /// </summary>
        public static readonly string FONT = @"HGP創英角ﾎﾟｯﾌﾟ体";
    }
}
