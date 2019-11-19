using System;

namespace ProjetMonopoly
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Board board = Board.getInstance();
            for (int i = 0; i < 40; i++)
                {
                Console.WriteLine(board.CellList[i].ToString());
                }

            Console.ReadKey();

        }
    }
}
