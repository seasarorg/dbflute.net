using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFlute.JavaLike.Time
{
    /// <summary>
    /// ISO-8601の暦体系によるタイムゾーン付きの日付/時間です(2007-12-03T10:15:30+01:00 Europe/Parisなど)。
    /// </summary>
    public class ZonedDateTime
    {
        public static ZonedDateTime ofInstant(Instant instant, ZoneId zoneId)
        {
            // TODO 正常なインスタンスを返す
            throw new NotSupportedException();
        }

        public LocalDateTime toLocalDateTime()
        {
            // TODO 正常なインスタンスを返す
            throw new NotSupportedException();
        }

        public LocalDate toLocalDate()
        {
            // TODO 正常なインスタンスを返す
            throw new NotSupportedException();
        }
    }
}
