using ConsoleCustomChess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCustomChess
{
    public class PieceGrid
    {
        public int Rows { get; init; }
        public int Columns { get; init; }

        public List<Coord> whiteLegalPositions { get; set; } = new List<Coord>();

        public List<Coord> blackLegalPositions { get; set; } = new List<Coord>();

        public Piece[,] Grid { get; private set; }

        public PieceGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            Grid = CreateEmptyGrid();
        }

        public PieceGrid Clone()
        {
            PieceGrid pieces = new PieceGrid(Rows, Columns);
            foreach(Piece piece in Grid)
            {
                pieces.Place(piece.Clone());
            }
            return pieces;
        }

        private Piece[,] CreateEmptyGrid()
        {
            Piece[,] pieces = new Piece[Rows, Columns];
            for (int i = 0; i < Rows; i++)
                for(int j = 0; j < Columns; j++)
                    pieces[i, j] = new Empty(new Coord(i, j));
            return pieces;
        }

        public void Move(Coord mover, Coord target)
        {
            //Update piece to its new position
            Grid[mover.Row, mover.Column].Position = target;
            Grid[target.Row, target.Column] = Grid[mover.Row, mover.Column];
            Grid[mover.Row, mover.Column] = new Empty(new Coord(mover.Row, mover.Column));
        }

        public void Place(Piece piece)
        {
            Grid[piece.Position.Row, piece.Position.Column] = piece;
        }

        public void Place(List<Piece> pieces)
        {
            foreach (Piece piece in pieces)
            {
                Place(piece);
            }
        }

        public void SetLegalMoves(PieceGrid pieces)
        {
            foreach(Piece piece in Grid)
            {
                if (piece.Color == Color.White)
                    whiteLegalPositions.AddRange(piece.LegalMoves(pieces));
                if (piece.Color == Color.Black)
                    blackLegalPositions.AddRange(piece.LegalMoves(pieces));
            }
        }
        
        public void Display()
        {
            bool light = true;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Grid[i, j].Color == Color.Empty)
                    {
                        if (light == true)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        Console.Write(".");
                    }

                    if(Grid[i, j].Color == Color.White)
                        Console.ForegroundColor = ConsoleColor.White;
                    if (Grid[i, j].Color == Color.Black)
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                    //Should probably use a switch statement
                    if (Grid[i, j] is Bishop)
                        Console.Write("b");
                    if (Grid[i, j] is Rook)
                        Console.Write("r");
                    if (Grid[i, j] is Pawn)
                        Console.Write("p");
                    if (Grid[i, j] is Queen)
                        Console.Write("q");
                    if (Grid[i, j] is King)
                        Console.Write("k");
                    if (Grid[i, j] is Knight)
                        Console.Write("n");

                    light = !light;
                }
                Console.WriteLine();
                //Ensures a checkerboard pattern whether the board is odd or not
                if (Columns % 2 == 0)
                    light = !light;
            }
        }
    }
}
