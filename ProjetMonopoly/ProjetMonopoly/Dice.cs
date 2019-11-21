using System;
using System.Collections.Generic;

namespace ProjetMonopoly
{
    public class Dice
    {
		private int resd1;
		private int resd2;
        bool dual;

        public Dice()
        {
            this.resd1 = 0;
            this.resd2 = 0;
            this.dual = false;
        }

        public int Resd1
		{ get; set; }

        public int Resd2
		{ get; set; }

        public bool Dual
        { get; set; }

        /// <summary>
        /// Simulate a dice roll for both dices using Random
        /// If the dices have the same result, dual change in true
        /// </summary>
        /// <returns>
        /// both dual and the final result of the dice roll are stocked in a list
        /// </returns>
        public List<object> DiceRoll()
		{
            List<object> result = new List<object>();
			Random rand = new Random();
			this.resd1 = rand.Next(1, 7);
			this.resd2 = rand.Next(1, 7);
			//resd1 = resd2 = 2;
            if(resd1==resd2)
			{
				this.dual = true;
			}
            result.Add(resd1 + resd2);
            result.Add(dual);
            return result;
		}
    }
}
