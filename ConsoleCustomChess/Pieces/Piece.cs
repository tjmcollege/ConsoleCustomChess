using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCustomChess.Pieces
{
    public abstract class Piece
    {
        public Color Color { get; init; }
        public Coord Position { get; set; }

        public bool HasMoved { get; set; } = false;

        public Piece(Color color, Coord position)
        {
            Color = color;
            Position = position;
        }

        public Piece(Color color, Coord position, bool hasMoved)
        {
            Color = color;
            Position = position;
            HasMoved = hasMoved;
        }

        abstract public Piece Clone();

        abstract public List<Coord> LegalMoves(PieceGrid pieces);
    }
}
