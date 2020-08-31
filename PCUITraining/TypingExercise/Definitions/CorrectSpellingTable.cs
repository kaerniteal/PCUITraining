using Common.DataIO;
using Common.Extentions;
using System;
using System.Collections.Generic;

namespace TypingExercise.Definitions
{
    /// <summary>
    /// 正しい綴りテーブルクラス.
    /// </summary>
    public class CorrectSpellingTable
    {
        /// <summary>
        /// 正答定義ファイル.
        /// </summary>
        private static readonly string FileName = @".\CorrectSpelling.json";

        /// <summary>
        /// 1文字綴りリスト.
        /// </summary>
        public List<CorrectSpelling> Table1 { get; set; }

        /// <summary>
        /// 2文字綴りリスト.
        /// </summary>
        public List<CorrectSpelling> Table2 { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public CorrectSpellingTable()
        {
            this.Table1 = new List<CorrectSpelling>();
            this.Table2 = new List<CorrectSpelling>();
        }

        /// <summary>
        /// ロード処理.
        /// </summary>
        /// <remarks>失敗時にはNULLを返す</remarks>
        /// <returns>正答テーブル</returns>
        public static CorrectSpellingTable Load()
        {
            try
            {
                return JsonIO<CorrectSpellingTable>.Load(FileName);
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox("定義ファイルの読み込みに失敗しました。\nfile:{0}".Fmt(FileName));
            }

            return new CorrectSpellingTable();
        }

        /// <summary>
        /// セーブ処理.
        /// </summary>
        public void Save()
        {
            try
            {
                JsonIO<CorrectSpellingTable>.Save(this, FileName);
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox("定義ファイルの書き込みに失敗しました。\nfile:{0}".Fmt(FileName));
            }
        }
    }
}
