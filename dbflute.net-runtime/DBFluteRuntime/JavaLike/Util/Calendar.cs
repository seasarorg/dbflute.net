using DBFluteRuntime.JavaLike.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFluteRuntime.JavaLike.Util
{
    // #pending 未実装
    /// <summary>
    /// [Java]Calendar
    /// </summary>
    public class Calendar
    {
        public static Calendar getInstance()
        {
            return new Calendar();
        }

        public void setTime(DateTime date)
        {
            throw new NotSupportedException();
        }

        public int get(int field)
        {
            throw new NotSupportedException();
        }

        public void setTimeInMillis(long ms)
        {
            throw new NotSupportedException();
        }

        public long getTimeInMillis()
        {
            throw new NotSupportedException();
        }

        public void clear()
        {
            throw new NotSupportedException();
        }

        public void set(int year, int month, int date, int hourOfDay, int minute, int second)
        {
            throw new NotSupportedException();
        }

        public void set(int field, int value)
        {
            throw new NotSupportedException();
        }

        public void setTimeZone(TimeZone timeZone)
        {
            throw new NotSupportedException();
        }

        public void add(int field, int amount)
        {
            throw new NotSupportedException();
        }

        public int getActualMinumum(int field)
        {
            throw new NotSupportedException();
        }
    }
}
