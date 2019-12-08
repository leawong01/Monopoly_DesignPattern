using System;
using System.Collections.Generic;

namespace ProjetMonopoly
{
    public struct Result
    {
        public int resd;
        public bool dual;
    }

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
        /// Declaration of 2 Random variables because the chance of making a double with one is too high
        /// </summary>
        /// <returns>
        /// both dual and the final result of the dice roll are returned through the structure Result
        /// </returns>
        /// 
        public Result DiceRoll()
		{
            this.dual =false;
            Result result = new Result();
			Random rand = new Random();
			this.resd1 = rand.Next(1, 7);
            Random rand2 = new Random();
            this.resd2 = rand2.Next(1, 7);
			//this.resd1 = this.resd2 = 15;
            if(this.resd1==this.resd2)
			{
				this.dual = true;
			}
            result.resd = (this.resd1 + this.resd2);
            result.dual = this.dual;
            return result;
		}
    }
}
