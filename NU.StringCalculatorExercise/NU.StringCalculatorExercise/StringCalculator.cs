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
            var allNumbers = numbers.Split(',').ToList().Take(2);

            if (string.IsNullOrEmpty(numbers))
                return 0;
            else
                return allNumbers.Sum(x => Convert.ToInt32(x));
        }
    }
}
