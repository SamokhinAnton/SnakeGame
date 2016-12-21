using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class Field
    {
        public void GameField()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 1; i < Console.WindowWidth - 5; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("*");
                Console.SetCursorPosition(i, Console.WindowHeight - 5);
                Console.Write("*");
            }
            for (int i = 0; i <= Console.WindowHeight - 5; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("*");
                Console.SetCursorPosition(Console.WindowWidth - 5, i);
                Console.Write("*");
            }
        }

        public void Statistic(int speed, int score, int lives)
        {
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Score = {0}", score);
            Console.SetCursorPosition(30, Console.WindowHeight - 4);
            Console.Write("Speed lvl = {0}", (100 - speed)/5);
            Console.SetCursorPosition(60, Console.WindowHeight - 4);
            Console.Write("lives = {0}", lives);
        }
    }
}
