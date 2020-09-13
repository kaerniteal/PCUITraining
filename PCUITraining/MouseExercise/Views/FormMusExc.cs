using Common.Extentions;
using Common.WinForms;
using Common.WinForms.Ccontrols;
using MouseExercise.Executors;
using MouseExercise.Interfaces;
using MouseExercise.MusExcSet;
using PCUITCommon;
using PCUITCommon.Datas;
using System;
using System.Drawing;
using System.Windows.Forms;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Views
{
    /// <summary>
    /// 実行ダイアログ.
    /// </summary>
    public partial class FormMusExc : Form, IMusExcViewer
    {
        /// <summary>
        /// ゲームインスタンス.
        /// </summary>
        private IMusExcGameInstance GameInstance { get; set; }

        /// <summary>
        /// 実行クラスとの共有データ.
        /// </summary>
        private MusExcSharedData SharedData { get; set; }

        /// <summary>
        /// 実行クラスインタフェース
        /// </summary>
        private IMusExcExecutor Executor { get; set; }

        /// <summary>
        /// ユニットリスト.
        /// </summary>
        private UnitPBox[] UnitArray { get; set; }

        /// <summary>
        /// 更新中フラグ.
        /// </summary>
        public bool Updating { get; set; }

        /// <summary>
        /// 描画領域サイズ.
        /// </summary>
        public Size ViewSize { get; set; }

        /// <summary>
        /// カーソルOFF
        /// </summary>
        private Cursor CursorOff { get; set; }

        /// <summary>
        /// カーソルON
        /// </summary>
        private Cursor CursorOn { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="gameInstance">ゲームインスタンス</param>
        public FormMusExc(IMusExcGameInstance gameInstance)
        {
            InitializeComponent();

            if (!MusExc.Conf.IsOffice)
            {
                this.lblTime.Font = PCUIT.GetFont(28);
            }

            this.GameInstance = gameInstance;
            this.SharedData = new MusExcSharedData();
            this.Executor = null;
            this.UnitArray = new UnitPBox[MusExc.Conf.UnitMax];
            this.Updating = false;

            this.lblGot.Visible = MusExc.Conf.ShowDebugShot;

            if (MusExc.Conf.IsOffice)
            {
                this.WindowState = FormWindowState.Normal;
            }

            // Cusor をロード.
            this.CursorOff = new Cursor(@".\MusExcResorce\InsectCollectingOff.cur");
            this.CursorOn = new Cursor(@".\MusExcResorce\InsectCollectingOn.cur");
        }

        /// <summary>
        /// フォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMusExc_Load(object sender, EventArgs e)
        {
            // 別スレッドでも参照するため、サイズを別インスタンス化しておく.
            this.ViewSize = new Size(this.Size.Width, this.Size.Height);

            // Cusor をセット.
            if (this.GameInstance.GetMusExcSetConf().UseCustomMouseIcon)
            {
                this.Cursor = this.CursorOff;
            }

            this.StartNewGame();
        }

        /// <summary>
        /// ゲーム開始.
        /// </summary>
        private void StartNewGame()
        {
            this.SharedData = new MusExcSharedData();
            this.Executor = new MusExcExecutor(this);
            this.Executor.Start(this.SharedData);
        }

        /// <summary>
        /// Key入力を取得.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMusExc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Esc
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Executor.Stop();
                this.Close();
            }
        }

        /// <summary>
        /// マウス押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMusExc_MouseDown(object sender, MouseEventArgs e)
        {
            // Cusor をセット.
            if (this.GameInstance.GetMusExcSetConf().UseCustomMouseIcon)
            {
                this.Cursor = this.CursorOn;
            }
        }

        /// <summary>
        /// マウスボタンリリース.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMusExc_MouseUp(object sender, MouseEventArgs e)
        {
            // Cusor をセット.
            if (this.GameInstance.GetMusExcSetConf().UseCustomMouseIcon)
            {
                this.Cursor = this.CursorOff;
            }
        }

        /// <summary>
        /// 新たな設問をセットし、実行クラスに返す.
        /// </summary>
        /// <param name="difficulty">難易度</param>
        /// <returns>設問情報</returns>
        public MusExcQuestionDef GetNextQuestionDef(DIFFICULTY difficulty)
        {
            // 新しい設問を取得.
            var qDef = this.GameInstance.GetQuestionDef(difficulty);

            // 背景をセット.
            this.BackColor = Color.FromArgb(qDef.BgColorR, qDef.BgColorG, qDef.BgColorB);
            if (BG_TYPE.IMAGE == qDef.BgType)
            {
                // 背景が未ロードであれば、Webからロードする.
                var fl = new FileLoader();
                fl.Load(qDef.BgImageFilePath);

                // 背景をローカルからロード.
                this.BackgroundImage = new Bitmap(qDef.BgImageFilePath);
            }
            else
            {
                this.BackgroundImage = null;
            }

            if (MusExc.Conf.IsOffice)
            {
                this.BackColor = Color.FromArgb(243, 242, 241);
                this.BackgroundImage = null;
            }

            return qDef;
        }

        /// <summary>
        /// Clickに対する結果を通知.
        /// </summary>
        /// <param name="unitIndex">ユニットIndex</param>
        /// <param name="increase">増加量</param>
        public void ShowClickResult(int unitIndex, int increase)
        {
            var unit = this.UnitArray[unitIndex];
            if (null == unit)
            {
                return;
            }
        }

        /// <summary>
        /// 描画エリアのサイズを返す.
        /// </summary>
        /// <returns>サイズ</returns>
        public Size GetSize()
        {
            return this.ViewSize;
        }

        /// <summary>
        /// 描画更新可能かどうか.
        /// </summary>
        /// <returns>可否</returns>
        public bool CanViewUpdated()
        {
            return !this.Updating;
        }

        /// <summary>
        /// 表示更新.
        /// </summary>
        public void ViewUpdate()
        {
            // 別スレッドから呼び出された場合の考慮.
            this.UIInvoke(() =>
            {
                this.Updating = true;

                // 残り時間を描画.
                this.lblTime.Text = this.SharedData.GetRemaining();

                // デバッグ出力
                var debugShot = "Unit Count:{0}\n".Fmt(this.SharedData.UnitStateArray.Length);

                // ユニットリスト
                var unitStateArray = this.SharedData.UnitStateArray;
                this.InitUnitArray(unitStateArray.Length);

                for (var ii = 0; ii < unitStateArray.Length; ii++)
                {
                    var state = unitStateArray[ii];
                    var unit = this.UnitArray[ii];

                    if (LIFE_STATE.LIVING == state.LifeState)
                    {
                        unit.Update(state);
                        if (!unit.Visible)
                        {
                            unit.Visible = true;
                        }
                    }
                    else
                    {
                        unit.ImageOff();
                    }

                    // 元の領域.

                    if (!unit.Location.Equals(state.ViewPoint))
                    {
                        unit.BeginControlUpdate();
                        var oldRect = new Rectangle(unit.Location, unit.Size);
                        unit.Location = state.ViewPoint;
                        unit.EndControlUpdate();
                        this.Invalidate(oldRect);
                        this.Update();
                    }

                    // DEBGU情報.
                    debugShot += "{0} > {1} {2} {3} {4} {5}\n".Fmt(
                        state.Id,
                        state.LifeState,
                        state.ViewPoint,
                        state.DefUnit.UnitImageFilePath,
                        unit.Visible,
                        unit.Image);
                }

                this.lblGot.Text = debugShot;

                this.Updating = false;
            });
        }

        /// <summary>
        /// 実行後の総合結果を通知.
        /// </summary>
        public void ShowSetResult()
        {
            // 別スレッドから呼び出された場合の考慮.
            this.UIInvoke(() =>
            {
                this.InitUnitArray(0);
                this.lblTime.Text = @"00.000";

                // 結果ダイアログを表示.
                var dlgResult = this.GameInstance.ShowSetResultDlg(this.SharedData.Result);

                // もう一回の場合.
                if (DialogResult.OK == dlgResult)
                {
                    this.StartNewGame();
                }
                else
                {
                    this.Close();
                }
            });
        }

        /// <summary>
        /// ピクチャーボックスを初期化する.
        /// </summary>
        /// <param name="max">最大数</param>
        private void InitUnitArray(int max)
        {
            for (var ii = 0; ii < this.UnitArray.Length; ii++)
            {
                if (null == this.UnitArray[ii])
                {
                    if (ii < max)
                    {
                        var pb = new UnitPBox(ii);
                        pb.MouseDown += new MouseEventHandler(this.PBox_MouseDown);
                        pb.MouseDown += new MouseEventHandler(this.FormMusExc_MouseDown);
                        pb.MouseUp += new MouseEventHandler(this.FormMusExc_MouseUp);
                        this.Controls.Add(pb);
                        this.UnitArray[ii] = pb;
                    }
                }
                else if (max <= ii)
                {
                    this.UnitArray[ii].ImageOff();
                    this.UnitArray[ii].Visible = false;
                }
            }
        }

        /// <summary>
        /// マウス押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PBox_MouseDown(object sender, MouseEventArgs e)
        {
            var unit = sender as UnitPBox;
            if (null == unit)
            {
                return;
            }

            this.Executor.InputClick(unit.UnitIndex);
        }

        /// <summary>
        /// ユニットを表示するインナークラス.
        /// </summary>
        private class UnitPBox : PictureBoxTransparentLayered
        {
            /// <summary>
            /// ユニットIndex.
            /// </summary>
            public int UnitIndex { get; set; }

            /// <summary>
            /// イメージファイルパス.
            /// </summary>
            public string UnitImageFilePath { get; set; }


            /// <summary>
            /// コンストラクタ.
            /// </summary>
            /// <param name="index">ユニットIndex</param>
            public UnitPBox(int index)
            {
                this.BackColor = Color.Transparent;
                this.Location = new Point(0, 0);
                this.Size = new Size(0, 0);
                this.SizeMode = PictureBoxSizeMode.AutoSize;
                this.TabStop = false;
                this.Visible = false;

                this.UnitIndex = index;
                this.UnitImageFilePath = string.Empty;
            }

            /// <summary>
            /// ユニットの状態を更新する.
            /// </summary>
            /// <param name="state">ユニットステータス</param>
            public void Update(MusExcSharedDataUnitState state)
            {
                if (!this.UnitImageFilePath.Equals(state.DefUnit.UnitImageFilePath))
                {
                    this.UnitImageFilePath = state.DefUnit.UnitImageFilePath;
                    this.Image = MusExc.Conf.IsOffice
                        ? new Bitmap(@".\MusExcResorce\dummy.jpg")
                        : new Bitmap(state.DefUnit.UnitImageFilePath);
                    ;
                }
            }

            /// <summary>
            /// イメージをOffにする.
            /// </summary>
            public void ImageOff()
            {
                this.UnitImageFilePath = string.Empty;
                this.Image = null;
            }
        }
    }
}
