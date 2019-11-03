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
        public void Add_Two_Integers_Are_Passed_Their_Sum_Is_Return(string input, int expected)
        {
            Assert.AreEqual(stringCalculator.Add(input), expected);
        }

        [DataTestMethod]
        [DataRow("0,1", 1)]
        [DataRow("1,1", 2)]
        [DataRow("1,1,2", 4)]
        public void Add_Pass_Multiple_String_Numbers_WithCommas_Return_Their_Sum(string input, int expected)
        {
            Assert.AreEqual(stringCalculator.Add(input), expected);
        }


        [DataTestMethod]
        [DataRow("ArgumentException", "0,A", 0)]
        [DataRow("ArgumentException", "1,\n", 0)]
        public void Add_Invliad_Number_Passed_Trow_An_Argument_Exception(string paramters, string input, int expected)
        {
            Assert.ThrowsException<ArgumentException>(() => stringCalculator.Add(input));
        }

        [DataTestMethod]
        [DataRow("0,1", 1)]
        [DataRow("1,1", 2)]
        [DataRow("1,1\n2", 4)]
        public void Add_Pass_Multiple_String_Numbers_WithCommas_And_NewLine__Return_Their_Sum(string input, int expected)
        {
            Assert.AreEqual(stringCalculator.Add(input), expected);
        }
    }
}
