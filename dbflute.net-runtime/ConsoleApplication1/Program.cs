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
            Thread.Sleep(2000);
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
