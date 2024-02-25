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

        // Method to check if a player collects a gem at their current position
        public void CollectGem(Player player)
        {
            // Get the current coordinates of the player
            int x = player.Position.X;
            int y = player.Position.Y;

            // Check if the current cell contains a gem
            if (grid[y, x].Occupant == "G")
            {
                // Increment the player's gem count and set the cell to an empty space
                player.GemCount += 1;
                grid[y, x].Occupant = "-";
            }
        }
    }



    // Represents the main game logic and flow in the "Gem Hunters" game
    class Game
    {
        // Private fields to store the game board, players, current turn, and total turns
        private Board board;
        private Player player1;
        private Player player2;
        private Player currentTurn;
        private int totalTurns;

        // Constructor to initialize the game with a board and two players
        public Game()
        {
            // Create a new game board
            board = new Board();

            // Create Player 1 with the name "P1" and starting position at (0, 0)
            player1 = new Player("P1", new Position(0, 0));

            // Create Player 2 with the name "P2" and starting position at (5, 5)
            player2 = new Player("P2", new Position(5, 5));

            // Set the current turn to Player 1 at the beginning
            currentTurn = player1;

            // Initialize the total turns to 0
            totalTurns = 0;
        }

        // Method to start the game loop
        public void Start()
        {
            // Continue the game loop until the game is over
            while (!IsGameOver())
            {
                // Display the current state of the board
                board.Display();

                // Print information about the current turn
                Console.WriteLine($"\n{currentTurn.Name}'s turn. Total turns: {totalTurns + 1}");

                // Prompt the player for a move direction
                Console.Write("Enter direction (U/D/L/R): ");

                // Read the key pressed by the player and convert it to upper case
                char direction = char.ToUpper(Console.ReadKey().KeyChar);

                // Check if the entered move is valid
                if (board.IsValidMove(currentTurn, direction))
                {
                    // Move the current player and collect any gem at the new position
                    currentTurn.Move(direction);
                    board.CollectGem(currentTurn);

                    // Increment the total turns and switch to the next player's turn
                    totalTurns += 1;
                    SwitchTurn();
                }
                else
                {
                    // Inform the player about an invalid move
                    Console.WriteLine("\nInvalid move. Try again.");
                }
            }

            // Announce the winner or a tie at the end of the game
            AnnounceWinner();
        }

        // Private method to switch turns between Player 1 and Player 2
        private void SwitchTurn()
        {
            // Check the current turn and switch to the other player
            if (currentTurn == player1)
                currentTurn = player2;
            else
                currentTurn = player1;
        }

        // Private method to check if the game has reached its end condition
        private bool IsGameOver()
        {
            // Return true if the total turns reach 30 (15 turns for each player)
            return totalTurns == 30;
        }

        // Private method to announce the winner or a tie at the end of the game
        private void AnnounceWinner()
        {
            // Display game over message
            Console.WriteLine("\nGame over!");

            // Display the number of gems collected by each player
            Console.WriteLine($"{player1.Name} collected {player1.GemCount} gems.");
            Console.WriteLine($"{player2.Name} collected {player2.GemCount} gems.");

            // Determine and display the winner or announce a tie
            if (player1.GemCount > player2.GemCount)
                Console.WriteLine($"{player1.Name} wins!");
            else if (player1.GemCount < player2.GemCount)
                Console.WriteLine($"{player2.Name} wins!");
            else
                Console.WriteLine("It's a tie!");
        }
    }



















}
