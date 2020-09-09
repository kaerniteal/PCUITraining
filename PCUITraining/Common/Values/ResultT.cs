using System;

namespace Common.Values
{
    /// <summary>
    /// 戻り値
    /// </summary>
    public class Result<T> : Result where T : class
    {
        /// <summary>
        /// 値を返したい場合.
        /// </summary>
        public T Value { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        protected Result()
        {
            this.Value = null;
        }


        /// <summary>
        /// OKを生成する.
        /// </summary>
        /// <param name="value">値</param>
        /// <returns>OK</returns>
        public static Result<T> OK(T value)
        {
            return new Result<T>
            {
                OkNg = RESULT.OK,
                Value = value,
            };
        }

        /// <summary>
        /// NGを生成する.
        /// </summary>
        /// <returns>NG</returns>
        public static new Result<T> NG()
        {
            return new Result<T>();
        }

        /// <summary>
        /// NGを生成する.
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>NG</returns>
        public static new Result<T> NG(string message)
        {
            return new Result<T>
            {
                Message = message,
            };
        }

        /// <summary>
        /// NGを生成する.
        /// </summary>
        /// <param name="message">親エラー</param>
        /// <returns>NG</returns>
        public static new Result<T> NG(Result roots)
        {
            return new Result<T>
            {
                Message = roots.Message,
            };
        }

        /// <summary>
        /// NGを生成する.
        /// </summary>
        /// <param name="ex">例外</param>
        /// <returns>NG</returns>
        public static new Result<T> NG(Exception ex)
        {
            return new Result<T>
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
        public static new Result<T> NG(string message, Result roots)
        {
            return new Result<T>
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
        public static new Result<T> NG(string message, Exception ex)
        {
            return new Result<T>
            {
                Message = $"{message}\n>{ex}",
            };
        }
    }
}
