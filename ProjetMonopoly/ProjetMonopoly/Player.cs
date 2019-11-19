using System;
using System.Collections.Generic;


namespace ProjetMonopoly
{
    enum Pawns { Barrow = 1, Boat, Boot, Car, Dog, Hat, Iron, Thimble };

    public class Player
    {
        private String _name;
        private Dictionary<int, int> _balance;
        private int _position;
        //private List<Cell> _properties;

        public Player(string name, Dictionary<int, int> balance,int position)
        {
            foreach(char c in name)
            {
                this._name += c;
            }
            _balance = new Dictionary<int, int>();
            Dictionary<int, int>.KeyCollection keycoll = balance.Keys;
            foreach(int key in keycoll)
            {
                _balance[key] = balance[key];
            }
            this._position = position;
            //this._cards = new List<Cell>();
        }

        public string Name { get { return _name; } set { _name = value; } }
        public Dictionary<int,int> Balance { get { return _balance; } set { _balance = value; } }
        public int Position { get { return _position; } set { _position = value; } }
        //public List<Cell> Properties { get { return _properties; } set { _properties = value; } }

        public override string ToString()
        {
            string result=  string.Format("Le joueur {0} est en position {1}",Name,Position);
            return result;
        }
    }
}
