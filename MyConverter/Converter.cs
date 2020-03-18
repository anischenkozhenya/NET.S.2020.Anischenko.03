using System;
using System.Text;

namespace MyConverter
{
    public static class Converter
    {
        private const int ExponentLength = 11;
        private const int MantissaLength = 52;
        public static string DoubleToBitFormat(this double number)
        {
            return GetSign(number)+ GetExponent(number) + GetMantissa(number);
        }

        private static string GetSign(double number)
        {
            var sign = number < 0 ? "1" : "0";
            return sign;
        }

        private static string GetExponent(double number)
        {
            number = Math.Abs(number);
            var result = new StringBuilder(0, ExponentLength);
            var exp = Math.Floor(Math.Log(number, 2)) + ((1 << (ExponentLength - 1)) - 1);
            for (int i = 0, pow = ExponentLength - 1; i < result.MaxCapacity; i++, pow--)
            {
                if (Math.Pow(2, pow) <= exp)
                {
                    result.Append("1");
                    exp -= Math.Pow(2, pow);
                }
                else
                {
                    result.Append("0");
                }
            }
            return result.ToString();
        }
        private static string GetMantissa(double number)
        {
            number = Math.Abs(number);
            var result = new StringBuilder(0, MantissaLength + 1);
            for (int i = 0, pow = (int)Math.Floor(Math.Log(number, 2)); i < result.MaxCapacity; i++, pow--)
            {
                if (Math.Pow(2, pow) <= number)
                {
                    result.Append("1");
                    number -= Math.Pow(2, pow);
                }
                else
                {
                    result.Append("0");
                }
            }
            return result.Remove(0, 1).ToString();
        }

        
       

       
    }
}
