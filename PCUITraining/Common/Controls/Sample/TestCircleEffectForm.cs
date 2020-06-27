using System.Windows.Forms;

namespace Common.Controls.Sample
{
    public partial class TestCircleEffectForm : Form
    {
        public TestCircleEffectForm()
        {
            InitializeComponent();
        }

        private void TestCircleEffectForm_Load(object sender, System.EventArgs e)
        {
            var ace = new AnimationCircleEffect(this);
            ace.FadeIn(1000);
        }

        private void TestCircleEffectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var ace = new AnimationCircleEffect(this);
            ace.FadeOut(1000, () => { this.Dispose(); });

            e.Cancel = true;
        }
    }
}
