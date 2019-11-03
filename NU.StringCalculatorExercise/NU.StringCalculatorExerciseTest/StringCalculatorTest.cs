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
        public void Add_Pass_EmptyString_ReturnZero(string input, int expected)
        {
            Assert.AreEqual(stringCalculator.Add(input), expected);
        }

        [DataTestMethod]
        [DataRow("0,1", 1)]
        [DataRow("1,1", 2)]
        public void Add_Pass_Two_Integers_Return_Their_Sum(string input, int expected)
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
        public void Add_Invliad_Number_Passed_Trow_An_Argument_Exception(string testMethodType, string input, int expected)
        {
            Assert.ThrowsException<ArgumentException>(() => stringCalculator.Add(input));
        }

        [DataTestMethod]
        [DataRow("0,1", 1)]
        [DataRow("1,1", 2)]
        [DataRow("1,1\n2", 4)]
        public void Add_Pass_Multiple_String_Numbers_WithCommas_And_NewLine_Return_Their_Sum(string input, int expected)
        {
            Assert.AreEqual(stringCalculator.Add(input), expected);
        }

        [DataTestMethod]
        [DataRow("//;\n1;2", 3)]
        [DataRow("//,\n2,2", 4)]
        public void Add_Pass_Custom_Single_Delimiter_Use_That_Delimiter_Return_Their_Sum(string input, int expected)
        {
            Assert.AreEqual(stringCalculator.Add(input), expected);
        }

        [DataTestMethod]
        [DataRow("Pass one negitive number : (\"1,-2\")", "1,-2", "-2")]
        [DataRow("Pass multiple negitive numbers : (\"1,-2,-4\")", "1,-2,-4", "-2,-4")]
        public void Add_Pass_Negative_Number_Throw_An_Exception(string testMethodType, string input, string expected)
        {
            String errorMessage = $"negatives not allowed- {expected}";
            var ex = Assert.ThrowsException<Exception>(() => stringCalculator.Add(input));
            Assert.AreEqual(ex.Message, errorMessage);
        }

        [DataTestMethod]
        [DataRow("Sinlge greater the 1000 numers : (\"3,2,1001,4\",9)", "3,2,1001,4", 9)]
        [DataRow("Multiple greater the 1000 numbers : (\"3,2002,1001,4\",7)", "3,2002,1001,4", 7)]
        public void Add_Pass_String_That_Contains_Number_Greater_Than_One_Thousand_Ignore_Numbers_Greater_Than_One_Thousand(string testMethodType, string input, int expected)
        {
            Assert.AreEqual(stringCalculator.Add(input), expected);
        }
    }
}
