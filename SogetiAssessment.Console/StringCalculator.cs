using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SogetiAssessment.Console
{
    public class StringCalculator
    {
        public int Add (string numbers)
        {
            string[] delimiters = new string[] { ",", "\n" };
            if(numbers.StartsWith("//"))
            {
                string delimiter = numbers.Substring(2, numbers.IndexOf('\n') - 2);
                if (delimiter.StartsWith("[")) delimiter = delimiter.Substring(1, delimiter.Length - 2);
                delimiters = delimiter.Split(new string[] { "][" }, StringSplitOptions.RemoveEmptyEntries);
                numbers = numbers.Substring(numbers.IndexOf('\n') + 1);
            }
            int result = 0;
            if (String.IsNullOrEmpty(numbers)) return result;

            var numberArray = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            List<string> negatives = new List<string>();
            foreach(var num in numberArray)
            {
                int parsedNum;
                if(int.TryParse(num, out parsedNum))
                {
                    if (parsedNum >= 0)
                    {
                        result += parsedNum > 1000 ? 0 : parsedNum;
                    }
                    else
                    {
                        negatives.Add(num);
                    }
                }
            }
            if(negatives.Count > 0)
            {
                throw new Exception(String.Format("negatives not allowed: {0}", String.Join(",", negatives)));
            }
            return result;
        }
    }
}
