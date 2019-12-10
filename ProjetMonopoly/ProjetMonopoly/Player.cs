using System;
using System.Collections.Generic;


namespace ProjetMonopoly
{

    public class Player
    {
        /* Instance variables */
        private string _name;
        private int _balance;
        private int _position;
		private bool isInJail;
        private int sentence;
        private int dble;

        /* Constructor */
        public Player(string name, int balance,int position)
        {
            foreach(char c in name)
            {
                this._name += c;
            }
			this._balance = balance;
            this._position = position;
			this.isInJail = false;
            this.sentence = 0;
            this.dble = 0;
        }

        /* Properties */ 
        public string Name { get { return _name; } set { _name = value; } }
        public int Balance { get { return _balance; } set { _balance = value; } }
        public int Position { get { return _position; } set { _position = value; } }
        public bool IsInJail { get { return isInJail; } set { isInJail = value; } }
        public int Sentence { get { return sentence; } set { sentence = value; } }
        public int Dble { get { return dble; } set { dble = value; } }

        /// <summary>
        /// Method that describe a player with its instance variables
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result=  string.Format("Joueur '{0}', actuellement en position {1}.\nVous possedez {2} euros \n",Name,Position,Balance);
            return result;
        }

        

    }
}
