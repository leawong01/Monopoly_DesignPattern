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
        private int sentence;
        private int dble;

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
            this.sentence = 0;
            this.dble = 0;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public int Balance { get { return _balance; } set { _balance = value; } }
        public int Position { get { return _position; } set { _position = value; } }
        public List<Cell> Properties { get { return _properties; } set { _properties = value; } }
        public bool IsInJail { get { return isInJail; } set { isInJail = value; } }
        public int Sentence { get { return sentence; } set { sentence = value; } }
        public int Dble { get { return dble; } set { dble = value; } }

        public override string ToString()
        {
            string result=  string.Format("Joueur '{0}', actuellement en position {1}.\nVous possedez {2} euros \n",Name,Position,Balance);
            return result;
        }

        

    }
}
