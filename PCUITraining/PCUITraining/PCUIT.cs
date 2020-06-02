using System.Windows.Forms;

namespace PCUITraining
{
    /*
     * PCUITメインクラス.
     */
    public class PCUIT
    {
        /*
         * シングルトンインスタンス.
         */
        private static PCUIT instance = new PCUIT();
        
        /*
         * コンストラクタ.
         */
        private PCUIT()
        {
        }

        /*
         * 初期化.
         */
        public static void Init()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        /*
         * 開始.
         */
        public static void Start()
        {
            Application.Run(new Form1());
        }
    }
}
