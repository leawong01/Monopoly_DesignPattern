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
        private List<Cards> _cards;

        public Player(string name, Dictionary<int, int> balance,int position, List<Cards> cards)
        {
            this._name = name;
            this._balance = balance;
            this._position = position;
            this._cards = cards;
        }

        public string Name { get; }
        public Dictionary<int,int> Balance { get; set; }
        public int Position { get; set; }
        public List<Cards> Cards { get; set; }

    }
}
