using Common.Controls;
using Common.Extentions;
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
using System.Threading;
using System.Threading.Tasks;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Clic begin");

            this.AsyncRapper();

            // ここは AsyncRapper の中の非同期処理を待たずに処理される.
            Console.WriteLine("Clic end");
        }

        /// <summary>
        /// 重い処理のラップ.
        /// </summary>
        private async void AsyncRapper()
        {
            Console.WriteLine("AsyncRapper begin");

            var res = await Task.Run(() => HavyFunc(3000));

            // ここは HavyFunc 実行後に処理される.
            Console.WriteLine("AsyncRapper end result[{0}]sec wait".Fmt(res));
        }

        /// <summary>
        /// 重い処理.
        /// </summary>
        /// <param name="waitTime"></param>
        private int HavyFunc(int waitTime)
        {
            Console.WriteLine("HavyFunc begin");
            Thread.Sleep(waitTime);
            Console.WriteLine("HavyFunc end");

            return waitTime / 1000;
        }
    }
}
