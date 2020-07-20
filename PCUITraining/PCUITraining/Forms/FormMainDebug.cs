using Common.Controls;
using Common.Threads.Sample;
using MouseExercise;
using MouseExercise.MusExcSet;
using MouseExercise.MusExcSet.InsectCollectingSet;
using MouseExercise.Views;
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
        public FormMainDebug()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TaskSample.Sample();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PCUITraining.Stop();
        }
    }
}
