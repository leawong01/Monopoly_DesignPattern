using System;
namespace ProjetMonopoly
{
    public class JailRollDice : DiceRollStrategy
    {
        /// <summary>
        /// Implementation of Strategy Pattern
        /// Method to display the result of the diceroll if the player is in jail
        /// </summary>
        /// <param name="dice">
        /// Avoid creating a new dice each turn
        /// </param>
        /// <param name="p">
        /// The current player
        /// </param>
        /// <param name="choice">
        ///  1 is if the player choose to pay on turn 1 so he directly goes out
        ///  2 is if the player can't pay or if he wants to trying making a double
        /// </param>
        /// <returns>
        /// Returns the number of turns left in jail
        /// </returns>
        public int DisplayDiceRoll(Dice dice,Player p, int choice)
        {
            int diceroll = 0;
            int turnleft = 3;
            string validate = " ";
            do
            {
                Console.WriteLine("To throw the dices enter 'Y'");
                validate = Console.ReadLine().ToUpper();
            } while (validate != "Y");

            Result resdice = dice.DiceRoll();
            diceroll = resdice.resd;

            if (choice == 1)
            {
                Console.WriteLine("\n\nDiceroll = {0}\n\n", diceroll);
                p.Position += diceroll;
                turnleft = 0;
            }
            else if (choice == 2)
            {
                if (resdice.dual)
                {
                    Console.WriteLine("Congratulations, you just made a double {0}, you can move your pawn and go out of jail !", resdice.resd / 2);
                    p.IsInJail = false;
                    p.Position += diceroll;
                    turnleft = 0;
                }
                else
                {
                    Console.WriteLine("\n\nDiceroll = {0}\n\n", diceroll);
                    Console.WriteLine("Too bad, stay in jail and try again next turn");
                    p.Sentence += 1;
                    turnleft -= 1;
                }
            }

            return turnleft;
        }
    }
}
