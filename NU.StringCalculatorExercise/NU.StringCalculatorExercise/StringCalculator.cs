using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                    string customDelimiter = numbers.Substring(startIndex, (numbers.IndexOf("\n") - startIndex));

                    if (customDelimiter.Contains('[') && customDelimiter.Contains(']'))
                    {
                        strDelimiter = Regex.Matches(customDelimiter, @"(?<=\[).+?(?=\])").Cast<Match>().Select(m => m.Value).ToArray();
                    }
                    else
                    {
                        strDelimiter[0] = customDelimiter;
                    }
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
            int checkNegitiveValue;
            foreach (var number in numbers)
            {
                if (int.TryParse(number, out int _number))
                {
                    if (IsNumberNegitive(_number))
                    {
                        var allNegitiveNumbers = numbers.Where(x => int.TryParse(x, out checkNegitiveValue) && checkNegitiveValue < 0).ToArray();
                        string negitiveValues = string.Join(",", allNegitiveNumbers.Select(s => s.ToString()));
                        throw new Exception($"negatives not allowed- {negitiveValues}");
                    }
                    if (_number < 1000)
                        sum += _number;
                }
                else
                {
                    throw new ArgumentException("Invalid Input", "_number");
                }
            }
            return sum;
        }

        private bool IsNumberNegitive(int number)
        {
            if (number < 0)
                return true;

            return false;
        }
    }
}
