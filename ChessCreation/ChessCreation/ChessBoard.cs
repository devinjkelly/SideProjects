using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessCreation.GamePiecesSpecific;

namespace ChessCreation
{
    public class ChessBoard
    {
        //8 Rank rows (Horizontal)

        //8 File Rows (Vertical)




        public static void ChessBoardGeneration()
        {
            King blackKing = new King("King", "E8", "Black");
            King whiteKing = new King("King", "E1", "White");
            Queen blackQueen = new Queen("Queen", "D8", "Black");
            Queen whiteQueen = new Queen("Queen", "D1", "White");
            Bishop blackBishopB = new Bishop("Bishop", "F8", "Black");
            Bishop blackBishopW = new Bishop("Bishop", "C8", "Black");
            Bishop whiteBishopB = new Bishop("Bishop", "F1", "White");
            Bishop whiteBishopW = new Bishop("Bishop", "C1", "White");
            Knight blackKnightB = new Knight("Knight", "B8", "Black");
            Knight blackKnightW = new Knight("Knight", "G8", "Black");
            Knight whiteKnightB = new Knight("Knight", "B1", "White");
            Knight whiteKnightW = new Knight("Knight", "G1", "White");
            Rook blackRookB = new Rook("Rook", "H8", "Black");
            Rook blackRookW = new Rook("Rook", "A8", "Black");
            Rook whiteRookB = new Rook("Rook", "H1", "White");
            Rook whiteRookW = new Rook("Rook", "A1", "White");
            Pawn blackPawnA7 = new Pawn("Pawn", "A7", "Black");
            Pawn blackPawnB7 = new Pawn("Pawn", "B7", "Black");
            Pawn blackPawnC7 = new Pawn("Pawn", "C7", "Black");
            Pawn blackPawnD7 = new Pawn("Pawn", "D7", "Black");
            Pawn blackPawnE7 = new Pawn("Pawn", "E7", "Black");
            Pawn blackPawnF7 = new Pawn("Pawn", "F7", "Black");
            Pawn blackPawnG7 = new Pawn("Pawn", "G7", "Black");
            Pawn blackPawnH7 = new Pawn("Pawn", "H7", "Black");
            Pawn whitePawnA2 = new Pawn("Pawn", "A2", "White");
            Pawn whitePawnB2 = new Pawn("Pawn", "B2", "White");
            Pawn whitePawnC2 = new Pawn("Pawn", "C2", "White");
            Pawn whitePawnD2 = new Pawn("Pawn", "D2", "White");
            Pawn whitePawnE2 = new Pawn("Pawn", "E2", "White");
            Pawn whitePawnF2 = new Pawn("Pawn", "F2", "White");
            Pawn whitePawnG2 = new Pawn("Pawn", "G2", "White");
            Pawn whitePawnH2 = new Pawn("Pawn", "H2", "White");

        }



    }
}
