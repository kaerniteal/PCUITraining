using System.Collections.Generic;

namespace Common.Lang.Japanese
{
    /// <summary>
    /// 形態素解析クラス
    /// </summary>
    /// <remarks>
    /// NuGetでUwpDesktopを取得して利用する
    /// </remarks>
    public class MorphologicalAnalysis
    {
        /// <summary>
        /// フリガナ解析.
        /// </summary>
        /// <param name="text">漢字文字列</param>
        /// <returns>読みリスト</returns>
        public static List<string> PhoneticAnalyze(string text)
        {
            //var wrods = JapanesePhoneticAnalyzer.GetWords(text);
            //return wrods
            //    .Select(s => s.YomiText)
            //    .ToList();
            return new List<string> { text };
        }
    }
}
