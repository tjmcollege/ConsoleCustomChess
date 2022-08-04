using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCustomChess.Pieces
{
    public class Empty : Piece
    {
        public Empty(Coord position) : base(Color.Empty, position)
        {
            Position = position;
        }

        public override Piece Clone()
        {
            return new Empty(Position);
        }

        public override List<Coord> LegalMoves(PieceGrid pieces)
        {
            return new List<Coord>() { };
        }
    }
}
