using System;
using System.Linq;

namespace KatasTDD.Kata1
{
    public class StringCalculator
    {
        public int Add(string parameters)
        {
            if (string.IsNullOrEmpty(parameters.Trim()) || (parameters.Length == 0))
                return 0;

            int sumOfNumbers = 0;
            var stringArray = parameters.Trim().Split(Environment.NewLine.ToCharArray());
            foreach (var str in stringArray)
            {
                sumOfNumbers += str.Split(',').Sum(x => int.Parse(x));
            }

            return sumOfNumbers;
        }
    }
}
