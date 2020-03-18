using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace GCD
{
    /// <summary>
    ///A class for finding the greatest common divisor
    /// </summary>
    public static partial class GreatestCommonDivisor
    {
        /// <summary>
        /// Returns the greatest common divisor using the Euclidean Algorithm from Nth numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>The greatest common divisor</returns>
        public static int EuclideanAlgorithm(params int[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException();
            }
            var greatestCommonDivisor = numbers[numbers.Length - 1];
            Array.Sort(numbers);
            for (var i = numbers.Length - 1; i >= 1; i--)
            {
                greatestCommonDivisor = EuclideanAlgorithm(numbers[i],numbers[i-1]);
            }
            return greatestCommonDivisor;
        }
        /// <summary>
        /// Returns the greatest common divisor using the Euclidean Algorithm from two numbers
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>The greatest common divisor</returns>
        public static int EuclideanAlgorithm(int firstNumber, int secondNumber)
        {
            if (firstNumber < 1 || secondNumber < 1)
            {
                throw new ArgumentException();
            }
            while (firstNumber != secondNumber)
            {
                if (firstNumber > secondNumber)
                {
                    firstNumber -= secondNumber;
                }
                else
                {
                    secondNumber -= firstNumber;
                }
            }
            return firstNumber;
        }
    }
}
