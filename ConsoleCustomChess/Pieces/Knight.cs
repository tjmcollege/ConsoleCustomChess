using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCustomChess.Pieces
{
    public class Knight : Piece
    {
        public Knight(Color color, Coord position) : base(color, position)
        {
            Color = color;
            Position = position;
        }

        public Knight(Color color, Coord position, bool hasMoved) : base(color, position, hasMoved)
        {
            Color = color;
            Position = position;
            HasMoved = hasMoved;
        }

        public override Piece Clone()
        {
            return new Knight(Color, Position, HasMoved);
        }

        public override List<Coord> LegalMoves(PieceGrid pieces)
        {
            List<Coord> result = new List<Coord>();

            result.AddRange(Move());

            return result;

            List<Coord> Move()
            {
                List<Coord> result = new List<Coord>();

                List<Coord> moveset = new List<Coord>()
                {
                    new Coord(Position.Row - 1, Position.Column + 2),
                    new Coord(Position.Row - 1, Position.Column - 2),
                    new Coord(Position.Row + 1, Position.Column + 2),
                    new Coord(Position.Row + 1, Position.Column - 2),
                    new Coord(Position.Row - 2, Position.Column + 1),
                    new Coord(Position.Row - 2, Position.Column - 1),
                    new Coord(Position.Row + 2, Position.Column + 1),
                    new Coord(Position.Row + 2, Position.Column - 1),
                };

                foreach (Coord position in moveset)
                {
                    if (position.Row < 0 || position.Row >= pieces.Rows)
                        continue;
                    if (position.Column < 0 || position.Column >= pieces.Rows)
                        continue;
                    if (pieces.Grid[position.Row, position.Column] is not Empty)
                        if (pieces.Grid[position.Row, position.Column].Color != Color)
                            result.Add(position);
                    if (pieces.Grid[position.Row, position.Column] is Empty)
                        result.Add(position);
                }

                return result;
            }
        }
    }
}
