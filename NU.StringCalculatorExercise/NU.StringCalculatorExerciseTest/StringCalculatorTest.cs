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

        [TestMethod]
        public void StringCalculator1()
        {
        }
    }
}
