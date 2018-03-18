using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorDataCollector.Util
{
    public static class MathUtil
    {
        /// <summary>
        /// より小さい倍数を求める（倍数で切り捨てられるような値）
        ///（例）倍数 = 10 のとき、12 → 10, 17 → 10
        /// </summary>
        /// <param name="value">入力値</param>
        /// <param name="multiple">倍数</param>
        /// <returns>倍数で切り捨てた値</returns>
        public static double MultipleFloor(double value, double multiple)
        {
            return Math.Floor(value / multiple) * multiple;
        }

        /// <summary>
        /// より大きい倍数を求める（倍数で繰り上がるような値）
        ///（例）倍数 = 10 のとき、12 → 20, 17 → 20
        /// </summary>
        /// <param name="value">入力値</param>
        /// <param name="multiple">倍数</param>
        /// <returns>倍数で切り上げた値</returns>
        public static double MultipleCeil(double value, double multiple)
        {
            return Math.Ceiling(value / multiple) * multiple;
        }
    }
}