using Common.Logger;
using Common.Progress;
using Common.Updater;
using Common.Updater.Ver1_0_0;
using MouseExercise;
using PCUITCommon;
using PCUITraining.Forms;
using System.Reflection;
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
        /// ログ.
        /// </summary>
        private static Log4netLogger Log = new Log4netLogger(MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// 開始.
        /// </summary>
        public static void Start()
        {
            Log.Info("PCUITraining Start");

            // 共通初期化
            var resultInit = PCUIT.CommonInit();
            if (resultInit.IsNG)
            {
                MessageBox.Show($"初期化に失敗しました\n{resultInit.Message}");
                return;
            }

            // ※ ゲームセットアップは時間がかかるため、フォームロード後に変更
            Log.Info("初期化成功");

            // フォームロード.
            Application.Run(new FormMain());
        }

        /// <summary>
        /// アプリケーション終了.
        /// </summary>
        public static void Stop()
        {
            Log.Info("PCUITraining Stop");
            Application.Exit();
        }

        /// <summary>
        /// ゲームセットアップ.
        /// </summary>
        public static void SetUp(ProgressCtl ctl)
        {
            Log.Info("PCUITraining SetUp Begin");
            
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
                    Log.Info("PCUITraining 更新開始");

                    // 更新ツールの更新.
                    if (updater.UpdaterUpdate(Def.UPDATER_URL).IsNG)
                    {
                        MessageBox.Show("更新ツールの更新に失敗しました。");
                    }

                    Log.Info("PCUITraining AppUpdate");

                    // アプリケーションの更新.
                    if (updater.AppUpdate())
                    {
                        // 更新の為に終了.
                        Log.Info("更新の為に終了");
                        Stop();
                    }
                }
            }

            // 進捗の最大をセット.
            ctl.Begin(3);

            // タイピングゲーム.
            var typResult = TypExc.Init();
            if (typResult.IsNG)
            {
                MessageBox.Show($"TypExcの初期化に失敗しました\n{typResult.Message}");
                return;
            }

            ctl.Increment();

            // マウスクリックゲーム.
            var musResult = MusExc.Init();
            if (musResult.IsNG)
            {
                MessageBox.Show($"MusExcの初期化に失敗しました\n{musResult.Message}");
                return;
            }

            ctl.Increment();

            // テキストライティングゲーム.
            var tiResult = TIExc.Init();
            if (tiResult.IsNG)
            {
                MessageBox.Show($"TIExcの初期化に失敗しました\n{tiResult.Message}");
                return;
            }

            ctl.Increment();
            ctl.Finish();

            // ちょっと焦らす.
            Thread.Sleep(1000);
        }
    }
}
