using Common.Controls;
using Common.Extentions;
using System.Windows.Forms;
using TextInputExercise.Executors;

namespace TextInputExercise.TextSet.PokeaniSet
{
    /// <summary>
    /// ポケアニテキスト入力結果表示ダイアログ.
    /// </summary>
    public partial class FormPokeaniSetResultText : Form
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="textResult">テキストの入力結果</param>
        public FormPokeaniSetResultText(TextResult textResult)
        {
            InitializeComponent();

            this.Opacity = 0;

            // アップキャスト.
            var pokeani = textResult.TextBase as PokeaniSetText;
            if (null == pokeani)
            {
                return;
            }

            // 結果を反映.
            this.lblSeries.Text = pokeani.Series;
            this.lblVolume.Text = pokeani.Volume;
            this.lblEpisode.Text = pokeani.Episode;
            this.lblText.Text = pokeani.Text;
            this.lblEtime.Text = "{0}ms".Fmt(textResult.MeasuredTime);
        }

        /// <summary>
        /// ロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPokeaniSetResultText_Load(object sender, System.EventArgs e)
        {
            var aoe = new AnimationOpacityEffect(this);
            aoe.FadeIn(200);
        }

        /// <summary>
        /// KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPokeaniSetResultText_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 何か押下されたら消える.
            this.Close();
        }
    }
}
