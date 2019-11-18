using System;
using System.Collections.Generic;

namespace ProjetMonopoly
{
    public class DogFactory:PlayerFactory
    {
        private Dictionary<int, int> _bank;
        private int _position;
        private List<Cards> _cards;

        public DogFactory()
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
