using System;
using System.Windows.Forms;

namespace PCUITraining
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // メイン処理.
            PCUITraining.Start();
        }
    }
}
