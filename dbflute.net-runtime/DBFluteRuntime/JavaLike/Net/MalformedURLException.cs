using System.IO;

namespace DBFlute.JavaLike.Net
{
    /// <summary>
    /// [Java]MalformedURLException
    /// </summary>
    public class MalformedURLException : IOException
    {
        public MalformedURLException() : base() { }
        public MalformedURLException(string message) : base(message) { }
        public MalformedURLException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
