using System;
using System.Collections.Generic;

namespace ProjetMonopoly
{
    public class Menu
    {
        public Menu()
        {           
        }

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

        public void BalancePlot(Player p)
		{
			Console.WriteLine("Detailled Balance of Player '{0}' :\n", p.Name);
			Dictionary<int, int> dbalance = p.DetailledBalance();
			Dictionary<int, int>.KeyCollection keycoll = dbalance.Keys;
			foreach (int key in keycoll)
			{
				Console.WriteLine("{0} bill(s) of {1} euros\n", dbalance[key], key);
			}
		}

        public bool MadeDouble(Player p,int diceroll,int dble)
		{
			Console.WriteLine("\n\nCongrats you made a double {0}.\nMove your pawn and play again", diceroll / 2);
			if (dble == 3)
			{
				Console.WriteLine("\n\nIt's your third double, go immediately to Jail");
				p.IsInJail = true;
			}

			return p.IsInJail;
		}

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

        public void StartGame()
		{
			Board board = Board.getInstance();
			Player[] list_players = NbOfPlayers();
			Console.WriteLine("The pawns are :");
            foreach(Player p in list_players)
			{
				Console.WriteLine(p.Name);
			}
			int tour = 0;
			bool endgame = false;
			int dble = 0;
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
					string validate = " ";
					Player p = list_players[i];
					do
					{
						Console.WriteLine("\n{0}, it's your turn.\nTo throw the dices enter 'Y'", p.Name);
						validate = Console.ReadLine().ToUpper();
					} while (validate != "Y");

					Dice dice = new Dice();

					int diceroll = 0;

					List<Object> resdice = dice.DiceRoll();

					diceroll = (int)resdice[0];

					dice.Dual = (bool)resdice[1];

					if (dice.Dual)
					{
						dble += 1;
						if (MadeDouble(p,diceroll, dble))
						{
							p.Position = 10;
						}
						else
						{
							i -= 1;
							p.Position += diceroll;
						}
					}
					else
					{
						Console.WriteLine("\n\nDiceroll = {0}\n\n", diceroll);
						p.Position += diceroll;
					}

					Cell currentcell = (Cell) board.CellList[p.Position];

					if (currentcell.Type.Equals("Taxe"))
					{
						p.Balance -= currentcell.Buyingprice;
					}

                    if(currentcell.Type.Equals("Prison"))
					{
						p.Position = 10;
						p.IsInJail = true;
					}

					if (p.Position > 39)
					{
						p.Position -= 40;
						p.Balance += 200;
					}

					Console.WriteLine(currentcell);
                    if (p.Position == 10)
                    {
                        if(p.IsInJail == true)
                        {
                            Console.WriteLine("You are in jail !");
                        }
                        else
                        {
                            Console.WriteLine("Lucky you, you are on a simple visit !");
                        }
                    }
					
				}
				list_players[0].Balance = 0;
				Player winner = Winner(list_players);

				if (winner != null)
				{
					Console.WriteLine("\n********************************************************************************");
					Console.WriteLine("********************************************************************************");
					Console.WriteLine("\t\t\t\tGame Over \n\t\t\t\tThe player {0} won !",winner.Name);
					Console.WriteLine("********************************************************************************");
					Console.WriteLine("********************************************************************************");
					endgame = true;
				}
			}
		}
	}
}
