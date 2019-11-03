using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NU.StringCalculatorExercise
{
    public class StringCalculator
    {
        bool IsDefaultDelimiter = true;
        public int Add(string numbers)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                    return 0;

                string[] strDelimiter = { ",", "\n" };

                if (numbers.StartsWith("//"))
                {
                    IsDefaultDelimiter = false;
                    int startIndex = (numbers.IndexOf("//") + 2);
                    string customeDelimiter = numbers.Substring(startIndex, (numbers.IndexOf("\n") - startIndex));
                    strDelimiter[0] = customeDelimiter;
                }

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

            if (!IsDefaultDelimiter)
                numbers = numbers.Substring(numbers.IndexOf("\n") + 1);

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
