using System;
namespace ProjetMonopoly
{
    public class RegularRollDice: DiceRollStrategy
    {
        /// <summary>
        /// implements the function DisplayDiceRoll of the strategy pattern
        /// method that displays the result of the dices and makes the player move when the player is not in jail
        /// </summary>
        /// <param name="dice">
        /// avoid creating a new dice at each turn
        /// </param>
        /// <param name="p">
        /// the player playing
        /// </param>
        /// <param name="turn">
        /// the turn of the current player
        /// </param>
        /// <returns>
        /// if the player made a double it returns turn-1 meaning the for loop will increment the turn
        /// and go back to this player
        /// </returns>
        public int DisplayDiceRoll(Dice dice, Player p, int turn)
        {
            int diceroll = 0;
            string validate = " ";

            do
            {
                Console.WriteLine("\t\t\t{0}, it's your turn.\n\nTo throw the dices enter 'Y'", p.Name);
                validate = Console.ReadLine().ToUpper();
            } while (validate != "Y");

            Result resdice = dice.DiceRoll();

            diceroll = resdice.resd;

            if (resdice.dual)
            {
                p.Dble += 1;
                if (MadeDouble(p, diceroll, p.Dble))
                {                    
                    p.Position = 10;
                }
                else
                {
                    turn -= 1;
                    p.Position += diceroll;
                }
            }
            else
            {
                Console.WriteLine("\n\nDiceroll = {0}\n\n", diceroll);
                p.Position += diceroll;
            }

            return turn;
        }

        /// <summary>
        /// function that analyzes how many duble in a row a player made an if less than 3, he can play again
        /// </summary>
        /// <param name="p">
        /// the player playing
        /// </param>
        /// <param name="diceroll">
        /// the sum of the dices
        /// </param>
        /// <param name="dble">
        ///the number of double the player made, if the number is 3 he goes to jail
        /// </param> 
        /// <returns>
        /// if the player goes in jail or not
        /// </returns>
        public bool MadeDouble(Player p, int diceroll, int dble)
        {
            Console.WriteLine("\n\nCongrats you made a double {0}.\n", diceroll / 2);
            if (dble == 3)
            {
                Console.WriteLine("\n\nIt's your third double, go immediately to Jail !\n\n");
                p.IsInJail = true;
                p.Sentence = 1;
                p.Dble = 0;
            }
            else if(p.Position+diceroll == 30)
            {
                Console.WriteLine("You are actually on the cell Allez en Prison, position 30. \nGo directly to Jail without going through the start!\n\n ");
                p.IsInJail = true;
                p.Sentence = 1;
                p.Dble = 0;
            }
            else
            {
                Console.WriteLine("Move your pawn and play again.\n\n");
            }

            return p.IsInJail;
        }
    }
}
