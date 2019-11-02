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
    }
}
