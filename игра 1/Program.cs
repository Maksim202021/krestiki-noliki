using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3]; // игровое поле
        static char currentPlayer = 'X'; // текущий игрок

        static void Main(string[] args)
        {
            InitializeBoard(); // инициализация игрового поля

            while (true)
            {
                Console.Clear(); // очистка консоли
                DrawBoard(); // отрисовка игрового поля

                Console.WriteLine($"Ход игрока {currentPlayer}:");
                Console.Write("Введите номер строки: ");
                int row = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Введите номер столбца: ");
                int col = int.Parse(Console.ReadLine()) - 1;

                if (board[row, col] == ' ') // если ячейка свободна
                {
                    board[row, col] = currentPlayer; // ставим метку игрока
                    if (CheckWin()) // проверяем на победу
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine($"Игрок {currentPlayer} победил!");
                        break;
                    }
                    else if (CheckDraw()) // проверяем на ничью
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("Ничья!");
                        break;
                    }
                    else // меняем игрока
                    {
                        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                    }
                }
                else // если ячейка занята
                {
                    Console.WriteLine("Эта ячейка уже занята! Попробуйте еще раз.");
                    Console.ReadKey();
                }
            }

            Console.ReadKey();
        }

        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        static void DrawBoard()
        {
            Console.WriteLine("  1 2 3");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i + 1} ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{board[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static bool CheckWin()
        {
            // проверяем по горизонтали
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                {
                    return true;
                }
            }

            // проверяем по вертикали
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                {
                    return true;
                }
            }

            // проверяем по диагонали
            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            {
                return true;
            }
            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            {
                return true;
            }

            return false;
        }

        static bool CheckDraw()
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