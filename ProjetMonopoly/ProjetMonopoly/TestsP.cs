using System;
namespace ProjetMonopoly
{
    public class TestsP
    {
        public TestsP()
        {
        }

        public void program()
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
