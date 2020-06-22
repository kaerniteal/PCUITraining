using Common.Utilities;
using MouseExercise.Interfaces;
using PCUITCommon.Users;
using System.Linq;
using System.Windows.Forms;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.MusExcSet.InsectCollectingSet
{
    /// <summary>
    /// 昆虫採集セットゲームインスタンス.
    /// </summary>
    public class InsectCollectingSetGameInstance : IMusExcGameInstance
    {
        /// <summary>
        /// 昆虫採集セット.
        /// </summary>
        private InsectCollectingSet ICSet { get; set; }

        /// <summary>
        /// ユーザーデータ.
        /// </summary>
        private UserData UserData { get; set; }

        /// <summary>
        /// ゲームデータ.
        /// </summary>
        private InsectCollectingSetGameData GameData { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="icSet">昆虫採集セット</param>
        /// <param name="userData">ユーザーデータ</param>
        public InsectCollectingSetGameInstance(InsectCollectingSet icSet, UserData userData)
        {
            this.ICSet = icSet;
            this.UserData = userData;
            this.GameData = InsectCollectingSetGameData.Load(userData);
        }

        /// <summary>
        /// 新たな設問を取得する.
        /// </summary>
        /// <param name="difficulty">難易度</param>
        /// <returns></returns>
        public MusExcQuestionDef GetQuestionDef(DIFFICULTY difficulty)
        {
            // 対象難易度のリストを取得.
            var targetDfcltList = this.ICSet.GetQuestionDefList(difficulty);

            // リストが存在しない場合.
            if (targetDfcltList.Count <= 0)
            {
                // 難易度を問わず取得.
                targetDfcltList = this.ICSet.GetQuestionDefList(DIFFICULTY.NON);
            }

            // そのリストの中からランダムで一つ返す.
            return targetDfcltList.GetRandom();
        }

        /// <summary>
        /// 結果を表示する.
        /// </summary>
        /// <param name="result">実行結果</param>
        /// <returns>ダイアログリザルト</returns>
        public DialogResult ShowSetResultDlg(MusExcSharedDataResult result)
        {
            // 結果をリストで取得.
            var resultList = result.GetResultList();

            // ゲームデータに反映.
            foreach(var record in resultList)
            {
                var target = this.GameData.RecordList
                    .Find(rec => rec.Name.Equals(record.UnitName));
                if (null == target)
                {
                    this.GameData.RecordList.Add(new InsectCollectingSetGameDataRecord()
                    {
                        Name = record.UnitName,
                        CaptureCount = 1,
                        ImageFilePath = record.DefUnit.UnitImageFilePath,
                        // TODO:スコアも含めるならここで.
                    });
                }
                else
                {
                    target.CaptureCount++;
                }
            }

            // 結果を更新.
            // ユーザーデータが無ければ保存しない.
            if (null != this.UserData)
            {
                this.GameData.Save(this.UserData);
            }

            // TODO:結果ダイアログ表示.


            return DialogResult.Cancel;
        }
    }
}
