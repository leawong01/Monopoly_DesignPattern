using System;

namespace ProjetMonopoly
{
    public class Cell
    {
        /* Instance variables */

        int position;
        string name;
        string type;//Color or type
        int buyingprice;
        int cost;
        int Nbhouse;
        int Owner;

        //Constructor
        public Cell(int position, string name, string type, int buyingprice, int cost)
        {
            this.position = position;
            this.name = name;
            this.type = type;
            this.buyingprice = buyingprice;
            this.cost = cost;            
        }

        //Properties
        public int Cost { get => cost; set => cost = value; }
        public int Buyingprice { get => buyingprice; set => buyingprice = value; }
        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public int Position { get => position; set => position = value; }

        //Methods
        /// <summary>
        /// Method that describe a cell with its instance variables
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
			string result = null;

            if(type.Equals("Communaute")|| type.Equals("Chance"))
			{
                result= string.Format("You are actually on the cell {0}, position {1}. \nPick a card ! ",name, position);
			}

            else if(type.Equals("Taxe"))
			{
				result = string.Format("You are actually on the cell {0}, position {1}.\nPay {2}euros to the bank ! ", name, position,cost);
			}

            else if(type.Equals("Parc"))
			{
				result = string.Format("You are actually on the cell {0}, position {1}.\nRelax !", name, position);
			}

            else if(type.Equals("Prison"))
			{
				result = string.Format("You are actually on the cell {0}, position {1}. \nGo directly to Jail without going through the start! ", name, position);
			}
            else if(type.Equals("Depart"))
			{
				result = string.Format("You are actually on the Start cell.\nReceive 200euros !");
			}
            else if (type.Equals("Visite"))
            {
                result = string.Format("You are on the cell Jail, position 10.");
            }
			else
			{
				result = string.Format("You are actually on the cell {0}, position {1}, this cell belongs to the group {2}." +
				"\nIt costs {3}euros to buy it and the rent is {4}euros.", name, position, type, buyingprice, cost);
			}
				
            return result;

        }
    }
}
