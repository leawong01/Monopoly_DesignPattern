using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMonopoly
{
    public class Board
    {
        /* Instance variables */
        public ArrayList CellList = new ArrayList();


        /* Private constructor */
        private Board()
        {
            BoardFilling();
        }

        /** Single Instance not pre-initialized */
        private static Board board = null;

        /// <summary>
        /// Static operation that returns the sole instance of the class // Access point for the single instance of the singleton
        /// </summary>
        /// <returns></returns>
        public static Board getInstance()
        {
            if (board == null)
            {
                board = new Board();
            }
            return board;
        }
        /// <summary>
        /// Method that read the file Monopoly_cells.txt and create all the cells and thus the board
        /// </summary>
        public void BoardFilling()
        {
            string[] lines = System.IO.File.ReadAllLines("../../Monopoly_cells.txt");
            foreach (string line in lines)
            {
                string[] ligne = line.Split(',');
                Cell case1 = new Cell(Convert.ToInt32(ligne[1]), ligne[0], ligne[2], Convert.ToInt32(ligne[3]), Convert.ToInt32(ligne[4]));
                CellList.Add(case1);
            }
        }
    }
}
