using Common.Values;
using PCUITCommon.Users;
using System.Collections.Generic;
using TextInputExercise.Interfaces;

namespace TextInputExercise.TextSet.AnimeTitleSet
{
    /// <summary>
    /// テキストセット－アニタイライティング
    /// </summary>
    public class AnimeTitleSet : TextSetBase
    {
        /// <summary>
        /// セット名.
        /// </summary>
        public static readonly string Name = @"AniTtlWriting";


        /// <summary>
        /// セット名を返す.
        /// </summary>
        public override string GetGameName()
        {
            return Name;
        }

        /// <summary>
        /// 読み込み処理.
        /// </summary>
        /// <returns>成否</returns>
        public override Result LoadList()
        {
            this.WordList = new List<TextBase>();
            this.WordList.AddRange(AnimeTitleList.GetTitleList());
            return Result.OK();
        }

        /// <summary>
        /// ゲームインスタンスを取得する.
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        /// <returns>ゲームインスタンスインタフェース</returns>
        public override ITIExcGameInstance GetGameInstance(UserData userData)
        {
            return new AnimeTitleSetGameInstance(this, userData);
        }
    }
}
