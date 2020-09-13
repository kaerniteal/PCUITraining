using Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Utilities
{
    /// <summary>
    /// インクリメンタルサーチを扱うためのユーティリティを定義します. 
    /// </summary>
    public static class UtilIncrementalSearch
    {
        /// <summary>
        /// インクリメンタルサーチ処理(文字列).
        /// </summary>
        /// <param name="orgList">絞り込み対象リスト</param>
        /// <param name="keyword">キーワード</param>
        /// <returns>フィルタ後のリスト</returns>
        public static List<string> IncrementalSearch(List<string> orgList, string keyword)
        {
            return IncrementalSearch(orgList, keyword, (src) => { return src; });
        }

        /// <summary>
        /// インクリメンタルサーチ処理(任意の型).
        /// </summary>
        /// <typeparam name="T">元データ型</typeparam>
        /// <param name="orgList">絞り込み対象リスト</param>
        /// <param name="keyword">キーワード</param>
        /// <param name="converter">元データを文字列に変換するデリゲート：(src) => { return src.strparam; }</param>
        /// <returns>フィルタ後のリスト</returns>
        public static List<T> IncrementalSearch<T>(List<T> orgList, string keyword, Func<T, string> converter)
        {
            // 元リストをペアクラスに変換してリスト化.
            var serchList = orgList
                .Select(src => new SearchPare<T> { Src = src, Remaining = converter(src) })
                .ToList();

            // インクリメンタルサーチでフィルタ.
            var filterd = IncSearchIn(serchList, keyword);

            // フィルタ後のリストを返す.
            return filterd
                .Select(pare => pare.Src)
                .ToList();
        }

        /// <summary>
        /// IncrementalSearchの実体(再帰呼び出し)
        /// </summary>
        /// <param name="list">フィルタ対象のペアリスト</param>
        /// <param name="keyword">キーワード</param>
        /// <returns>フィルタ後のリスト</returns>
        private static List<SearchPare<T>> IncSearchIn<T>(List<SearchPare<T>> list, string keyword)
        {
            // Keywordに該当する文字列をもつものだけにフィルタする.
            // Keywordにフルに一致しない場合、後ろから分割位置を一文字ずつズラしながら、
            // 分割した左部に一部でも一致する要素を検索していく.
            // 分割した場合、残りの右部はさらに再帰呼び出しで絞り込む.
            for (var ii = 0; ii < keyword.Length; ii++)
            {
                // keywordを左部と右部に分割(初回は左部に全部、右部なし).
                var keyLeft = keyword.Left(keyword.Length - ii);
                var keyRight = keyword.Right(ii);

                // keywordの左部でフィルタする.
                // keywordの左部に該当した文字列は、
                // 該当した文字列より右側を切り出して残りに入れておく
                // ※ さらに絞り込むかもしれないので.

                // まずは先頭から一致するものだけを検索.
                var filterd = list
                    .Where(pare => pare.Remaining.Left(keyLeft.Length).Equals(keyLeft))
                    .Select(pare => new SearchPare<T> { Src = pare.Src, Remaining = pare.Remaining.Right(keyLeft) })
                    .ToList();

                // 先頭から一致するものが無い場合は、含むものでも検索.
                if (filterd.Count <= 0)
                {
                    filterd = list
                        .Where(pare => pare.Remaining.Contains(keyLeft))
                        .Select(pare => new SearchPare<T> { Src = pare.Src, Remaining = pare.Remaining.Right(keyLeft) })
                        .ToList();
                }

                // keywordの左部に該当する要素がある場合.
                if (0 < filterd.Count)
                {
                    // keywordの右部が存在する場合は、
                    if (!keyRight.IsEmpty())
                    {
                        // その右部でさらにフィルタするために自身を再帰呼び出し.
                        return IncSearchIn(filterd, keyRight);
                    }

                    // keywordの右部が存在しなければこのリストで確定.
                    return filterd;
                }

                // keywordの左部に該当する要素が無い場合.
                // keywordを分割位置をさらに左にズラして再度検索.
            }

            // ループを回りきってもリターンしてない場合は該当する要素なし.
            return new List<SearchPare<T>>();
        }

        /// <summary>
        /// 元データと検索対象残り文字列をペアで持つインナークラス.
        /// </summary>
        private class SearchPare<T>
        {
            /// <summary>
            /// 元データ.
            /// </summary>
            public T Src { get; set; }

            /// <summary>
            /// 検索対象の残り文字列.
            /// </summary>
            public string Remaining { get; set; }
        }
    }
}
