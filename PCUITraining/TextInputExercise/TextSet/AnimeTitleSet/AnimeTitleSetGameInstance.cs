using Common.Utilities;
using PCUITCommon.Users;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TextInputExercise.Executors;
using TextInputExercise.Interfaces;

namespace TextInputExercise.TextSet.AnimeTitleSet
{
    /// <summary>
    /// アニタイライティングゲームインスタンス.
    /// </summary>
    public class AnimeTitleSetGameInstance : ITIExcGameInstance
    {
        /// <summary>
        /// アニタイセット.
        /// </summary>
        private AnimeTitleSet AnimeTitleSet { get; set; }

        /// <summary>
        /// ユーザーデータ.
        /// </summary>
        private UserData UserData { get; set; }

        /// <summary>
        /// ゲームデータ.
        /// </summary>
        private AnimeTitleSetGameData GameData { get; set; }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="aniTtlSet">アニタイセット</param>
        /// <param name="userData">ユーザーデータ</param>
        public AnimeTitleSetGameInstance(AnimeTitleSet aniTtlSet, UserData userData)
        {
            this.AnimeTitleSet = aniTtlSet;
            this.UserData = userData;
            this.GameData = AnimeTitleSetGameData.Load(userData);
        }

        /// <summary>
        /// 新たな文字列リストを作成して返す.
        /// </summary>
        /// <param name="length">リスト長</param>
        /// <returns>単語リスト</returns>
        public List<TextBase> CreateNewTextList(int length)
        {
            return this.AnimeTitleSet.CreateNewWordList(length);
        }

        /// <summary>
        /// 共通設定を返す.
        /// </summary>
        /// <returns>共通設定eturns>
        public TextConf GetTextConf()
        {
            return this.GameData.TextConf;
        }

        /// <summary>
        /// Web検索キーワードを生成する.
        /// </summary>
        /// <param name="word">入力対象</param>
        public string CreateWebKeyWord(TextBase word)
        {
            // 検索キーワード.
            var text = word.Text;

            // アニメタイトルをKeyword に加える.
            var aniTtl = word as AnimeTitleSetText;
            if (null == aniTtl)
            {
                return text;
            }

            return $"{aniTtl.GetAnimation()}+{text}";
        }

        /// <summary>
        /// 文字列入力毎の結果を表示する.
        /// </summary>
        /// <param name="result">単語入力結果</param>
        public void ShowTextResult(TextResult result)
        {
            if (!this.GameData.TextConf.ShowTextResult)
            {
                return;
            }

            // 文字列の結果表示ダイアログを表示.
            var dlg = new FormAnimeTitleSetResultText(result);
            dlg.ShowDialog();
        }

        /// <summary>
        /// 実行結果を表示する.
        /// </summary>
        /// <param name="result">実行結果</param>
        /// <returns>表示結果</returns>
        public DialogResult ShowSetResultDlg(SetResult result)
        {
            // 結果生成.
            var resList = result.TextResultList
                .Select(textResult =>
                {
                    var pokeAni = textResult.TextBase as AnimeTitleSetText;
                    if (null == pokeAni)
                    {
                        return null;
                    }

                    // ユーザーデータのタイトル別レコードを取得する.
                    var record = this.GameData.RecordList
                        .Find(rec => rec.Title.Equals(pokeAni.Text));

                    // 存在しない場合は新たに生成して追加しておく.
                    if (null == record)
                    {
                        record = new AnimeTitleSetGameDataRecord(pokeAni);
                        this.GameData.RecordList.Add(record);
                    }

                    // これまでの最速タイムを上回っているかどうか.
                    var update = false;
                    if ((record.ShortestTime <= 0) ||
                        (textResult.MeasuredTime < record.ShortestTime))
                    {
                        record.ShortestTime = textResult.MeasuredTime;
                        update = true;
                    }

                    // 入力回数をインクリメント.
                    record.InputedCount++;

                    // 結果表示用のデータにして返す.
                    return new AnimeTitleSetTextResult(textResult, update);
                })
                .ToList();

            //**************************************************//
            // ユーザーデータがnullの場合、保存処理等は走らない //
            //**************************************************//
            if (null != this.UserData)
            {
                // ソートしときます.
                this.GameData.RecordList = this.GameData.RecordList
                                                    .OrderBy(rec => rec.Animation)
                                                    .ThenBy(rec => rec.ID)
                                                    .ToList();

                this.GameData.Save(this.UserData);
            }

            // 結果表示ダイアログを表示.
            var setResultDlg = new FormAnimeTitleSetResultSet(resList);
            return setResultDlg.ShowDialog();
        }
    }
}
