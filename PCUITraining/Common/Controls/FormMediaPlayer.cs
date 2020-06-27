using System.Windows.Forms;

namespace Common.Controls
{
    /// <summary>
    /// Media Player
    /// </summary>
    public partial class FormMediaPlayer : Form
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FormMediaPlayer()
        {
            InitializeComponent();

            this.ComMediaPlayer.Visible = false;
        }

        /// <summary>
        /// 再生.
        /// </summary>
        /// <param name="url">再生メディア</param>
        /// <param name="playCount">再生回数</param>
        public void Play(string url, int playCount = 1)
        {
            ComMediaPlayer.uiMode = "none";
            ComMediaPlayer.settings.playCount = playCount;

            ComMediaPlayer.Visible = true;

            // 再生開始.
            ComMediaPlayer.URL = url;

            this.ShowDialog();
        }

        /// <summary>
        /// 再生状態変化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            // ステータスに合わせて.
            switch (e.newState)
            {
                case 1:
                    // 再生が終了したら閉じる.
                    this.Close();
                    break;
            }
        }
    }
}
