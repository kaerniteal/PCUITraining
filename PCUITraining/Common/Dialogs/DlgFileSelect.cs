using Common.Extentions;
using System;
using System.IO;
using System.Windows.Forms;

namespace Common.Dialogs
{
    /// <summary>
    /// File選択ダイアログクラス.
    /// </summary>
    public class DlgFileSelect
    {
        /// <summary>
        /// OpenFileDialog
        /// </summary>
        private OpenFileDialog Ofd { get; set; }

        /// <summary>
        /// ファイル名.
        /// </summary>
        public string FileName
        {
            get
            {
                return this.Ofd.FileName;
            }
        }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="title">ダイアログタイトル</param>
        /// <param name="filter">フィルタ</param>
        /// <param name="filePath">既選択ファイルパス</param>
        public DlgFileSelect(string title, string filter, string filePath)
        {
            // デフォルトのファイル名は空欄.
            var fileName = string.Empty;

            // デフォルトのディレクトとしてデスクトップを設定.
            var dirPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            // 現在選択中のファイルを格納しているディレクトリを採取.
            var oldFile = filePath.Trim();
            if (!oldFile.IsEmpty())
            {
                fileName = Path.GetFileName(oldFile);

                var oldDir = Path.GetDirectoryName(oldFile);
                if (Directory.Exists(oldDir))
                {
                    dirPath = oldDir;
                }
            }

            // ダイアログを生成.
            this.Ofd = new OpenFileDialog
            {
                Title = title,
                Filter = filter,
                FileName = fileName,
                InitialDirectory = dirPath,
                CheckFileExists = true,
                CheckPathExists = true,
            };
        }

        /// <summary>
        /// ダイアログ表示.
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowDialog()
        {
            // ダイアログを表示する
            return this.Ofd.ShowDialog();
        }
    }
}
