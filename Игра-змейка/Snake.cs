using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Threading;
using static Игра_змейка.Snake;

namespace Игра_змейка
{
    internal class Snake : Level
    {
        public Snake() : base()
        {
            NewElementOfSneke(0, coordX / 2, 5);
            NewElementOfSneke(1, coordX / 2, 4);
        }

        #region перегрузки NewElementOfSneke
        private void NewElementOfSneke(int myKey, int x, int y)
        {
            snake.Add(myKey, new int[] { x, y });
            NumberOfFreeFields -= 1;
        }
        private void NewElementOfSneke()
        {
            int i = snake.Keys.Last();
            int[] z = snake[i];
            int myKey = i + 1;

            snake.Add(myKey, new int[] { z[0], z[1] });

            NumberOfFreeFields -= 1;
        }
        #endregion

        protected void Go()
        {
            do
            {
                int[] z = CopiSnake(0);
                MovingSnakesHeadToCage(ref z);
                CheckliveAndApple(z);

                PrintBlank();

                MovingSnakeToCage(z);

                if (live) PrintSnake();

                Sleep(speed);

            } while (live);
        }

        #region методы Go
        private void MovingSnakesHeadToCage(ref int[] z)
        {
            switch (Direction)
            {
                case "up": z[0] = z[0] - 1; break;
                case "left": z[1] = z[1] - 1; break;
                case "down": z[0] = z[0] + 1; break;
                case "right": z[1] = z[1] + 1; break;
            }
        }
        private void MovingSnakeToCage(int[] z)
        {
            int[] n;

            for (int i = 0; i < snake.Count; i++)
            {
                n = CopiSnake(i);

                snake[i] = z;

                z = n;
            }
        }

        /// <summary>
        /// Если игра закончена возвращает false
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        private void CheckliveAndApple(int[] z)
        {
            if (z[0] == apple[0] && z[1] == apple[1])
            {
                NewElementOfSneke();
                EATEAPPLE();
            }
            else if (screen[z[0], z[1]] == false || ProverkaBSheke(z))
            {
                GEMEOVER();
            }
        }
        #endregion


        #region x2 Print()
        protected void PrintSnake()
        {
            foreach (var item in snake)
            {
                int[] x = item.Value;

                Cursor(x[0], x[1]);

                if (item.Key == 0)
                {
                    Write("8");
                }
                else Write("0");
            }
        }
        private void PrintBlank()
        {
            int[] x = snake.Last().Value;

            Cursor(x[0], x[1]);

            Write(" ");
        }
        #endregion

        #region ProverkaBSheke и Proverka2KeyBSheke
        protected bool ProverkaBSheke(int[] proveriemoe)
        {
            bool _bool = false;

            foreach (var item in snake)
            {
                int[] x = item.Value;
                if (proveriemoe[0] == x[0] && proveriemoe[1] == x[1]) _bool = true;
            }

            return _bool;
        }
        protected bool Proverka2KeyBSheke(string Napravlenie)
        {
            bool _bool = true;

            int[] z = CopiSnake(0);
            switch (Napravlenie)
            {
                case "up": z[0] = z[0] - 1; break;
                case "left": z[1] = z[1] - 1; break;
                case "down": z[0] = z[0] + 1; break;
                case "right": z[1] = z[1] + 1; break;
            }
            if (snake[1][0] == z[0] && snake[1][1] == z[1]) _bool = false;

            return _bool;
        }
        #endregion

        private int[] CopiSnake(int i)
        {
            int[] perelogInt = snake[i];
            string[] perelogString = new string[] { Convert.ToString(perelogInt[0]), Convert.ToString(perelogInt[1]) };
            int[] x = { Convert.ToInt32(perelogString[0]), Convert.ToInt32(perelogString[1]) };
            return x;
        }
    }

}
