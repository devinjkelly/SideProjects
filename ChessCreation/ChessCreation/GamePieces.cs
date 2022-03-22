using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCreation
{
    public class GamePieces
    {
        public string Name { get; set; }
        public string StartingLocation { get; set; }
        public string CurrentLocation { get; set; }
        public string MovementRange { get; set; }
        public string AttackRange { get; set; }
        public string Color { get; set; }
        public string Die { get; set; }

        public GamePieces(string name, string startingLocation, string color)
        {
            this.Name = name;
            this.StartingLocation = startingLocation;
            this.Color = color;
        }

        public void UpdateCurrentLocation()
        {
            //Tracking the piece's current location.
        }

        public void RemoveFromGame()
        {
            //If a piece is attacked it is removed from the game, unless pawn recovers piece.
        }



    }
}
