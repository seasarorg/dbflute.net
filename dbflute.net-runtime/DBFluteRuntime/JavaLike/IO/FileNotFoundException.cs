
namespace DBFluteRuntime.JavaLike.IO
{
    /// <summary>
    /// [Java]FileNotFoundExceptionクラス
    /// </summary>
    public class FileNotFoundException : IOException
    {
        public FileNotFoundException() : base() { }
        public FileNotFoundException(string message) : base(message) { }
        public FileNotFoundException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
