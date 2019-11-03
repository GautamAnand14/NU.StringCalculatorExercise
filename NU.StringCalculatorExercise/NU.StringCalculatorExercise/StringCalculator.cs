using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NU.StringCalculatorExercise
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                    return 0;

                string[] strDelimiter = { ",", "\n" };

                var splitNumbers = SplitNumber(numbers, strDelimiter);
                if (splitNumbers == null)
                    return 0;

                return Sum(splitNumbers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string[] SplitNumber(string numbers, string[] delimiter)
        {
            if (numbers.EndsWith("\n"))
                throw new ArgumentException("Invalid Input");

            return numbers.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }

        private int Sum(string[] numbers)
        {
            int sum = 0;
            foreach (var number in numbers)
            {
                if (int.TryParse(number, out int _number))
                {
                    sum += _number;
                }
                else
                {
                    throw new ArgumentException("Invalid Input", "_number");
                }
            }
            return sum;
        }
    }
}
