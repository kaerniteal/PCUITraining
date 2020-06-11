using Common.Controls;
using PCUITCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TypingExercise;
using TypingExercise.Views;
using TypingExercise.WordSet.PokemonTyping;

namespace PCUITraining.Forms
{
    public partial class FormMainDebug : Form
    {
        private List<Bitmap> Images { get; set; }
        private int index = 0;

        private CustomToolTip ToolTip { get; set; }

        public FormMainDebug()
        {
            InitializeComponent();

            var users = PCUIT.UserDataManager.UserDataList;
            foreach(var user in users)
            {
                var btn = new Button();

                btn.Text = user.Name;
                btn.ForeColor = user.GetFontColor();
                if (user.UseCustomIcon)
                {
                    Bitmap bitmap = user.LoadIcon();
                    btn.Image = bitmap;
                }
                btn.Click += (sender, e) =>
                {
                    var b = sender as Button;
                    b.Visible = false;
                };

                this.tableUserButton.Controls.Add(btn, 0, 0);

            }

//            this.components = new Container();
//            this.ToolTip = new CustomToolTip(this.components);
            this.ToolTip = new CustomToolTip();
            this.ToolTip.CustomFont = PCUIT.GetFont(48);
            this.ToolTip.FontColor = Color.Red;
            this.ToolTip.BackgroundColor = Color.DimGray;
            this.ToolTip.SetToolTip(this.pictureBox1, "ミスタイプ！");
        }

        private void btnPokeMonTyping_Click(object sender, EventArgs e)
        {
            var wordSet = TypExc.GetWordList(PocketMonsterSet.Name);
            var formExec = new FormTypExcDebug(wordSet);
            formExec.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.index++;
            this.pictureBox1.Image = this.Images[this.index];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PCUITraining.Stop();
        }
    }
}
