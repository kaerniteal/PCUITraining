using MouseExercise.Executors;
using MouseExercise.MusExcSet;
using System.Drawing;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Interfaces
{
    /// <summary>
    /// 表示インタフェース
    /// </summary>
    public interface IMusExcViewer
    {
        /// <summary>
        /// 新たな設問を実行クラスに返す.
        /// </summary>
        /// <param name="difficulty">難易度</param>
        /// <returns>設問情報</returns>
        MusExcQuestionDef GetNextQuestionDef(DIFFICULTY difficulty);

        /// <summary>
        /// Clickに対する結果を通知.
        /// </summary>
        /// <param name="unitIndex">ユニットIndex</param>
        /// <param name="increase">増加量</param>
        void ShowClickResult(int unitIndex, int increase);

        /// <summary>
        /// 描画エリアのサイズを返す.
        /// </summary>
        /// <returns>サイズ</returns>
        Size GetSize();

        /// <summary>
        /// 描画更新可能かどうか.
        /// </summary>
        /// <returns>可否</returns>
        bool CanViewUpdated();

        /// <summary>
        /// 表示更新.
        /// </summary>
        void ViewUpdate();

        /// <summary>
        /// 実行後の総合結果を通知.
        /// </summary>
        void ShowSetResult();
    }
}
