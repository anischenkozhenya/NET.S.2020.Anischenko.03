using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    public static partial class GreatestCommonDivisor
    {
        /// <summary>
        /// Returns the greatest common divisor using the Binary Algorithm from Nth numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>The greatest common divisor</returns>
        public static int BinaryAlgorithm(params int[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException();
            }
            var greatestCommonDivisor = numbers[numbers.Length - 1];
            Array.Sort(numbers);
            for (var i = numbers.Length - 1; i >= 1; i--)
            {
                greatestCommonDivisor = BinaryAlgorithm(numbers[i], numbers[i - 1]);
            }
            return greatestCommonDivisor;
        }

        /// <summary>
        /// Returns the greatest common divisor using the Binary Algorithm from two numbers
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>The greatest common divisor</returns>
        public static int BinaryAlgorithm(int firstNumber, int secondNumber)
        {
            if (firstNumber < 1 || secondNumber < 1)
            {
                throw new ArgumentException();
            }
			if (firstNumber == secondNumber)
				return firstNumber;
			if (firstNumber == 0)
				return secondNumber;
			if (secondNumber == 0)
				return firstNumber;
			if ((~firstNumber & 1) != 0)
			{
				if ((secondNumber & 1) != 0)
					return BinaryAlgorithm(firstNumber >> 1, secondNumber);
				else
					return BinaryAlgorithm(firstNumber >> 1, secondNumber >> 1) << 1;
			}
			if ((~secondNumber & 1) != 0)
				return BinaryAlgorithm(firstNumber, secondNumber >> 1);
			if (firstNumber > secondNumber)
				return BinaryAlgorithm((firstNumber - secondNumber) >> 1, secondNumber);
			return BinaryAlgorithm((secondNumber - firstNumber) >> 1, firstNumber);
		}
    }
}
