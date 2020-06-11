using System.Collections.Generic;

namespace TypingExercise.WordSet.PokemonTyping
{
    /// <summary>
    /// ポケットモンスターゲームデータレコード.
    /// </summary>
    public class PocketMonsterGameDataRecord
    {
        /// <summary>
        /// ポケモン名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 捕獲数.
        /// </summary>
        public int CapturCount { get; set; }

        /// <summary>
        /// 最速タイム.
        /// </summary>
        public long ShortestTime { get; set; }

        /// <summary>
        /// イメージファイル名リスト.
        /// </summary>
        public List<string> ImageFileList { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public PocketMonsterGameDataRecord()
        {
            this.Name = string.Empty;
            this.CapturCount = 0;
            this.ShortestTime = 0;
            this.ImageFileList = new List<string>();
        }
    }
}
