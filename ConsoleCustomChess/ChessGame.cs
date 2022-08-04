using ConsoleCustomChess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCustomChess
{
    public class ChessGame
    {
        public PieceGrid Board { get; private set; }

        public List<PieceGrid> BoardStates { get; private set; } = new List<PieceGrid>();

        public int TurnCount { get; private set; } = 0;

        private Color colorTurn = Color.White;

        private bool isCheckmate = false;

        private bool isCheck = false;

        public ChessGame(PieceGrid pieces)
        {
            Board = pieces;
        }

        public void Run()
        {
            while (!isCheckmate)
            {
                isCheck = CheckCheckColor(colorTurn) ? true : false;

                PieceGrid previousBoard = Board.Clone();
                BoardStates.Add(previousBoard);

                while (true)
                {
                    TurnCount++;
                    Board.Display();

                    Coord pieceSelection = SelectColoredPiece(colorTurn);
                    Coord moveSelection = SelectLegalMove(pieceSelection);
                    Board.Move(pieceSelection, moveSelection);
                    Board.SetLegalMoves(Board);

                    if (CheckCheckColor(colorTurn))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You cannot place your King in check.");
                        Console.ForegroundColor = ConsoleColor.White;
                        TurnCount--;
                        Board = BoardStates[TurnCount].Clone();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                if (colorTurn == Color.White)
                    colorTurn = Color.Black;
                else
                    colorTurn = Color.White;
            }
        }

        private Coord SelectColoredPiece(Color color)
        {
            Console.WriteLine($"{colorTurn}, select a piece to move.");

            while (true)
            {
                while (true)
                {
                    string input = Console.ReadLine();

                    if (!SanitizeUtilities.IsParseableCoord(input))
                    {
                        Console.WriteLine("Please enter a coordinate like so: #,#");
                        break;
                    }

                    Coord coord = SanitizeUtilities.ParseCoord(input);

                    if (!(coord.Row >= 0 && coord.Row < Board.Rows && coord.Column >= 0 && coord.Column < Board.Columns))
                    {
                        Console.WriteLine("Please enter a coordinate inbounds.");
                        break;
                    }

                    if(!(Board.Grid[coord.Row, coord.Column].Color == color))
                    {
                        Console.WriteLine("You can only select your own pieces.");
                        break;
                    }

                    if (!(Board.Grid[coord.Row, coord.Column].LegalMoves(Board).Count > 0))
                    {
                        Console.WriteLine($"{Board.Grid[coord.Row, coord.Column]} has no legal moves.");
                        break;
                    }

                    return coord;
                }
            }
        }

        private Coord SelectLegalMove(Coord coord)
        {
            Console.WriteLine("Select a position to move to.");

            int count = 0;
            List<Coord> legalMoves = Board.Grid[coord.Row, coord.Column].LegalMoves(Board);
            foreach (Coord legalMove in legalMoves)
            {
                Console.WriteLine(count + ": " + legalMove);
                count++;
            }


            bool fail = true;
            int selection = 0;
            do
            {
                string input = Console.ReadLine();
                try
                {
                    selection = Convert.ToInt32(input);
                    fail = false;
                }
                catch (Exception ex)
                {

                }
            }
            while (fail);

            return legalMoves[selection];
        }

        private Coord KingPosition(Color color)
        {
            foreach (Piece piece in Board.Grid)
            {
                if (piece is King && piece.Color == color)
                {
                    return piece.Position;
                }
            }

            throw new Exception($"{color}'s king could not be found.");
        }

        private bool CheckCheckColor(Color color)
        {
            if (color == Color.White && Board.blackLegalPositions.Contains(KingPosition(color)))
                return true;
            if (color == Color.Black && Board.whiteLegalPositions.Contains(KingPosition(color)))
                return true;

            return false;
        }

        private bool CheckCheckmateColor(Color color)
        {
            PieceGrid tempBoard = Board.Clone();

            foreach (Coord legalMove in Board.Grid[KingPosition(color).Row, KingPosition(color).Column].LegalMoves(Board))
            {
            }

            return false;
        }

    }
}
