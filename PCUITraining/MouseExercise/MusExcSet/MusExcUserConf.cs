namespace MouseExercise.MusExcSet
{
    /// <summary>
    /// ユーザー設定.
    /// </summary>
    public class MusExcUserConf
    {
        /// <summary>
        /// カスタムマウスアイコンを使用する.
        /// </summary>
        public bool UseCustomMouseIcon { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MusExcUserConf()
        {
            this.UseCustomMouseIcon = true;
        }
    }
}
