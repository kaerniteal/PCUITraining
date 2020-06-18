using Common.Controls;
using Common.Extentions;
using MouseExercise.Executors;
using MouseExercise.Interfaces;
using MouseExercise.MusExcSet;
using PCUITCommon;
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
        /// 捕獲表示ToolTip
        /// </summary>
        private CustomToolTip Ballon { get; set; }

        /// <summary>
        /// 更新中フラグ.
        /// </summary>
        public bool Updating { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="gameInstance">ゲームインスタンス</param>
        public FormMusExc(IMusExcGameInstance gameInstance)
        {
            InitializeComponent();

            this.GameInstance = gameInstance;
            this.SharedData = new MusExcSharedData();
            this.Executor = null;
            this.UnitArray = new UnitPBox[MusExc.Conf.UnitMax];
            this.Ballon = new CustomToolTip
            {
                CustomFont = PCUIT.GetFont(36),
                FontColor = Color.Yellow,
                BackgroundColor = Color.DimGray,
            };

            this.Updating = false;


            if (PCUIT.Conf.IsDebug)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        /// <summary>
        /// フォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMusExc_Load(object sender, EventArgs e)
        {
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
            switch(e.Button)
            {
                case MouseButtons.Left:
                    Console.WriteLine("left press");
                    break;
                case MouseButtons.Middle:
                    Console.WriteLine("mid press");
                    break;
                case MouseButtons.Right:
                    Console.WriteLine("right press");
                    break;
            }
        }

        /// <summary>
        /// マウスボタンリリース.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMusExc_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("release");
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
                this.BackgroundImage = new Bitmap(qDef.BgImageFilePath);
            }
            else
            {
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

            this.Ballon.Active = true;
            this.Ballon.Show("＋{0}秒".Fmt(increase), this, 500);
            unit.Image = null;
        }

        /// <summary>
        /// 描画エリアのサイズを返す.
        /// </summary>
        /// <returns>サイズ</returns>
        public Size GetSize()
        {
            return this.Size;
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
            // 別スレッドから呼び出された場合
            if (this.InvokeRequired)
            {
                this.UIInvoke(this.ViewUpdate);
                return;
            }

            this.Updating = true;
            this.BeginControlUpdate();

            // 残り時間を描画.
            this.lblTime.Text = this.SharedData.GetRemaining();

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
                    unit.Visible = true;
                }
                else
                {
                    unit.Image = null;
                }

                
                unit.Location = state.ViewPoint;
            }

            this.EndControlUpdate();
            this.Updating = false;
        }

        /// <summary>
        /// 実行後の総合結果を通知.
        /// </summary>
        public void ShowSetResult()
        {
            // 別スレッドから呼び出された場合
            if (this.InvokeRequired)
            {
                this.UIInvoke(this.ShowSetResult);
                return;
            }

            this.InitUnitArray(0);
            this.lblTime.Text = @"00.000";

            // TODO:結果ダイアログを表示.
        }

        /// <summary>
        /// ピクチャーボックスを初期化する.
        /// </summary>
        /// <param name="max">最大数</param>
        private void InitUnitArray(int max)
        {
            for(var ii = 0; ii < this.UnitArray.Length; ii++ )
            {
                if (null == this.UnitArray[ii])
                {
                    if (ii < max)
                    {
                        var pb = new UnitPBox(ii);
                        pb.MouseDown += new MouseEventHandler(this.PBox_MouseDown);
                        this.Controls.Add(pb);
                        this.UnitArray[ii] = pb;
                    }
                }
                else if (max <= ii)
                {
                    this.UnitArray[ii].Image = null;
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
        private class UnitPBox : PictureBox
        {
            /// <summary>
            /// ユニットIndex.
            /// </summary>
            public int UnitIndex { get; set; }

            /// <summary>
            /// ユニットID
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
                if(!this.UnitImageFilePath.Equals(state.DefUnit.UnitImageFilePath))
                {
                    this.UnitImageFilePath = UnitImageFilePath;
                    this.Image = state.Image;
                }
            }
        }
    }
}
