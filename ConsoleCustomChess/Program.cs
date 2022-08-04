using ConsoleCustomChess.Pieces;

namespace ConsoleCustomChess
{

    //TODO
    //Make pawn movement subtractive
    //Additive pieces: Rook Bishop Queen
    //Subtractive pieces: King Knight
    //

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Piece> classicBoard = new List<Piece>()
            {
                new Rook(Color.Black, new Coord(0,0)),
                new Knight(Color.Black, new Coord(0,1)),
                new Bishop(Color.Black, new Coord(0,2)),
                new Queen(Color.Black, new Coord(0,3)),
                new King(Color.Black, new Coord(0,4)),
                new Bishop(Color.Black, new Coord(0,5)),
                new Knight(Color.Black, new Coord(0,6)),
                new Rook(Color.Black, new Coord(0,7)),
                new Pawn(Color.Black, new Coord(1,0)),
                new Pawn(Color.Black, new Coord(1,1)),
                new Pawn(Color.Black, new Coord(1,2)),
                new Pawn(Color.Black, new Coord(1,3)),
                new Pawn(Color.Black, new Coord(1,4)),
                new Pawn(Color.Black, new Coord(1,5)),
                new Pawn(Color.Black, new Coord(1,6)),
                new Pawn(Color.Black, new Coord(1,7)),

                new Pawn(Color.White, new Coord(6,0)),
                new Pawn(Color.White, new Coord(6,1)),
                new Pawn(Color.White, new Coord(6,2)),
                new Pawn(Color.White, new Coord(6,3)),
                new Pawn(Color.White, new Coord(6,4)),
                new Pawn(Color.White, new Coord(6,5)),
                new Pawn(Color.White, new Coord(6,6)),
                new Pawn(Color.White, new Coord(6,7)),
                new Rook(Color.White, new Coord(7,0)),
                new Knight(Color.White, new Coord(7,1)),
                new Bishop(Color.White, new Coord(7,2)),
                new King(Color.White, new Coord(7,3)),
                new Queen(Color.White, new Coord(7,4)),
                new Bishop(Color.White, new Coord(7,5)),
                new Knight(Color.White, new Coord(7,6)),
                new Rook(Color.White, new Coord(7,7))
            };


            PieceGrid pieces = new PieceGrid(8,8);
            //pieces.Place(classicBoard);
            pieces.Place(new King(Color.White, new Coord(4, 4)));
            pieces.Place(new Bishop(Color.White, new Coord(4, 5)));
            pieces.Place(new Rook(Color.Black, new Coord(4, 7)));

            ChessGame game = new ChessGame(pieces);
            game.Run();
        }
    }

    public enum Color { Empty, White, Black };
}