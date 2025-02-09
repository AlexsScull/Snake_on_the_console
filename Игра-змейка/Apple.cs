using System;

namespace Игра_змейка
{
    internal class Apple : Snake
    {
        public Apple() : base()
        {
            IncreaseApple(coordX / 2, 10);

            ActionEATEAPPLE += () => EatApple();
        }

        #region перегрузки IncreaseApple
        private void IncreaseApple(int x, int y)
        {
            apple[0] = x; apple[1] = y;
        }
        private void IncreaseApple(int[] z)
        {
            apple[0] = z[0]; apple[1] = z[1];
        }
        #endregion

        protected void EatApple()
        {
            IncreaseApple(RandomXY(1));
            if (live)
            {
                PrintApple();
            }
        }
        #region методы EatApple
        private int[] RandomXY(int i)
        {
            int[] r = { Random(i, coordX - 1), Random(i, coordY - 1) };

            if (ProverkaRandomXY(r)) { r = RandomXY(i + 1); }

            return r;
        }
        private int Random(int i, int xy)
        {
            int x = Convert.ToInt32(DateTime.Now.Second) + i;
            Random r = new Random(x);
            return r.Next(1, xy);
        }

        /// <summary>
        /// Проверяет, попадает ли яблоко на змею, если да, возвращает true
        /// </summary>
        /// <param name="x"></param>
        private bool ProverkaRandomXY(int[] x)
        {
            bool b = ProverkaBSheke(x);

            return b;

        }
        #endregion

        protected void PrintApple()
        {
            Cursor(apple[0], apple[1]);
            Write("@");
        }

    }
}
