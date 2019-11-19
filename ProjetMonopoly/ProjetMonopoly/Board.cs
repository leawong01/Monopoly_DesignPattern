using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMonopoly
{
    public class Board
    {
        /**Variables d'instance*/
        Cell[] CellList = new Cell[40];


        /** Constructeur privé */
        private Board()
        {
            BoardFilling();
        }

        /** Instance unique non préinitialisée */
        private static Board board = null;

        /** Point d'accès pour l'instance unique du singleton */
        public static Board getInstance()
        {
            if (board == null)
            {
                board = new Board();
            }
            return board;
        }
        public void BoardFilling()
        {
            string[] lines = System.IO.File.ReadAllLines("./Monopoly_cells");
            foreach (string line in lines)
            {
                string[] ligne = line.Split(',');
                Cell case1 = new Cell(Convert.ToInt32(ligne[1]), ligne[0], ligne[2], 0, 0);
                CellList.Append(case1);
            }


            //Creation des cases une par une
        }
    }
}
