using System;
using System.IO;
using System.Windows.Forms;

namespace Common.Dialogs
{
    /// <summary>
    /// Folder選択ダイアログクラス.
    /// </summary>
    public class DlgFolderSelect
    {
        /// <summary>
        /// FolderBrowserDialog
        /// </summary>
        private FolderBrowserDialog Fbd { get; set; }

        /// <summary>
        /// 選択されたパス.
        /// </summary>
        public string SelectedPath
        {
            get
            {
                return this.Fbd.SelectedPath;
            }
        }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="description">説明</param>
        /// <param name="dirPath">既選択ファイルパス</param>
        /// <param name="showNewFolderButton">新しいフォルダーボタンを表示するかどうか</param>
        public DlgFolderSelect(string description, string dirPath, bool showNewFolderButton = true)
        {
            // 現在選択されているディレクトリを採取.
            var dir = dirPath.Trim();
            if (!Directory.Exists(dir))
            {
                // 存在しない場合はデスクトップを選択.
                dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }

            // ダイアログを初期化.
            this.Fbd = new FolderBrowserDialog
            {
                Description = description,
                SelectedPath = dir,
                ShowNewFolderButton = showNewFolderButton,
            };
        }

        /// <summary>
        /// ダイアログ表示.
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowDialog()
        {
            // ダイアログを表示する
            return this.Fbd.ShowDialog();
        }
    }
}
