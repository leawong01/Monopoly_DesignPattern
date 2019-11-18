using System;
using System.Collections.Generic;

namespace ProjetMonopoly
{
    public abstract class Player
    {
        public abstract string Pawn { get; }
        public abstract Dictionary<int,int> Bank { get; set; }
        public abstract int Position { get; set; }
        public abstract List<Cards> Cards { get; set; }

       

        public Dictionary<int,int> BankStart()
        {
            this.bills.Add(500, 2);
            this.bills.Add(100, 4);
            this.bills.Add(50, 1);
            this.bills.Add(20, 1);
            this.bills.Add(10, 2);
            this.bills.Add(5, 1);
            this.bills.Add(1, 5);
            return bills;
        }
    }
}
