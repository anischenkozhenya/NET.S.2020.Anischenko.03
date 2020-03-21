using System;
using NUnit.Framework;
using GCD;

namespace GreatestCommonDivisorTests
{
    [TestFixture]
    public class GCDTests
    {
        #region
        [TestCase(3,9,ExpectedResult = 3)]
        [TestCase(3, 9,6,27, ExpectedResult = 3)]
        [TestCase(5, 15, 225, 40, ExpectedResult = 5)]
        [TestCase(6,8, ExpectedResult = 2)]
        [TestCase(8, 6, ExpectedResult = 2)]
        [TestCase(22,121,33,44, ExpectedResult = 11)]
        public int EuclideanAlgorithmSimpleTest(params int[] numbers)=>GreatestCommonDivisor.EuclideanAlgorithm(numbers);

        [TestCase()]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(-22,11)]
        public void EuclideanAlgorithmArgumentException(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() =>GreatestCommonDivisor.EuclideanAlgorithm(numbers));
        }

        [TestCase(3, 9, ExpectedResult = 3)]
        [TestCase(6, 8, ExpectedResult = 2)]
        [TestCase(8, 6, ExpectedResult = 2)]
        public int EuclideanAlgorithmTwoArguments(int a,int b) => GreatestCommonDivisor.EuclideanAlgorithm(a,b);
        #endregion



        #region 
        [TestCase()]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(-22, 11)]
        public void BinaryAlgorithmArgumentException(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.BinaryAlgorithm(numbers));
        }

        [TestCase(3, 9, ExpectedResult = 3)]
        [TestCase(6, 8, ExpectedResult = 2)]
        [TestCase(8, 6, ExpectedResult = 2)]
        public int BinaryAlgorithmTwoArguments(int a, int b) => GreatestCommonDivisor.BinaryAlgorithm(a, b);

        [TestCase(3, 9, ExpectedResult = 3)]
        [TestCase(3, 9, 6, 27, ExpectedResult = 3)]
        [TestCase(5, 15, 225, 40, ExpectedResult = 5)]
        [TestCase(6, 8, ExpectedResult = 2)]
        [TestCase(8, 6, ExpectedResult = 2)]
        [TestCase(22, 121, 33, 44, ExpectedResult = 11)]
        public int BinaryAlgorithmSimpleTest(params int[] numbers) => GreatestCommonDivisor.BinaryAlgorithm(numbers);
        #endregion

    }

}
