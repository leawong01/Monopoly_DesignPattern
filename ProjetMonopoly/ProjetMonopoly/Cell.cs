using System;

namespace ProjetMonopoly
{
    public class Cell
    {
        int position;
        string name;
        string type;//Color or type
        int buyingprice;
        int cost;
        /* int Nbhouse;*/

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
        public override string ToString()
        {
            string result = string.Format("Vous etes actuellement sur la case {0} en position {1}, cette case est une case {2}, elle coute {3} à l'achat et le loyer est de {4}.", name, position, type, buyingprice, cost);
            return result;

        }
    }
}
