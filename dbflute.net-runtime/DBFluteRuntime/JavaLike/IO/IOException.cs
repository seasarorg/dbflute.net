
namespace DBFluteRuntime.JavaLike.IO
{
    /// <summary>
    /// [Java]IOException
    /// </summary>
    public class IOException : System.IO.IOException
    {
        public IOException() : base() {  }
        public IOException(string message) : base(message) { }
        public IOException(string message, System.Exception innerException)
            : base(message, innerException) { }
    }
}
