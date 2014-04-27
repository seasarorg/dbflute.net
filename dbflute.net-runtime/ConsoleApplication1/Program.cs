using DBFluteRuntime.JavaLike.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestBoolean();
            TestInteger();

            Thread.Sleep(3000);
        }

        private static void TestInteger()
        {
            Integer i1 = 100;
            Console.WriteLine(i1);

            Integer i2 = null;
            Console.WriteLine(i2);

            int? i3 = i1;
            Console.WriteLine(i3);

            i1++;
            Console.WriteLine(i1);

            i1++;
            Console.WriteLine(i1);

            i1--;
            Console.WriteLine(i1);

            Console.WriteLine(Integer.valueOf("200"));

            Console.WriteLine(i1.intValue());

            Console.WriteLine(--i1);
            Console.WriteLine(++i1);

            Console.WriteLine(i1--);
            Console.WriteLine(i1++);

            try
            {
                Integer i4 = null;
                Integer i5 = 10;
                Console.WriteLine(i4 * i5);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                int? i6 = null;
                Integer i7 = 10;
                Console.WriteLine(i6 * i7);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                int? i8 = 999;
                Integer i9 = null;
                Console.WriteLine(i8 * i9);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                int? i10 = 999;
                int? i11 = null;
                Console.WriteLine((i10 * i11).HasValue ? "not null" : "null");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// booleanクラス用動作確認の実行
        /// </summary>
        private static void TestBoolean()
        {
            boolean hoge1 = true;
            boolean hoge2 = false;

            if (hoge1)
            {
                Console.WriteLine("true");
            }

            if (hoge2)
            {
                Console.WriteLine("XXXXXXXXXXXX");
            }

            if (hoge1 && hoge2)
            {
                Console.WriteLine("hoge1 && hoge2 -> true");
            }
            if (hoge1 || hoge2)
            {
                Console.WriteLine("hoge1 || hoge2 -> true");
            }

            methodBool(hoge1);
            methodBool(hoge2);

            methodBoolean(true);
            methodBoolean(false);

            bool huga1 = hoge1;
            bool huga2 = hoge2;

            Console.WriteLine(retBool(true));
            Console.WriteLine(retBoolean(boolean.BOOLEAN_FALSE));
        }

        private static void methodBool(bool b)
        {
            Console.WriteLine("methodTrue->{0}", b);
        }

        private static void methodBoolean(boolean b)
        {
            Console.WriteLine("methodTrue->{0}", b);
        }

        private static bool retBool(boolean b)
        {
            return b;
        }

        private static bool retBoolean(bool b)
        {
            return b;
        }
    }
}
