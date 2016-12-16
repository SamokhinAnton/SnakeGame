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
            Console.OutputEncoding = Encoding.Unicode;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight + 10);
            Console.CursorVisible = false;
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

        public void Statistic(int speed, int score)
        {
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Score = {0}", score);
            Console.SetCursorPosition(40, Console.WindowHeight - 4);
            Console.Write("Speed lvl = {0}", (100 - speed)/5);
        }
    }
}
