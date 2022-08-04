using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCustomChess.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Color color, Coord position) : base(color, position)
        {
            Color = color;
            Position = position;
        }

        public Pawn(Color color, Coord position, bool hasMoved) : base(color, position, hasMoved)
        {
            Color = color;
            Position = position;
            HasMoved = hasMoved;
        }

        public override Piece Clone()
        {
            return new Pawn(Color, Position, HasMoved);
        }

        public override List<Coord> LegalMoves(PieceGrid pieces)
        {
            List<Coord> result = new List<Coord>();

            result.AddRange(Move());

            return result;

            List<Coord> Move()
            {
                int direction;

                if (Color == Color.White)
                    direction = -1;
                else
                    direction = 1;

                List<Coord> subresult = new List<Coord>();

                List<Coord> moveset = new List<Coord>()
                {
                    new Coord(Position.Row + direction, Position.Column),
                };

                if (HasMoved == false)
                    moveset.Add(new Coord(Position.Row + 2 * direction, Position.Column));

                foreach (Coord position in moveset)
                {
                    if (position.Row < 0 || position.Row >= pieces.Rows)
                        continue;
                    if (position.Column < 0 || position.Column >= pieces.Rows)
                        continue;
                    if (pieces.Grid[position.Row, position.Column] is Empty)
                        subresult.Add(position);
                }

                List<Coord> attackset = new List<Coord>()
                {
                    new Coord(Position.Row + direction, Position.Column - 1),
                    new Coord(Position.Row + direction, Position.Column + 1)
                };

                foreach (Coord position in attackset)
                {
                    if (position.Row < 0 || position.Row >= pieces.Rows)
                        continue;
                    if (position.Column < 0 || position.Column >= pieces.Rows)
                        continue;
                    if (pieces.Grid[position.Row, position.Column] is not Empty)
                        if (pieces.Grid[position.Row, position.Column].Color != Color)
                            subresult.Add(position);
                }

                return subresult;
            }
        }
    }
}
