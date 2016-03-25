using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SogetiAssessment.Console;

namespace SogetiAssessment.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        StringCalculator calculator;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new StringCalculator();
        }

        [TestMethod]
        public void EmptyStringReturns0()
        {
            string input = "";
            int expected = 0;
            var result = calculator.Add(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OneNumberReturnsSame()
        {
            string input = "1";
            int expected = 1;
            var result = calculator.Add(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OnePlusTwoEqualsThree()
        {
            string input = "1,2";
            int expected = 3;
            var result = calculator.Add(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TenNumbers()
        {
            string input = "1,2,3,4,5,6,7,8,9,10";
            int expected = 55;
            var result = calculator.Add(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ArbitraryNumbers()
        {
            var rnd = new Random();
            int numValues = rnd.Next(100);
            string[] input = new string[numValues];
            int expected = 0;
            for (var i = 0; i < numValues; i++)
            {
                input[i] = i.ToString();
                expected += i;
            }
            var result = calculator.Add(String.Join(",", input));
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Newlines()
        {
            string input = "1\n2,3";
            int expected = 6;
            var result = calculator.Add(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DefineDelimiter()
        {
            string input = "//;\n1;2";
            int expected = 3;
            var result = calculator.Add(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NegativesNotAllowedOneNegative()
        {
            string input = "-1";
            string expectedException = "negatives not allowed: -1";
            try
            {
                var result = calculator.Add(input);
                Assert.Fail();
            }
            catch(Exception ex)
            {
                Assert.AreEqual(expectedException, ex.Message);
            }
        }

        [TestMethod]
        public void NegativesNotAllowedMultipleNegatives()
        {
            string input = "-1,2,-3,4";
            string expectedException = "negatives not allowed: -1,-3";
            try
            {
                var result = calculator.Add(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedException, ex.Message);
            }
        }

        [TestMethod]
        public void IgnoreThousands()
        {
            string input = "2,1001";
            int expected = 2;
            var result = calculator.Add(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnyLengthDelimiter()
        {
            string input = "//[***]\n1***2***3";
            int expected = 6;
            var result = calculator.Add(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MultipleArbitraryDelimiters()
        {
            string input = "//[*][%]\n1*2%3";
            int expected = 6;
            var result = calculator.Add(input);
            Assert.AreEqual(expected, result);
        }
    }
}