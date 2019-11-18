using System;
using System.Collections.Generic;

namespace ProjetMonopoly
{
    public class Boat:Player
    {
        private string _pawn;
        private Dictionary<int, int> _bank;
        private int _position;
        private List<Cards> _cards;

        public Boat(Dictionary<int, int> bank, int position, List<Cards> cards)
        {
            _pawn = "Boat";
            _bank = bank;
            _position = position;
            _cards = cards;
        }


        public override string Pawn
        {
            get { return _pawn; }
        }

        public override Dictionary<int, int> Bank
        {
            get { return _bank; }
            set { _bank = value; }
        }

        public override int Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public override List<Cards> Cards
        {
            get { return _cards; }
            set { _cards = value; }
        }
    }
}
