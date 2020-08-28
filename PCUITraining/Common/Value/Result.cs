using System;

namespace Common.Value
{
    /// <summary>
    /// 戻り値
    /// </summary>
    public class Result
    {
        /// <summary>
        /// リターンコード.
        /// </summary>
        private int Code { get; set; }

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
                return 0 == Code;
            }
        }

        /// <summary>
        /// NGかどうか
        /// </summary>
        public bool IsNG
        {
            get
            {
                return 0 != Code;
            }
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        private Result()
        {
            this.Code = -1;
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
                Code = 0,
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
        /// <param name="code">エラーコード</param>
        /// <returns>NG</returns>
        public static Result NG(int code)
        {
            return new Result
            {
                Code = code,
            };
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
        /// <param name="code">エラーコード</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>NG</returns>
        public static Result NG(int code, string message)
        {
            return new Result
            {
                Code = code,
                Message = message,
            };
        }

        /// <summary>
        /// NGを生成する.
        /// </summary>
        /// <param name="code">エラーコード</param>
        /// <param name="ex">例外</param>
        /// <returns>NG</returns>
        public static Result NG(int code, Exception ex)
        {
            return new Result
            {
                Code = code,
                Message = ex.ToString(),
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
                Message = $"{message}\n{ex}",
            };
        }

        /// <summary>
        /// NGを生成する.
        /// </summary>
        /// <param name="code">エラーコード</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="ex">例外</param>
        /// <returns>NG</returns>
        public static Result NG(int code, string message, Exception ex)
        {
            return new Result
            {
                Code = code,
                Message = $"{message}\n{ex}",
            };
        }
    }
}
