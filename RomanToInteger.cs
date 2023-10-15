using System;
using System.Collections.Generic;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(FromRoman("IV"));
    }

    public static string ToRoman(int n)
    {
        Dictionary<int, string> romanNumerals = new Dictionary<int, string>()
        {
        { 1, "I" },
        { 4, "IV" },
        { 5, "V" },
        { 9, "IX" },
        { 10, "X" },
        { 40, "XL" },
        { 50, "L" },
        { 90, "XC" },
        { 100, "C" },
        { 400, "CD" },
        { 500, "D" },
        { 900, "CM" },
        { 1000, "M" }
        };

        string romanString = "";

        foreach (var key in romanNumerals.Keys.OrderByDescending(x => x))
        {
            while(n >= key)
            {
                romanString += romanNumerals[key];
                n -= key;
            }
        }
        return romanString;

    }

    public static int FromRoman(string romanNumeral)
    {
        Dictionary<char, int> romanNumerals = new Dictionary<char, int>()
        {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
        };
        int result = 0, prevValue = 0;

        foreach(char c in romanNumeral)
        {
            int currentValue = romanNumerals[c];
            if (currentValue > prevValue)
                result += currentValue - 2 * prevValue;
            else
                result += currentValue;

            prevValue = currentValue;
        }
        return result;
    }
}
