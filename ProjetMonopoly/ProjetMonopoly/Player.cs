using System;
using System.Collections.Generic;


namespace ProjetMonopoly
{
    enum Pawns { Barrow = 1, Boat, Boot, Car, Dog, Hat, Iron, Thimble };

    public class Player
    {
        private String _name;
        private int _balance;
        private int _position;
        private List<Cell> _properties;
		private bool isInJail;

        public Player(string name, int balance,int position)
        {
            foreach(char c in name)
            {
                this._name += c;
            }
			this._balance = balance;
            this._position = position;
            this._properties = new List<Cell>();
			this.isInJail = false;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public int Balance { get { return _balance; } set { _balance = value; } }
        public int Position { get { return _position; } set { _position = value; } }
        public List<Cell> Properties { get { return _properties; } set { _properties = value; } }
        public bool IsInJail { get { return isInJail; } set { isInJail = value; } }

        public override string ToString()
        {
            string result=  string.Format("Joueur '{0}', actuellement en position {1}.\nVous possedez {2} euros \n",Name,Position,Balance);
            return result;
        }

        public Dictionary<int,int> DetailledBalance()
		{
			int rest = Balance;
			Dictionary<int, int> detail = new Dictionary<int, int>();
			int[] bills = { 500, 100, 50, 20, 10, 5, 1 };
            for(int i =0;i<bills.Length;i++)
			{
				int temp = rest / bills[i];
				detail[bills[i]] = temp;
				rest -= temp*bills[i]; 
			}

			return detail;
		}

    }
}
