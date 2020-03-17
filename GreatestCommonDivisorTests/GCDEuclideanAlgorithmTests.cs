using System;
using NUnit.Framework;
using GCD;

namespace GreatestCommonDivisorTests
{
    [TestFixture]
    public class GCDEuclideanAlgorithmTests
    {
        [TestCase(3,9,ExpectedResult = 3)]
        [TestCase(3, 9,6,27, ExpectedResult = 3)]
        [TestCase(5, 15, 225, 40, ExpectedResult = 5)]
        [TestCase(6,8, ExpectedResult = 2)]
        [TestCase(8, 6, ExpectedResult = 2)]
        [TestCase(22,121,33,44, ExpectedResult = 11)]
        public int SimpleGCDTests(params int[] numbers)=>GreatestCommonDivisor.EuclideanAlgorithm(numbers);

        [TestCase()]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(-22,11)]
        public void SimpleGCDArgumentException(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() =>GreatestCommonDivisor.EuclideanAlgorithm(numbers));
        }

        [TestCase(3, 9, ExpectedResult = 3)]
        [TestCase(6, 8, ExpectedResult = 2)]
        [TestCase(8, 6, ExpectedResult = 2)]
        public int SimpleGCDTestsTwoArguments(int a,int b) => GreatestCommonDivisor.EuclideanAlgorithm(a,b);
    }
    
}
