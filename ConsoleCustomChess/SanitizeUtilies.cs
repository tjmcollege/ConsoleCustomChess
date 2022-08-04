using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCustomChess
{
    public static class SanitizeUtilities
    {
        public static bool IsParseableCoord(string input)
        {
            List<Char> numbers = new List<Char>() {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            List<Char> delimiters = new List<Char>() { ',' };
            bool hasFirstInt = false;
            bool hasDelimiter = false;

            foreach (Char a in input)
            {
                if (hasFirstInt == false && numbers.Contains(a))
                    hasFirstInt = true;

                if (hasFirstInt == true && delimiters.Contains(a))
                    hasDelimiter = true;

                if (hasFirstInt == true && hasDelimiter == true && numbers.Contains(a))
                    return true;
            }

            return false;
        }

        public static Coord ParseCoord(string input)
        {
            List<Char> numbers = new List<Char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            List<Char> delimiters = new List<Char>() { ',' };

            string[] split = input.Split(',');
            int row = Convert.ToInt32(split[0]);
            int column = Convert.ToInt32(split[1]);

            return new Coord(row, column);
        }
    }
}
