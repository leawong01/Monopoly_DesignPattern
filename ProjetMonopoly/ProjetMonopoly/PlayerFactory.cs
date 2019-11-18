using System;
using System.Collections.Generic;

namespace ProjetMonopoly
{
    public abstract class PlayerFactory
    {
        public abstract Player GetPlayer();

        public Dictionary<int,int> BankStart()
        {
            Dictionary<int, int> bills = new Dictionary<int, int>();
            bills.Add(500, 2);
            bills.Add(100, 4);
            bills.Add(50, 1);
            bills.Add(20, 1);
            bills.Add(10, 2);
            bills.Add(5, 1);
            bills.Add(1, 5);
            return bills;
        }
    }
}
