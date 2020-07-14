using Common.Controls;
using Common.Utilities;
using MouseExercise;
using MouseExercise.MusExcSet;
using MouseExercise.MusExcSet.InsectCollectingSet;
using MouseExercise.Views;
using PCUITCommon;
using PCUITCommon.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TypingExercise;
using TypingExercise.Views;
using TypingExercise.WordSet.PokemonSet;

namespace PCUITraining.Forms
{
    public partial class FormMainDebug : Form
    {
        private List<Bitmap> Images { get; set; }

        private CustomToolTip ToolTip { get; set; }

        public FormMainDebug()
        {
            InitializeComponent();

            var users = PCUIT.UserDataManager.UserDataList;
            foreach (var user in users)
            {
                var btn = new Button();

                btn.Text = user.Name;
                btn.ForeColor = user.GetFontColor();
                if (user.UseCustomIcon)
                {
                    btn.Image = user.LoadIcon();
                }
                btn.Click += (sender, e) =>
                {
                    var b = sender as Button;
                    b.Visible = false;
                };

                this.tableUserButton.Controls.Add(btn, 0, 0);

            }
        }

        private void btnPokeMonTyping_Click(object sender, EventArgs e)
        {
            var wordSet = TypExc.GetWordSet(PokemonSet.Name);
            var formExec = new FormTypExcDebug(wordSet);
            formExec.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var userData = new UserData
            {
                Name = "けんた",
            };
            var musExcSet = MusExc.GetMusExcSet(InsectCollectingSet.Name);
            var gameInstance = musExcSet.GetGameInstance(userData);
            var formExec = new FormMusExc(gameInstance);
            formExec.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PCUITraining.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = new MusExcSharedDataResult();
            var qList = InsectCollectingSetQuestionList.Load();
            result.DeadUnitList = qList.QuestionList
                .SelectMany(q => q.UnitList)
                .ToList();

            var game = new InsectCollectingSetGameData();
            var ficsr = new FormInsectCollectingSetResult();
            ficsr.ShowSetResultDlg(result, game);
        }
    }
}
