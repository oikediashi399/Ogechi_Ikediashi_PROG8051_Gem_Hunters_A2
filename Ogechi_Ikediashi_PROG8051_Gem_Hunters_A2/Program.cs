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

        // Method to move the player in a specified direction on the game board
        public void Move(char direction)
        {
            // Check the provided direction and adjust the player's position accordingly
            if (direction == 'U')
                Position.Y -= 1;
            else if (direction == 'D')
                Position.Y += 1;
            else if (direction == 'L')
                Position.X -= 1;
            else if (direction == 'R')
                Position.X += 1;
        }
    }



    // This class represents a cell/position/location on the game board
    class Cell
    {
        // Property for the occupant of the cell (player (P1 and P2), gem (G), obstacle (O), or empty(represented as -))
        public string Occupant { get; set; }

        // Constructor to initialize a cell with a default occupant of empty ("-")
        public Cell(string occupant = "-")
        {
            // Set the initial occupant of the cell using the provided value (P1, P2, G, O) or the default "-"
            Occupant = occupant;
        }
    }



    // This class represents the entire game board including cells and it's possible occupants
    class Board
    {
        // Declaring a 2-D array to represent the game board like a table
        private Cell[,] grid;

        // Implementing a Constructor to initialize the board by creating cells and initializing their occupants
        public Board()
        {
            // Initialize the board with 6 rows and 6 columns
            grid = new Cell[6, 6];

            // Calling the method to pick new cell value and set up the initial state of the board
            InitializeBoard();
        }

        // Method to set up the initial state of the board (players, gems, and obstacles)
        private void InitializeBoard()
        {
            // Loop through each row of the board
            for (int i = 0; i < 6; i++)
            {
                // Loop through each column of the board
                for (int j = 0; j < 6; j++)
                {
                    // Setting up the board for a game round
                    // Create a new cell and assign it to the current position in the grid
                    grid[i, j] = new Cell();
                }
            }

            // Initialize players
            grid[0, 5].Occupant = "P1";
            grid[5, 0].Occupant = "P2";

            // Initialize gems
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                int x, y;
                do
                {
                    // Generate random coordinates for gems until an empty cell is found
                    x = random.Next(6);
                    y = random.Next(6);
                } while (grid[y, x].Occupant != "-");

                // Assign a gem to the randomly selected empty cell
                grid[y, x].Occupant = "G";
            }

            // Initialize obstacles
            for (int i = 0; i < 4; i++)
            {
                int x, y;
                do
                {
                    // Generate random coordinates for obstacles until an empty cell is found
                    x = random.Next(6);
                    y = random.Next(6);
                } while (grid[y, x].Occupant != "-");

                // Assign an obstacle to the randomly selected empty cell
                grid[y, x].Occupant = "O";
            }
        }

        // Method to display the current state of the board in the console
        public void Display()
        {
            // Loop through each row of the grid
            for (int i = 0; i < 6; i++)
            {
                // Loop through each column of the grid
                for (int j = 0; j < 6; j++)
                {
                    // Print the occupant of the current cell followed by a space
                    Console.Write(grid[i, j].Occupant + " ");
                }

                // Move to the next line after printing each row
                Console.WriteLine();
            }
        }

        // Method to check if a move is valid for a given player
        public bool IsValidMove(Player player, char direction)
        {
            // Get the current coordinates of the player
            int newX = player.Position.X;
            int newY = player.Position.Y;

            // Update the coordinates based on the provided direction
            if (direction == 'U')
                newY -= 1;
            else if (direction == 'D')
                newY += 1;
            else if (direction == 'L')
                newX -= 1;
            else if (direction == 'R')
                newX += 1;

            // Check if the new coordinates are within the bounds of the grid and the cell is not an obstacle
            if (newX >= 0 && newX < 6 && newY >= 0 && newY < 6 && grid[newY, newX].Occupant != "O")
                return true;

            // Return false if the move is not valid
            return false;
        }

        
    }






















}
