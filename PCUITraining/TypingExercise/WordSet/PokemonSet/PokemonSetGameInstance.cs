using Common.Utilities;
using PCUITCommon.Users;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TypingExercise.Executors;
using TypingExercise.Interfaces;

namespace TypingExercise.WordSet.PokemonSet
{
    /// <summary>
    /// ポケモンタイプゲームインスタンス.
    /// </summary>
    public class PokemonSetGameInstance : ITypExcGameInstance
    {
        /// <summary>
        /// ポケモンセット.
        /// </summary>
        private PokemonSet PokemonSet { get; set; }

        /// <summary>
        /// ユーザーデータ.
        /// </summary>
        private UserData UserData { get; set; }

        /// <summary>
        /// ゲームデータ.
        /// </summary>
        private PokemonSetGameData GameData { get; set; }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="pokemonSet">ポケモンセット</param>
        /// <param name="userData">ユーザーデータ</param>
        public PokemonSetGameInstance(PokemonSet pokemonSet, UserData userData)
        {
            this.PokemonSet = pokemonSet;
            this.UserData = userData;
            this.GameData = PokemonSetGameData.Load(userData);
        }

        /// <summary>
        /// 新たな単語リストを作成して返す.
        /// </summary>
        /// <param name="length">リスト長</param>
        /// <returns>単語リスト</returns>
        public List<WordBase> CreateNewWordList(int length)
        {
            return this.PokemonSet.CreateNewWordList(length);
        }

        /// <summary>
        /// アルファベットを大文字で表示するかどうか.
        /// </summary>
        /// <returns>true:大文字 false：小文字</returns>
        public bool ShowSpellUpper()
        {
            return this.GameData.ShowSpellUpper;
        }

        /// <summary>
        /// Web検索キーワードを生成する.
        /// </summary>
        /// <returns>キーワード</returns>
        public string CreateWebKeyWord(string word)
        {
            var count = this.GameData.AddWebImageSearchKeywordList.Count;
            if (count <= 0)
            {
                return word;
            }

            var keyword = this.GameData.AddWebImageSearchKeywordList.GetRandom();
            return keyword + "+" + word;
        }

        /// <summary>
        /// 単語入力毎の結果を表示する.
        /// </summary>
        /// <param name="result">単語入力結果</param>

        public void ShowWordResult(WordResult result)
        {
            if (!this.GameData.ShowWordResult)
            {
                return;
            }

            // 単語の結果表示ダイアログを表示.
            var wordResultDlg = new FormPokemonSetResultWord();
            wordResultDlg.ShowWordResultDlg(result);
        }

        /// <summary>
        /// 実行結果を表示する.
        /// </summary>
        /// <param name="result">実行結果</param>
        /// <returns>表示結果</returns>
        public DialogResult ShowSetResultDlg(SetResult result)
        {
            // 捕獲判定を実施.
            var judgResultList = result.WordResultList
                .Select(wordResult =>
                {
                    // ユーザーデータのポケモン別レコードを取得する.
                    var record = this.GameData.RecordList
                        .Find(rec => rec.Name.Equals(wordResult.Word));

                    // 存在しない場合は新たに生成して追加しておく.
                    if (null == record)
                    {
                        record = new PokemonSetGameDataRecord
                        {
                            Name = wordResult.Word,
                        };

                        this.GameData.RecordList.Add(record);
                    }

                    //*****************//
                    // 捕獲判定を実施. //
                    //*****************//
                    // ユーザーデータも更新して貰う.
                    return PokemonSetJudgmentResult.Judgment(wordResult, record);
                })
                .ToList();

            //**************************************************//
            // ユーザーデータがnullの場合、保存処理等は走らない //
            //**************************************************//
            if (null != this.UserData)
            {
                this.GameData.Save(this.UserData);
            }

            // 結果表示ダイアログを表示.
            var setResultDlg = new FormPokemonSetResultSet();
            return setResultDlg.ShowSetResultDlg(judgResultList);
        }
    }
}
