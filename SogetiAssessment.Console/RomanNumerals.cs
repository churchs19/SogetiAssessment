using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SogetiAssessment.Console
{
    public static class RomanNumerals
    {
        private  struct RomanNumeral
        {
            public int Number;
            public string Numeral;
        }

        private static readonly List<RomanNumeral> numerals = new List<RomanNumeral>()
        {
            new RomanNumeral() { Number = 1000, Numeral = "M" },
            new RomanNumeral() { Number =  900, Numeral = "CM"},
            new RomanNumeral() { Number =  500, Numeral = "D"},
            new RomanNumeral() { Number =  400, Numeral = "CD"},
            new RomanNumeral() { Number =  100, Numeral = "C"},
            new RomanNumeral() { Number =  90, Numeral = "XC"},
            new RomanNumeral() { Number =  50, Numeral = "L"},
            new RomanNumeral() { Number =  40, Numeral = "XL"},
            new RomanNumeral() { Number =  10, Numeral = "X"},
            new RomanNumeral() { Number =  9, Numeral = "IX"},
            new RomanNumeral() { Number =  5, Numeral = "V"},
            new RomanNumeral() { Number =  4, Numeral = "IV"},
            new RomanNumeral() { Number =  1, Numeral = "I"},
        };

        public static string ToRoman(this int arabic)
        {
            var workingArabic = arabic;
            string output = "";
            foreach(RomanNumeral numeral in numerals)
            {
                while(workingArabic >= numeral.Number)
                {
                    output += numeral.Numeral;
                    workingArabic -= numeral.Number;
                }
            }
            return output;
        }

        public static int ToArabic(this string roman)
        {
            int output = 0;
            foreach(RomanNumeral numeral in numerals)
            {
                if(roman.StartsWith(numeral.Numeral))
                {
                    output += numeral.Number;
                    if (roman.Length > numeral.Numeral.Length)
                    {
                        output += roman.Substring(numeral.Numeral.Length).ToArabic();
                    }
                    return output;
                }
            }
            return output;
        }
    }
}
