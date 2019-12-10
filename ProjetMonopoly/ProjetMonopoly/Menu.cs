using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjetMonopoly
{
    public class Menu
    {
        /* Constructor */
        public Menu()
        {           
        }

        /// <summary>
        /// Method to declare the right way to display the diceroll of the Strategy Pattern
        /// </summary>
        /// <param name="strategy">
        /// We declare JailRollDice if the player is currently in jail and RegularRollDice other way
        /// </param>
        /// <param name="dice"></param>
        /// <param name="p"></param>
        /// <param name="i">
        /// The current turn of the player or the turns left in jail
        /// </param>
        /// <returns></returns>
        /// 
        public int DiceRoll(DiceRollStrategy strategy, Dice dice, Player p, int i)
        {
            return strategy.DisplayDiceRoll(dice, p, i);
        }

        /// <summary>
        /// Method that ask the user the number of player and create them with their pawn using the playerfactory
        /// </summary>
        /// <returns></returns>
		public Player[] NbOfPlayers()
		{
			int nb_player = 0;
			do
			{
				Console.WriteLine("How many players are there for this game ? (Min 2 and Max 8) ");
				nb_player = int.Parse(Console.ReadLine());
                if (nb_player < 2 || nb_player > 8)
				{
					Console.WriteLine("Number of players invalid");
				}
			} while (nb_player < 2 || nb_player > 8);
			Player[] list_players = new Player[nb_player];
			PlayerFactory factory = new PlayerFactory();
			Random random = new Random();
			int[] randompawns = new int[nb_player];
			for (int i = 1; i <= list_players.Length; i++) 
			{
				int pawn = random.Next(1, 9);
				while(Array.Exists(randompawns,elt => elt == pawn))
				{
					pawn = random.Next(1, 9);
				}
				randompawns[i-1] = pawn;
				list_players[i - 1] = factory.GetPlayer(pawn);
            }
			return list_players;
		}

        /// <summary>
        /// Method that allows the player to make his choices durint his sentence in jail
        /// </summary>
        /// <param name="p"></param>
        /// <param name="dice"></param>
        public void JailTurn(Player p,Dice dice)
        {
            Console.WriteLine("\n{0}, it's your turn.\n", p.Name);
            int choice = 0;
            int turnleft = 2;
            if (p.Sentence == 1)
            {
                Console.WriteLine("It's your first turn in jail, you can pay 50euros or make a double to go out.");
                Console.WriteLine("You currently have {0}euros on your account", p.Balance);
                do
                {
                    Console.WriteLine("Press 1 to pay 50 euros \nPress 2 to roll the dices");
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Debug.WriteLine("Exception Message: " + ex.Message);
                    }
                    if (choice < 1 || choice > 2)
                    {
                        Console.WriteLine("Invalid choice please do it again.");
                    }
                } while (choice < 1 || choice > 2);
                if (choice == 1)
                {
                    if (p.Balance >= 50)
                    {
                        Console.WriteLine("You just paid 50euros,");
                        Console.WriteLine("you now have {0} euros, you can roll the dices and go out of jail !", p.Balance);
                        p.Balance -= 50;
                        p.IsInJail = false;
                        turnleft = DiceRoll(new JailRollDice(),dice, p, 1);                        
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you don't have enough money, try to make a double");
                        turnleft = DiceRoll(new JailRollDice(), dice, p, 2);
                    }
                }
                else
                {
                    Console.WriteLine("May the luck be with you ! \nRoll the dices");
                    turnleft = DiceRoll(new JailRollDice(), dice, p, 2);
                }
            }
            else if (p.Sentence == 2)
            {
                Console.WriteLine("May the luck be with you ! \nRoll the dices");
                turnleft = DiceRoll(new JailRollDice(), dice, p, 2);
            }
            else if (p.Sentence == 3)
            {
                Console.WriteLine("It's your third turn in Jail, pay 50euros, roll the dices and move your pawn !");
                turnleft = DiceRoll(new JailRollDice(), dice, p, 2);
            }

            if(turnleft != 0)
            {
                Console.WriteLine("You have {0} left turns in Jail.\nHang on ! ", turnleft);
            }
        }

        /// <summary>
        /// Method that determines if there is a winner 
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public Player Winner(Player[] players)
		{
			Player winner = null;
			int pos = 0;
			int losers = 0;
			for (int i = 0; i < players.Length; i++)
			{
                if(players[i].Balance<=0)
				{
					losers+=1;
				}
                else
				{
					pos = i;
				}
			}
			if (losers == players.Length - 1)
			{
				winner = players[pos];
			}

			return winner;
		}

        /// <summary>
        /// Display the cell on which the player is according to the type of the cell
        /// </summary>
        /// <param name="board"></param>
        /// <param name="p"></param>
        public void DisplayCell(Board board,Player p)
        {
            if (p.Position > 39)
            {
                p.Position -= 40;
                p.Balance += 200;
            }

            Cell currentcell = (Cell)board.CellList[p.Position];

            if (currentcell.Type.Equals("Taxe"))
            {
                p.Balance -= currentcell.Cost;
                Console.WriteLine("You now have {0} euros ",p.Balance);
            }

            if (currentcell.Type.Equals("Prison"))
            {
                Console.WriteLine((Cell)board.CellList[30]);
                p.Position = 10;
                p.IsInJail = true;
                p.Sentence = 1;
            }            

            Console.WriteLine(currentcell);

            if (p.Position == 10)
            {
                if (p.IsInJail == true)
                {
                    Console.WriteLine("You are in jail !");
                }
                else
                {
                    Console.WriteLine("Lucky you, you are on a simple visit !");
                }
            }
        }

        /// <summary>
        /// Course of the game using other method and covering all cases
        /// </summary>
        public void StartGame()
		{
			Board board = Board.getInstance();
			Player[] list_players = NbOfPlayers();
			Console.WriteLine("The pawns are :");
            Dice dice = new Dice();
            foreach(Player p in list_players)
			{
				Console.WriteLine(p.Name);
			}
			int tour = 0;
			bool endgame = false;
			Console.WriteLine("\n********************************************************************************");
			Console.WriteLine("********************************************************************************");
			Console.WriteLine("\t\t\t\tGame Start !");
			Console.WriteLine("********************************************************************************");
			Console.WriteLine("********************************************************************************");
			while (!endgame)
			{
				tour += 1;
				Console.WriteLine("\nTour n.{0}", tour);
				for (int i = 0; i < list_players.Length; i++)
				{
                    if (i > 0)
                    {
                        list_players[i - 1].Dble = 0;
                    }
                    else if (i == 0)
                    {
                        list_players[list_players.Length-1].Dble = 0;
                    }
                    Player p = list_players[i];                    
                    if (p.IsInJail == false)
                    {

                        i = DiceRoll(new RegularRollDice(), dice, p, i);
                        
                    }
                    else
                    {
                        JailTurn(p, dice);
                    }


                    DisplayCell(board,p);
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("--------------------------------------------------------------------------------");
                }

				Player winner = Winner(list_players);

				if (winner != null)
				{
					Console.WriteLine("\n********************************************************************************");
					Console.WriteLine("********************************************************************************");
                    Console.WriteLine("\t\t\t\tGame Over \n\t\t\t   The player {0} won !", winner.Name);
					Console.WriteLine("********************************************************************************");
					Console.WriteLine("********************************************************************************");
					endgame = true;
				}
			}
		}
	}
}
