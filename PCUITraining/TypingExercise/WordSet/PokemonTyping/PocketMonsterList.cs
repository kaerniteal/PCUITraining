using Common.Extentions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TypingExercise.WordSet.PokemonTyping
{
    /// <summary>
    /// ポケットモンスターリスト
    /// </summary>
    public static class PocketMonsterList
    {
        /// <summary>
        /// リソースファイル.
        /// </summary>
        private static readonly string FileName = @".\WordSet\PokemonTyping\PocketMonsterList.txt";

        /// <summary>
        /// ポケモンリスト.
        /// </summary>
        private static List<PocketMonsterWord> PockMonList = null;

        /// <summary>
        /// ポケモンリストを取得する.
        /// </summary>
        /// <returns></returns>
        public static List<PocketMonsterWord> GetPockeMonList()
        {
            if (null == PockMonList)
            {
                LoadPockeMonList();
            }

            return PockMonList;
        }

        /// <summary>
        /// ロード処理.
        /// </summary>
        /// <returns>ポケモンリスト</returns>
        private static void LoadPockeMonList()
        {
            try
            {
                PockMonList = new List<PocketMonsterWord>();

                var listFile = new StreamReader(FileName);

                var line = string.Empty;
                while ((line = listFile.ReadLine()) != null)
                {
                    var sep = line.IndexOf(",");
                    if (0 < sep)
                    {
                        var num = line.Substring(0, sep);
                        var word = line.Substring(sep + 1);
                        PockMonList.Add(new PocketMonsterWord(num, word));
                    }
                    else
                    {
                        MessageBox.Show("ポケモンデータの読み取りに失敗しました\n{0}".Fmt(line));
                    }
                }

                listFile.Close();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox("ポケモンリストの読み込みに失敗しました。\nfile:{0}".Fmt(FileName));
            }
        }
    }
}
