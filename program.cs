using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = new char[9];
        static char player = 'X';

        static void Main(string[] args)
        {
            PrintInstructions();
            InitializeBoard();
            PrintBoard();

            while (true)
            {
                GetPlayerInput();
                Console.Clear();
                PrintBoard();

                if (IsGameOver())
                {
                    Console.WriteLine("Game over! Player " + player + " wins.");
                    RestartGame();
                }

                SwitchPlayer();

            }
        }

        static void InitializeBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = (i + 1).ToString()[0];
            }
        }

        static void PrintBoard()
        {
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
        }

        static void GetPlayerInput()
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Player " + player + ", enter a number between 1 and 9 to place your mark:");
                string input = Console.ReadLine();
                int move;
                if (int.TryParse(input, out move) && move >= 1 && move <= 9 && !char.IsLetter(board[move - 1]))
                {
                    board[move - 1] = player;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }

            Console.WriteLine();
        }

        static bool IsGameOver()
        {
            // check rows
            if (board[0] == player && board[1] == player && board[2] == player) return true;
            if (board[3] == player && board[4] == player && board[5] == player) return true;
            if (board[6] == player && board[7] == player && board[8] == player) return true;

            // check columns
            if (board[0] == player && board[3] == player && board[6] == player) return true;
            if (board[1] == player && board[4] == player && board[7] == player) return true;
            if (board[2] == player && board[5] == player && board[8] == player) return true;

            // check diagonals
            if (board[0] == player && board[4] == player && board[8] == player) return true;
            if (board[2] == player && board[4] == player && board[6] == player) return true;

            return false;
        }

        static void SwitchPlayer()
        {
            if (player == 'X')
            {
                player = 'O';
            }
            else
            {
                player = 'X';
            }
        }
        static void RestartGame()
        {
            InitializeBoard();
            PrintBoard();
            player = 'X';
        }
        static void PrintInstructions()
        {
            Console.WriteLine("Tic-Tac-Toe game instructions:");
            Console.WriteLine("- The game is played on a 3x3 board.");
            Console.WriteLine("- Players take turns marking a square with their respective symbol (X or O).");
            Console.WriteLine("- The first player to get three of their symbols in a row (horizontally, vertically, or diagonally) wins the game.");
            Console.WriteLine("- If all squares are filled and no player has won, the game ends in a draw.");
            Console.WriteLine("- To make a move, enter the number of the square where you want to place your mark.");
            Console.WriteLine("- Have fun!\n");
        }
    }
}