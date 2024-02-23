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
        // Property declaration for X (RowPosition)
        public int X { get; set; }

        // Property declaration for Y (ColumnPosition)
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



    // This class represents a player in the game
    class Player
    {
        // Property for the player's name, with read-only
        public string Name { get; }

        // Property for the player's position on the game board
        public Position Position { get; set; }

        // Property for the count of gems collected by the player
        public int GemCount { get; set; }

        // Constructor to initialize a player with a name and starting position
        public Player(string name, Position startPosition)
        {
            // Set the player's name using the provided value
            Name = name;

            // Set the player's position using the provided starting position
            Position = startPosition;

            // Initialize the count of gems collected by the player to 0
            GemCount = 0;
        }


    }


























}
