using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NU.StringCalculatorExercise;

namespace NU.StringCalculatorExerciseTest
{
    [TestClass]
    public class StringCalculatorTest
    {
        private StringCalculator stringCalculator;

        [TestInitialize]
        public void StringCalculatorTestSetup()
        {
            stringCalculator = new StringCalculator();
        }

        [DataTestMethod]
        [DataRow("", 0)]
        public void Add_EmptyString_Is_Passed_ReturnZero(string input, int expected)
        {
            Assert.AreEqual(stringCalculator.Add(input), expected);
        }

        [DataTestMethod]
        [DataRow("0,1", 1)]
        [DataRow("1,1", 2)]
        [DataRow("1, 1, 1", 3)]
        [DataRow("1, 2, 3", 6)]
        public void Add_PassMultipleStringNumbers__ReturnTheirSum(string input, int expected)
        {
            Assert.AreEqual(stringCalculator.Add(input), expected);
        }


    }
}
