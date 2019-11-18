using System;
using System.Collections.Generic;

namespace ProjetMonopoly.Properties
{
    public class HatFactory:PlayerFactory
    {
        private Dictionary<int, int> _bank;
        private int _position;
        private List<Cards> _cards;

        public HatFactory()
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
