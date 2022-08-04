using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCustomChess
{
    public struct Coord
    {
        public int Row { get; init; }
        public int Column { get; init; }

        public Coord(int row, int column) 
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return Row + "," + Column;
        }

        public static Coord operator +(Coord a, Coord b) => new Coord(a.Row + a.Row, b.Column + b.Column);
    }
}
