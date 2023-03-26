using System;

namespace gamenho
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");

            char[,] board = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            char player = 'X';
            bool isGameFinished = false;

            while (!isGameFinished)
            {
                Console.Clear();
                DisplayBoard(board);

                int[] move = GetPlayerMove(player);

                board[move[0], move[1]] = player;

                if (IsWinner(board, player))
                {
                    Console.Clear();
                    DisplayBoard(board);
                    Console.WriteLine("Player " + player + " wins!");
                    isGameFinished = true;
                }
                else if (IsBoardFull(board))
                {
                    Console.Clear();
                    DisplayBoard(board);
                    Console.WriteLine("It's a tie!");
                    isGameFinished = true;
                }

                player = (player == 'X') ? 'O' : 'X';
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void DisplayBoard(char[,] board)
        {
            Console.WriteLine(" " + board[0, 0] + " | " + board[0, 1] + " | " + board[0, 2] + " ");
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + board[1, 0] + " | " + board[1, 1] + " | " + board[1, 2] + " ");
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + board[2, 0] + " | " + board[2, 1] + " | " + board[2, 2] + " ");
        }

        static int[] GetPlayerMove(char player)
        {
            int row = -1;
            int col = -1;

            while (row < 0 || row > 2 || col < 0 || col > 2)
            {
                Console.Write("Player " + player + ", enter your move (row[1-3] column[1-3]): ");
                string[] input = Console.ReadLine().Split(' ');

                if (input.Length != 2)
                {
                    Console.WriteLine("Invalid input. Please enter two numbers separated by a space.");
                    continue;
                }

                if (!int.TryParse(input[0], out row) || !int.TryParse(input[1], out col))
                {
                    Console.WriteLine("Invalid input. Please enter two numbers separated by a space.");
                    row = -1;
                    col = -1;
                    continue;
                }

                row--;
                col--;

                if (row < 0 || row > 2 || col < 0 || col > 2)
                {
                    Console.WriteLine("Invalid input. Row and column must be between 1 and 3.");
                }
            }

            return new int[] { row, col };
        }

        static bool IsWinner(char[,] board, char player)
        {
            if ((board[0, 0] == player && board[0, 1] == player && board[0, 2] == player) ||
                (
                board[1, 0] == player && board[1, 1] == player && board[1, 2] == player) ||
                (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player) ||
                (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player) ||
                (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player) ||
                (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player) ||
                (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
                (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
            {
                return true;
              }
            return false;
        }
        static bool IsBoardFull(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
        }

