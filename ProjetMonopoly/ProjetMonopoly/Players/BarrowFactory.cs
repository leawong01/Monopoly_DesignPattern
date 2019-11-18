using System;
using System.Collections.Generic;

namespace ProjetMonopoly.Players
{
    public class BarrowFactory:PlayerFactory
    {
        private Dictionary<int, int> _bank;
        private int _position;
        private List<Cards> _cards;

        public BarrowFactory()
        {
            _bank = BankStart();
            _position = 0;
            _cards = new List<Cards>();
        }

        public override Player GetPlayer()
        {
            return new Dog(_bank, _position, _cards);
        }
    }
}
