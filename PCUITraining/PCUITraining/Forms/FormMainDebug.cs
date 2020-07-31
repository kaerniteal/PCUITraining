using MouseExercise;
using MouseExercise.MusExcSet.InsectCollectingSet;
using MouseExercise.Views;
using PCUITCommon.Users;
using System;
using System.Windows.Forms;
using TextInputExercise.TextSet;
using TextInputExercise.TextSet.PokeaniSet;
using TypingExercise;
using TypingExercise.Views;

namespace PCUITraining.Forms
{
    public partial class FormMainDebug : Form
    {
        public FormMainDebug()
        {
            InitializeComponent();
        }

        private void btnPokeMonTyping_Click(object sender, EventArgs e)
        {
            var wordSet = TypExc.GetWordSet(TypingExercise.WordSet.PokemonSet.PokemonSet.Name);
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

        private void button1_Click(object sender, EventArgs e)
        {
            var list = PokeaniTitleList.GetPokemonTitleList();
            foreach(var title in list)
            {
                Console.WriteLine(title.Total + ":" + title.Episode + ":" + title.Text);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var grp = TextCorrect.CompatibleTolerancePattern;
            var haifun = grp[0];

            foreach(var ptn in haifun)
            {
                Console.WriteLine("[" + ptn + "]:" + Char.ConvertToUtf32(ptn, 0));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PCUITraining.Stop();
        }
    }
}
