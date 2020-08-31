namespace Common.Conf.Sample
{
    /// <summary>
    /// 設定ファイルサンプル.
    /// </summary>
    public class SampleConf : ConfBase<SampleConf>
    {
        /// <summary>
        /// 設定ファイルパスを返す.
        /// </summary>
        /// <returns>設定ファイルのパス</returns>
        public override string GetConfFilePath()
        {
            return @".\Sample.conf";
        }

        /// <summary>
        /// デフォルトをセット.
        /// </summary>
        public override void SetDefault()
        {
            this.IsDebug = false;
        }

        /// <summary>
        /// デバッグかどうか.
        /// </summary>
        public bool IsDebug { get; set; }
    }
}
