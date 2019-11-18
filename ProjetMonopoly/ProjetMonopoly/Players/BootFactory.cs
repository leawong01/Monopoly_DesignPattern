using System;
using System.Collections.Generic;

namespace ProjetMonopoly
{
    public class BootFactory:PlayerFactory
    {
        private Dictionary<int, int> _bank;
        private int _position;
        private List<Cards> _cards;

        public BootFactory()
        {
            _bank = BankStart();
            _position = 0;
            _cards = new List<Cards>();
        }

        public override Player GetPlayer()
        {
            return new Boot(_bank, _position, _cards);
        }
    }
}
