using Common.Progress;
using MouseExercise;
using PCUITCommon;
using PCUITraining.Forms;
using System.Threading;
using System.Windows.Forms;
using TextInputExercise;
using TypingExercise;

namespace PCUITraining
{
    /// <summary>
    /// メインクラス.
    /// </summary>
    public static class PCUITraining
    {
        /// <summary>
        /// APP名
        /// </summary>
        public static readonly string APP_VER = @"1.1.0";

        /// <summary>
        /// APP名
        /// </summary>
        public static readonly string APP_NAME = $"PCUITraining";


        /// <summary>
        /// 開始.
        /// </summary>
        public static void Start()
        {
            // 共通初期化
            if (!PCUIT.CommonInit())
            {
                MessageBox.Show("初期化に失敗しました");
                return;
            }

            // ※ ゲームセットアップは時間がかかるため、フォームロード後に変更

            // フォームロード.
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
        /// ゲームセットアップ.
        /// </summary>
        /// <returns>成否</returns>
        public static bool SetUp(ProgressCtl ctl)
        {
            // 最大をセット.
            ctl.Begin(3);

            // タイピングゲーム.
            if (!TypExc.Init())
            {
                MessageBox.Show("TypExcの初期化に失敗しました");
                return false;
            }

            ctl.Increment();

            // マウスクリックゲーム.
            if (!MusExc.Init())
            {
                MessageBox.Show("MusExcの初期化に失敗しました");
                return false;
            }

            ctl.Increment();

            // テキストライティングゲーム.
            if (!TIExc.Init())
            {
                MessageBox.Show("TIExcの初期化に失敗しました");
                return false;
            }

            ctl.Increment();
            ctl.Finish();

            // ちょっと焦らす.
            Thread.Sleep(1000);

            return true;
        }
    }
}
