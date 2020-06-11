using PCUITCommon;
using PCUITraining.Forms;
using System.Windows.Forms;
using TypingExercise;

namespace PCUITraining
{
    /// <summary>
    /// メインクラス.
    /// </summary>
    public static class PCUITraining
    {
        /// <summary>
        /// タイピングゲーム.
        /// </summary>
        public static TypExc TypExc { get; set; }


        /// <summary>
        /// 開始.
        /// </summary>
        public static void Start()
        {
            if (!PCUIT.Init())
            {
                MessageBox.Show("初期化に失敗しました");
                return;
            }

            if (!Init())
            {
                MessageBox.Show("初期化に失敗しました");
                return;
            }

            if (PCUIT.Conf.IsDebug)
            {
                Application.Run(new FormMainDebug());
            }
            else
            {
                Application.Run(new FormMain());
            }
        }

        /// <summary>
        /// アプリケーション終了.
        /// </summary>
        public static void Stop()
        {
            Application.Exit();
        }

        /// <summary>
        /// 初期化処理.
        /// </summary>
        /// <returns>成否</returns>
        private static bool Init()
        {
            // タイピングゲーム.
            TypExc = new TypExc();
            if (!TypExc.Init())
            {
                MessageBox.Show("TypExcの初期化に失敗しました");
                return false;
            }

            return true;
        }
    }
}
