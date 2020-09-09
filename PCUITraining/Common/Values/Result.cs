using System;

namespace Common.Values
{
    /// <summary>
    /// 戻り値
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 結果.
        /// </summary>
        public enum RESULT
        {
            OK,
            NG,
        }

        /// <summary>
        /// 結果.
        /// </summary>
        protected RESULT OkNg { get; set; }

        /// <summary>
        /// メッセージ.
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// OKかどうか.
        /// </summary>
        public bool IsOK
        {
            get
            {
                return RESULT.OK == this.OkNg;
            }
        }

        /// <summary>
        /// NGかどうか
        /// </summary>
        public bool IsNG
        {
            get
            {
                return RESULT.NG == this.OkNg;
            }
        }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        protected Result()
        {
            // NG値で初期化.
            this.OkNg = RESULT.NG;
            this.Message = string.Empty;
        }

        /// <summary>
        /// OKを生成する.
        /// </summary>
        /// <returns>OK</returns>
        public static Result OK()
        {
            return new Result
            {
                OkNg = RESULT.OK,
            };
        }

        /// <summary>
        /// NGを生成する.
        /// </summary>
        /// <returns>NG</returns>
        public static Result NG()
        {
            return new Result();
        }

        /// <summary>
        /// NGを生成する.
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>NG</returns>
        public static Result NG(string message)
        {
            return new Result
            {
                Message = message,
            };
        }

        /// <summary>
        /// NGを生成する.
        /// </summary>
        /// <param name="message">親エラー</param>
        /// <returns>NG</returns>
        public static Result NG(Result roots)
        {
            return new Result
            {
                Message = roots.Message,
            };
        }

        /// <summary>
        /// NGを生成する.
        /// </summary>
        /// <param name="ex">例外</param>
        /// <returns>NG</returns>
        public static Result NG(Exception ex)
        {
            return new Result
            {
                Message = ex.ToString(),
            };
        }

        /// <summary>
        /// NGを生成する.
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="roots">親エラー</param>
        /// <returns>NG</returns>
        public static Result NG(string message, Result roots)
        {
            return new Result
            {
                Message = $"{message}\n>{roots.Message}",
            };
        }

        /// <summary>
        /// NGを生成する.
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="ex">例外</param>
        /// <returns>NG</returns>
        public static Result NG(string message, Exception ex)
        {
            return new Result
            {
                Message = $"{message}\n>{ex}",
            };
        }
    }
}
