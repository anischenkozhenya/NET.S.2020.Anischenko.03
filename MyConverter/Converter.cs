using System;
using System.Text;

namespace MyConverter
{
    /// <summary>
    /// 
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Length mantissa in double
        /// </summary>
        private const int MANTISSA = 52;
        /// <summary>
        /// Length exponent in double
        /// </summary>
        private const int EXPONENT = 11;
        /// <summary>
        /// Returns string where number represented in bit format
        /// </summary>
        /// <param name="number">Input number</param>
        /// <returns>bit fotmat in string</returns>
        public static string DoubleToBitFormat(double number)
        {
            #region Exceptions
            //-0
            if (number == 0d && double.IsNegativeInfinity(1d / number))
            {
                return '1' + new string('0', EXPONENT) + new string('0', MANTISSA);
            }
            //+0
            if (number == 0d && double.IsPositiveInfinity(1d / number))
            {
                return '0' + new string('0', EXPONENT) + new string('0', MANTISSA);
            }
            //-Infinity
            if (number == double.NegativeInfinity)
            {
                return '1' + new string('1', EXPONENT) + new string('0', MANTISSA);
            }
            //+Infinity
            if (number == double.PositiveInfinity)
            {
                return '0' + new string('1', EXPONENT) + new string('0', MANTISSA);
            }
            //MinValue
            if (number == double.MinValue)
            {
                return '1' + new string('1', EXPONENT - 1) + '0' + new string('1', MANTISSA);
            }
            //MaxValue
            if (number == double.MaxValue)
            {
                return '0' + new string('1', EXPONENT - 1) + '0' + new string('1', MANTISSA);
            }
            //Epsilon
            if (number == double.Epsilon)
            {
                return '0' + new string('0', EXPONENT) + new string('0', MANTISSA - 1) + '1';
            }
            //NaN
            if (double.IsNaN(number))
            {
                return '1' + new string('1', EXPONENT) + '1' + new string('0', MANTISSA - 1);
            }
            #endregion

            //other numbers
            return GetSign(number) + GetExponent(number) + GetMantissa(number);

        }

        /// <summary>
        /// Returns 0 if the number is positive, and 1 if the number is negative
        /// </summary>
        /// <param name="number">The input number</param>
        /// <returns></returns>
        private static string GetSign(double number)
        {
            return number < 0 ? "1" : "0";
        }

        /// <summary>
        /// Returns the exponent of the number
        /// </summary>
        /// <param name="number">The input number</param>
        /// <returns>the exponent in bite formate</returns>
        private static string GetExponent(double number)
        {
            var result = new StringBuilder(0, EXPONENT);
            //Целочисленная часть(логарифма (безнакового числа) с основанием 2) +константа смещения
            var exp = Math.Floor(Math.Log(Math.Abs(number), 2)) + 1023;
            int pow = EXPONENT - 1;
            for (int i = 0; i < result.MaxCapacity; i++)
            {
                if (Math.Pow(2, pow) <= exp)
                {
                    result.Append('1');
                    exp -= Math.Pow(2, pow);
                }
                else
                {
                    result.Append("0");
                }
                pow--;
            }
            return result.ToString();
        }

        /// <summary>
        /// Returns the exponent of the number
        /// </summary>
        /// <param name="number">The input number</param>
        /// <returns>the matissa in bit formate</returns>
        private static string GetMantissa(double number)
        {
            var result = new StringBuilder(0, MANTISSA + 1);
            double unsignedNumber = Math.Abs(number);
            int pow = (int)Math.Floor(Math.Log(unsignedNumber, 2));
            for (int i = 0; i < result.MaxCapacity; i++)
            {
                if (Math.Pow(2, pow) <= unsignedNumber)
                {
                    result.Append('1');
                    unsignedNumber -= Math.Pow(2, pow);
                }
                else
                {
                    result.Append("0");
                }
                pow--;
            }
            return result.Remove(0, 1).ToString();
        }
    }
}
