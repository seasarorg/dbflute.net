
namespace DBFlute.JavaLike.Lang
{
    /// <summary>
    /// Character(char)クラス拡張用
    /// </summary>
    public static class CharacterExtension
    {
        //public static bool isLowerCase(this char target)
        //{
        //    return char.IsLower(target);
        //}

        //public static bool isUpperCase(this char target)
        //{
        //    return char.IsUpper(target);
        //}

        //public static char toLowerCase(this char target)
        //{
        //    return char.ToLower(target);
        //}

        //public static char toUpperCase(this char target)
        //{
        //    return char.ToUpper(target);
        //}

        public static bool isLowerCase(System.Char target)
        {
            return char.IsLower(target);
        }

        public static bool isUpperCase(System.Char target)
        {
            return char.IsUpper(target);
        }

        public static char toLowerCase(System.Char target)
        {
            return char.ToLower(target);
        }

        public static char toUpperCase(System.Char target)
        {
            return char.ToUpper(target);
        }
    }
}
