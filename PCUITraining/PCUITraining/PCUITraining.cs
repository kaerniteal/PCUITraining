using Common.Progress;
using Common.Updater;
using Common.Updater.Ver1_0_0;
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
            // 更新管理を生成.
            var info = new VerCheckInfoVer1_0_0
            {
                SrcVer = Def.Ver,
                Url = Def.UPDATE_URL,
                ModuleName = Def.APP_NAME,
                Proxy = new ProxyInfo(),
            };

            // アップデータを生成.
            var updater = new UpdaterControler(info, Def.UPDATER_NAME);

            // バージョンチェック.
            if (updater.CheckVersion())
            {
                if (DialogResult.Yes == MessageBox.Show("新しいバージョンが存在します。\n更新しますか？", "更新確認", MessageBoxButtons.YesNo))
                {
                    // 更新ツールの更新.
                    if (updater.UpdaterUpdate(Def.UPDATER_URL).IsNG)
                    {
                        MessageBox.Show("更新ツールの更新に失敗しました。");
                    }

                    // アプリケーションの更新.
                    if (updater.AppUpdate())
                    {
                        // 更新の為に終了.
                        Stop();
                    }
                }
            }

            // 進捗の最大をセット.
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
