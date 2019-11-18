﻿using System;
namespace ProjetMonopoly
{
    public class Dice
    {
		int resd1;
		int resd2;
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

        public int DiceRoll()
		{
			Random rand = new Random();
			this.resd1 = rand.Next(1, 7);
			this.resd2 = rand.Next(1, 7);
            if(resd1==resd2)
			{
				dual = true;
			}
			return resd1 + resd2;
		}
    }
}