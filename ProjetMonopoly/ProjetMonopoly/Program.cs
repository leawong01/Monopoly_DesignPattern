using System;

namespace ProjetMonopoly
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Menu menu = new Menu();

            menu.StartGame();

            Console.ReadKey();            
        }
    }

    
}
