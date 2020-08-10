using System;
using System.Drawing;
using System.Windows.Forms;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            PCUITraining.Stop();
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            this.lBox3.Location = new Point(this.lBox3.Location.X + 1, this.lBox3.Location.Y + 1);
        }

        private void btnTest2_Click(object sender, EventArgs e)
        {
        }

        private void btnTest3_Click(object sender, EventArgs e)
        {
        }
    }
}
