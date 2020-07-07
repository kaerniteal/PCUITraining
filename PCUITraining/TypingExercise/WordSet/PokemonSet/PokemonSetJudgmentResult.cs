using Common.Extentions;
using Common.Utilities;
using System.Drawing;
using TypingExercise.Executors;

namespace TypingExercise.WordSet.PokemonSet
{
    /// <summary>
    /// ポケモンタイプ捕獲判定結果.
    /// </summary>
    public class PokemonSetJudgmentResult
    {
        /// <summary>
        /// 単語入力結果.
        /// </summary>
        private WordResult WordResult { get; set; }

        /// <summary>
        /// ポケモン名
        /// </summary>
        public string Name
        {
            get
            {
                return this.WordResult.Word;
            }
        }

        /// <summary>
        /// 計測タイム.
        /// </summary>
        public long ETime
        {
            get
            {
                return this.WordResult.MeasuredTime;
            }
        }

        /// <summary>
        /// 計測タイム.
        /// </summary>
        public string ETimeStr
        {
            get
            {
                return this.WordResult.MeasuredTime.ToString();
            }
        }

        /// <summary>
        /// 計測タイムを更新したかどうか.
        /// </summary>
        public bool UpdateETime { get; private set; }

        /// <summary>
        /// ミスタイプ回数.
        /// </summary>
        public int MissTypeCount
        {
            get
            {
                return this.WordResult.MissTypeCount;
            }
        }

        /// <summary>
        /// ミスタイプ回数.
        /// </summary>
        public string MissTypeCountStr
        {
            get
            {
                return this.WordResult.MissTypeCount.ToString();
            }
        }

        /// <summary>
        /// 連続ノーミスカウント.
        /// </summary>
        public int ConsecutiveNoMissCount
        {
            get
            {
                return this.WordResult.ConsecutiveNoMissCount;
            }
        }

        /// <summary>
        /// 連続ノーミスカウント.
        /// </summary>
        public string ConsecutiveNoMissCountStr
        {
            get
            {
                return this.WordResult.ConsecutiveNoMissCount.ToString();
            }
        }

        /// <summary>
        /// 捕獲結果.
        /// </summary>
        public bool JudgmentResult { get; private set; }

        /// <summary>
        /// 捕獲数.
        /// </summary>
        public int CapturCount { get; private set; }

        /// <summary>
        /// 捕獲数.
        /// </summary>
        public string CapturCountStr
        {
            get
            {
                return this.CapturCount.ToString();
            }
        }

        /// <summary>
        /// 捕獲判定ログ.
        /// </summary>
        public string JudgLog { get; private set; }

        /// <summary>
        /// 画像イメージ.
        /// </summary>
        public Bitmap PockImage
        {
            get
            {
                return this.WordResult.ImageStore.GetRandomImage();
            }
        }

        /// <summary>
        /// マスターボールによる捕獲かどうか.
        /// </summary>
        public bool UsedMasterBoll
        {
            get
            {
                return this.WordResult.UseMasterBoll;
            }
        }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="wordResult">単語の入力結果</param>
        private PokemonSetJudgmentResult(WordResult wordResult)
        {
            this.WordResult = wordResult;
            this.UpdateETime = false;
            this.JudgmentResult = false;
            this.CapturCount = 0;
            this.JudgLog = string.Empty;
        }

        /// <summary>
        /// 捕獲判定を実施せずに結果だけを生成(ファクトリ)
        /// </summary>
        /// <remarks>ボーナス数値の事前計算用</remarks>
        /// <param name="wordResult">単語の入力結果</param>
        /// <returns>捕獲判定結果</returns>
        public static PokemonSetJudgmentResult CreateResultForCalcBonus(WordResult wordResult)
        {
            // 捕獲結果を返す.
            return new PokemonSetJudgmentResult(wordResult);
        }

        /// <summary>
        /// ※※ 捕獲判定 ※※を実施して結果を生成(ファクトリ)、渡されたユーザーデータも更新する
        /// </summary>
        /// <param name="wordResult">単語の入力結果</param>
        /// <param name="userDataRec">ユーザーデータ(nullも想定)</param>
        /// <returns>捕獲判定結果</returns>
        public static PokemonSetJudgmentResult Judgment(WordResult wordResult, PokemonSetGameDataRecord userDataRec)
        {
            var judgmentResult = new PokemonSetJudgmentResult(wordResult);

            if (wordResult.UseMasterBoll)
            {
                // マスターボールが使用された場合.
                judgmentResult.JudgmentResult = true;
            }
            else
            {
                // ************************ //
                // ※※！！捕獲判定！！※※ //
                // ************************ //

                // 基本捕獲確率.
                var bcp = TypExc.Conf.BaseCaptureProbability;

                // ボーナス.
                var bonus = judgmentResult.GetTotalBonus();

                // 乱数.
                var rand = UtilRandom.Next(100);

                // 評価ログ.
                judgmentResult.JudgLog = @"{0}<{1}+{2}".Fmt(rand, bcp, bonus);

                // 乱数が捕獲確率を下回ったらゲット！！
                judgmentResult.JudgmentResult = (rand < (bcp + bonus));
            }

            // ユーザーデータが存在する場合.
            if (null != userDataRec)
            {
                // これまでの最速タイムを上回っているかどうか.
                if ((userDataRec.ShortestTime <= 0) ||
                    (judgmentResult.ETime < userDataRec.ShortestTime))
                {
                    userDataRec.ShortestTime = judgmentResult.ETime;
                    judgmentResult.UpdateETime = true;
                }

                // 今回が捕獲成功なら
                if (judgmentResult.JudgmentResult)
                {
                    userDataRec.CapturCount++;
                }

                // これまでの捕獲数を格納
                judgmentResult.CapturCount = userDataRec.CapturCount;
            }

            // 捕獲結果を返す.
            return judgmentResult;
        }

        /// <summary>
        /// ボーナス合計.
        /// </summary>
        /// <returns>ボーナス</returns>
        public int GetTotalBonus()
        {
            return GetETimeBonus() + GetConsecutiveBonus();
        }

        /// <summary>
        /// タイムボーナス算出.
        /// </summary>
        /// <returns>ボーナス値</returns>
        public int GetETimeBonus()
        {
            //***************************//
            // 10秒未満ならボーナス
            // 9秒台で+1
            // ・・・
            // 1秒台で+9
            // 1秒以下で+10
            //***************************//

            // かかった時間を算出.
            var mstime = 10999 - this.ETime;
            if (mstime < 0)
            {
                mstime = 0;
            }

            var bonus = mstime / 1000;
            if (this.ETime < 1000)
            {
                // 1秒未満なら追加ボーナス.
                // 10ms早くなる毎に+1
                // 990～999 +0
                // 980～989 +1
                // ・・・
                bonus += 99 - (this.ETime / 10);
            }

            return (int)bonus;
        }

        /// <summary>
        /// 連続ノーミスボーナス.
        /// </summary>
        /// <returns>連続ノーミスボーナス</returns>
        public int GetConsecutiveBonus()
        {
            return this.ConsecutiveNoMissCount * 2;
        }
    }
}
