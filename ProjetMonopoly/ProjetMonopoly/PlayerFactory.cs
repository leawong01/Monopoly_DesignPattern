using System;
using System.Collections.Generic;

namespace ProjetMonopoly
{
    public class PlayerFactory
    {
        /// <summary>
        /// create a new player with a pawn, a starting account of 1500euros, at the position 0
        /// </summary>
        /// <param name="i">
        /// i is a random number between 1 and 8 to determine the pawn of the player
        /// </param>
        /// <returns></returns>
        public Player GetPlayer(int i)
        {
            
            Player player = new Player(Enum.GetName(typeof(Pawns), i), 1500, 0);
            return player;
        }
       
    }
}
