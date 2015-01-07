using System;

namespace DBFlute.JavaLike.Lang
{
    /// <summary>
    /// [Java]Exceptionクラス([C#]System.Exception拡張)
    /// </summary>
    public static class ExceptionExtension
    {
        public static Exception getCause(this System.Exception e)
        {
            return e.InnerException;
        }

        public static string getMessage(this System.Exception e)
        {
            return e.Message;
        }
    }
}
