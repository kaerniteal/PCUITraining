using Common.Extentions;
using MouseExercise.Executors;
using MouseExercise.Interfaces;
using MouseExercise.MusExcSet;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MouseExercise.Views
{
    /// <summary>
    /// 実行ダイアログ.
    /// </summary>
    public partial class FormMusExc : Form, IMusExcViewer
    {
        /// <summary>
        /// 実行クラスとの共有データ.
        /// </summary>
        private MusExcSharedData SharedData { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FormMusExc()
        {
            InitializeComponent();

            this.SharedData = new MusExcSharedData();
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
                this.SharedData.Continue = false;
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

        private void FormMusExc_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("release");
        }

        /// <summary>
        /// 表示更新.
        /// </summary>
        public void ViewUpdate()
        {
            if (this.SharedData.Updating)
            {
                return;
            }

            // 別スレッドから呼び出された場合
            if (this.InvokeRequired)
            {
                this.UIInvoke(this.ViewUpdate);
                return;
            }

            this.SharedData.Updating = true;

            this.lblDebug.Text = "Counter:" + this.SharedData.Counter;

            var h = this.Size.Height;
            var w = this.Size.Width;

            var x = this.Size.Width - this.SharedData.Counter * 10 % w;
            var y = this.SharedData.Counter / h;
            this.pb1.Location = new Point(x, y);

            this.SharedData.Updating = false;
        }

        private void FormMusExc_Load(object sender, EventArgs e)
        {
            //this.BackgroundImage = new Bitmap(@".\Resorce\bg_image01.jpg");
//            this.pb1.Image = new Bitmap(@".\Resorce\chou-ao-anime.gif");

            this.BackColor = Color.FromArgb(70, 71, 71);
            this.pb1.Image = new Bitmap(@".\Resorce\20140814210541.gif");
            this.pb1.Visible = true;


            var exec = new MusExcExecutor();
            this.SharedData = exec.Start(this);
        }
    }
}
