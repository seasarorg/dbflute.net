using DBFlute.JavaLike.Lang;
using System.IO;
using System.Linq;

namespace DBFlute.JavaLike.IO
{
    /// <summary>
    /// [Java]File
    /// </summary>
    public class File
    {
        private readonly string _path;

        public File(string path)
        {
            _path = path;
        }

        public string getName()
        {
            return Path.GetFileName(_path);
        }

        public string[] list(FilenameFilter filter)
        {
            if (isDirectory())
            {
                string[] paths = Directory.GetFiles(_path);
                var filteredPaths = from path in paths where filter.accept(this, path) select path;
                if (filteredPaths != null && filteredPaths.Count() > 0)
                {
                    return filteredPaths.ToArray();
                }
                return null;
            }
            return null;
        }

        public File[] listFiles(FileFilter filter)
        {
            if (isDirectory())
            {
                string[] paths = Directory.GetFiles(_path);
                var filteredFiles = from path in paths where filter.accept(this) select new File(path);
                if (filteredFiles != null && filteredFiles.Count() > 0)
                {
                    return filteredFiles.ToArray();
                }
                return null;
            }
            return null;
        }

        public boolean isDirectory()
        {
            return Directory.Exists(_path);
        }

        public string getCanonicalPath()
        {
            // #pending C#には一意のパスを返すメソッドがないので完全パスで代用
            return Path.GetFullPath(_path);
        }

        public File getParentFile()
        {
            var parent = Directory.GetParent(_path);
            if (parent != null && parent.Exists)
            {
                return new File(parent.FullName);
            }
            return null;
        }
    }
}
