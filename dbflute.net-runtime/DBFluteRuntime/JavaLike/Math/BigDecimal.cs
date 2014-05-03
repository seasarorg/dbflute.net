using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFluteRuntime.JavaLike.Math
{
    /// <summary>
    /// [Java]BigDecimalクラス
    /// </summary>
    [Serializable]
    public sealed class BigDecimal
    {
        // #pending BigInteger intVal

        private int _scale;
        private int _precision;
        private String _stringCache;
        private const long INFLATED = long.MaxValue;
        private long intCompact;
        private const int MAX_COMPACT_DIGITS = 18;
        private const int MAX_BIGINT_BITS = 62;

        // #pending ThreadLocal

        private static readonly BigDecimal[] _zeroThroughTen
            = {
                // #pending BigDecimal配列の初期化
              };

        // #pending ZERO_SCALED_BYの初期化

        #region Half of Long.MIN_VALUE & Long.MAX_VALUE

        private const long HALF_LONG_MAX_VALUE = long.MaxValue / 2;
        private const long HALF_LONG_MIN_VALUE = long.MinValue / 2;

        #endregion

        #region Constants

        public static readonly BigDecimal ZERO = _zeroThroughTen[0];
        public static readonly BigDecimal ONE = _zeroThroughTen[1];
        public static readonly BigDecimal TEN = _zeroThroughTen[10];

        #endregion

        #region Constructors

        // #pending コンストラクタ

        #endregion

        #region Static Factoru Methods

        public static BigDecimal valueOf(long unscaledVal, int scale)
        {
            // #pending valueOfメソッドの実装
            return null;
        }

        public static BigDecimal valueOf(long val)
        {
            return null;
        }

        public static BigDecimal valueOf(double val)
        {
            return null;
        }

        #endregion

        #region Arithmetic Operations

        // #pending 加算他色々
        public BigDecimal add(BigDecimal augend)
        {
            return null;
        }

        // add(BigDecimal augend, MathContext)
        #endregion
    }
}
