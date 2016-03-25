using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SogetiAssessment.Console;

namespace SogetiAssessment.Tests
{
    [TestClass]
    public class RomanNumeralsTests
    {
        [TestMethod]
        public void OneToRoman()
        {
            int input = 1;
            string expected = "I";
            var actual = input.ToRoman();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeToRoman()
        {
            int input = 3;
            string expected = "III";
            var actual = input.ToRoman();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NineToRoman()
        {
            int input = 9;
            string expected = "IX";
            var actual = input.ToRoman();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OneThousandSixtySixToRoman()
        {
            int input = 1066;
            string expected = "MLXVI";
            var actual = input.ToRoman();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OneThousandNineHundredEightyNineToRoman()
        {
            int input = 1989;
            string expected = "MCMLXXXIX";
            var actual = input.ToRoman();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IToArabic()
        {
            int expected = 1;
            string input = "I";
            var actual = input.ToArabic();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IIIToArabic()
        {
            int expected = 3;
            string input = "III";
            var actual = input.ToArabic();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IXToArabic()
        {
            int expected = 9;
            string input = "IX";
            var actual = input.ToArabic();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MLXVIToArabic()
        {
            int expected = 1066;
            string input = "MLXVI";
            var actual = input.ToArabic();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MCMLXXXIXToArabic()
        {
            int expected = 1989;
            string input = "MCMLXXXIX";
            var actual = input.ToArabic();
            Assert.AreEqual(expected, actual);
        }
    }
}
