using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogechi_Ikediashi_PROG8051_Gem_Hunters_A2
{
    internal class Program
    {
        static void Main()
        {
            // Project Initiallization
            // Nothing here yet, still building the game

        }
    }




    // This class represents a position on the game board with X and Y as Rows(Horizontal) and Columns(Vertical) respectively like in a table
    class Position
    {
        // Public property declaration for X (RowPosition)
        public int X { get; set; }

        // Public property declaration for Y (ColumnPosition)
        public int Y { get; set; }

        // A constructor to initialize a Position, specifying X and Y
        public Position(int x, int y)
        {
            // Setting the X to the provided parameter x (its passed value)
            X = x;

            // Setting the Y to the provided parameter y (its passed value)
            Y = y;
        }
    }












}
