using System;
namespace ProjetMonopoly
{
    public class RegularRollDice: DiceRollStrategy
    {
        public int DisplayDiceRoll(Dice dice, Player p, int turn)
        {
            int diceroll = 0;
            string validate = " ";

            do
            {
                Console.WriteLine("\n{0}, it's your turn.\nTo throw the dices enter 'Y'", p.Name);
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

        public bool MadeDouble(Player p, int diceroll, int dble)
        {
            Console.WriteLine("\n\nCongrats you made a double {0}.", diceroll / 2);
            if (dble == 3)
            {
                Console.WriteLine("\n\nIt's your third double, go immediately to Jail !");
                p.IsInJail = true;
                p.Sentence = 1;
                p.Dble = 0;
            }
            else if(p.Position+diceroll == 30)
            {
                Console.WriteLine("You are actually on the cell Allez en Prison, position 30. \nGo directly to Jail without going through the start! ");
                p.IsInJail = true;
                p.Sentence = 1;
                p.Dble = 0;
            }
            else
            {
                Console.WriteLine("Move your pawn and play again.");
            }

            return p.IsInJail;
        }
    }
}
