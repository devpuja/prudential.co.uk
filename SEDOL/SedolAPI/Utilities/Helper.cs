using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SedolAPI.Utilities
{
    public static class Helper
    {
        private const string sedolPattern = @"^[a-zA-Z0-9]+$";

        private const int charBaseValue = 64;
        private const int addonValue = 9;
        private const char userDefineValue = '9';
        public const int inputLength = 7;
        private static readonly IList<int> indexWeightMultiplyValue = new List<int> { 1, 3, 1, 7, 3, 9, 1 };

        public static bool IsChar(this char c)
        {
            return char.IsLetter(c);
        }

        public static bool IsUserdefined(this char c)
        {
            return c == userDefineValue;
        }

        public static bool IsFormatInValid(this string input)
        {
            Regex regex = new Regex(sedolPattern);
            return !regex.IsMatch(input);
        }

        public static bool IsInValid(this string input)
        {
            return !(input.Length == inputLength);
        }

        public static int GetCharValue(this char c)
        {
            return (c - charBaseValue) + addonValue;
        }

        public static int GetCheckSumValue(int index, int value)
        {
            return value * indexWeightMultiplyValue[index];
        }

        public static int GetCheckDigitValue(int value)
        {
            return 10 - (value % 10);
        }
    }
}