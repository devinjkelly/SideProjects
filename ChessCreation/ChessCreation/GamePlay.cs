using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCreation
{
    class GamePlay
    {
        public List<GamePieces> TeamBlack { get; set; } = new List<GamePieces>();
        public List<GamePieces> TeamWhite { get; set; } = new List<GamePieces>();
        public string Player1_PieceSelection { get; set; }
        public string Player2_PieceSelection { get; set; }
        public string Player1_RankFileSelection { get; set; }
        public string Player2_RankFileSelection { get; set; }
        public int TurnCount { get; set; }
        public decimal TimeDisplay { get; }
        public decimal Player1TimeDisplay { get; }
        public decimal Player2TimeDisplay { get; }




        public void PlayerTeamChoice()
        {
            //Random decision on who gets to choose their team color, remind them that black goes second and white goes first. However wins the toss up chooses, and other player is assigned the opposite color.
        }
        public string CheckForCheck()
        {
            // If Player's Piece Selection and RankFileSelection's give Player's piece to attack king next turn then call check.
            //if()
            return "";
        }

        public void Checkmate()
        {
            //If Player's King cannot move out of otherPlayer's attack OR Player cannot move another piece to intercept. Then Player must concede.
            Console.WriteLine();
        }

        public void turnCount()
        {

        }


    }
}
