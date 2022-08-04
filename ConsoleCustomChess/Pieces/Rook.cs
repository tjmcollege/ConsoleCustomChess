using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCustomChess.Pieces
{
    public class Rook : Piece
    {
        public Rook(Color color, Coord position) : base(color, position)
        {
            Color = color;
            Position = position;
        }

        public Rook(Color color, Coord position, bool hasMoved) : base(color, position, hasMoved)
        {
            Color = color;
            Position = position;
            HasMoved = hasMoved;
        }

        public override Piece Clone()
        {
            return new Rook(Color, Position, HasMoved);
        }

        public override List<Coord> LegalMoves(PieceGrid pieces)
        {

            List<Coord> result = new List<Coord>();

            result.AddRange(Up());
            result.AddRange(Down());
            result.AddRange(Left());
            result.AddRange(Right());

            return result;

            List<Coord> Up()
            {
                List<Coord> result = new List<Coord>();

                int i = Position.Row - 1;

                while (i >= 0)
                {
                    if (pieces.Grid[i, Position.Column] is not Empty)
                    {
                        if (pieces.Grid[i, Position.Column].Color != Color)
                        {
                            result.Add(new Coord(i, Position.Column));
                            break;
                        }
                        else
                            break;
                    }
                    result.Add(new Coord(i, Position.Column));

                    i--;
                }

                return result;
            }

            List<Coord> Down()
            {
                List<Coord> result = new List<Coord>();

                int i = Position.Row + 1;

                while (i < pieces.Rows)
                {
                    if (pieces.Grid[i, Position.Column] is not Empty)
                    {
                        if (pieces.Grid[i, Position.Column].Color != Color)
                        {
                            result.Add(new Coord(i, Position.Column));
                            break;
                        }
                        else
                            break;
                    }
                    result.Add(new Coord(i, Position.Column));

                    i++;
                }

                return result;
            }

            List<Coord> Left()
            {
                List<Coord> result = new List<Coord>();

                int j = Position.Column - 1;

                while (j >= 0)
                {
                    if (pieces.Grid[Position.Row, j] is not Empty)
                    {
                        if (pieces.Grid[Position.Row, j].Color != Color)
                        {
                            result.Add(new Coord(Position.Row, j));
                            break;
                        }
                        else
                            break;
                    }
                    result.Add(new Coord(Position.Row, j));

                    j--;
                }

                return result;
            }

            List<Coord> Right()
            {
                List<Coord> result = new List<Coord>();

                int j = Position.Column + 1;

                while (j < pieces.Columns)
                {
                    if (pieces.Grid[Position.Row, j] is not Empty)
                    {
                        if (pieces.Grid[Position.Row, j].Color != Color)
                        {
                            result.Add(new Coord(Position.Row, j));
                            break;
                        }
                        else
                            break;
                    }
                    result.Add(new Coord(Position.Row, j));

                    j++;
                }

                return result;
            }
        }
    }
}
