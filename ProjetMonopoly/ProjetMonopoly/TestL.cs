using System;
using System.Collections.Generic;

namespace ProjetMonopoly
{
    public class TestL
    {
        public TestL()
        {
        }
        /* 
         Fonction Libération ==> Menu
         Check au debut du tour si en prison
         Si oui paye ou jouer les des pour le 1er tour
         2eme tour ==> Dés
         3eme tour dés puis payer
                     
             */
		public void program()
		{
			Menu menu = new Menu();

			menu.StartGame();


		}
	}
}
