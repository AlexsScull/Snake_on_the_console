using System;

namespace Игра_змейка
{
    internal class Screen
    {
        #region Переменные
        protected bool[,] screen; //false - граница;

        #region переменные размеров
        private static readonly int WindowWidth = Console.LargestWindowWidth - 5;
        private static readonly int WindowHeight = Console.LargestWindowHeight - 5;
        protected static int coordX;
        protected static int coordY;
        #endregion

        /// <summary>
        /// Количество свободных клеток
        /// В NewElementOfSneke отнимается 1 (Змея удлиняется => места становится меньше)
        /// При поедании яблока(Lvel) проверяется значение, если =1 => YOUWIN
        /// </summary>
        protected int NumberOfFreeFields;
        

        #endregion

        public Screen()
        {
            Console.Clear();

            SetupTheConsole();

            InitializingPeremens();

            InitializingScreen();
        }

        private void InitializingPeremens()
        {
            if (WindowHeight - 1 > 3) coordX = WindowHeight - 1;
            else coordX = 4;

            if (WindowWidth - 2 > 3) coordY = WindowWidth - 2;
            else coordX = 5;

            screen = new bool[coordX, coordY];

            NumberOfFreeFields = (coordX * coordY) - (((coordX + coordY) * 2) - 4);
            // Площадь(Длина * ширина) - периметр((Длина + ширина) * 2) - 4(пересечения)
        }

        private static void SetupTheConsole()
        {
            Console.SetWindowSize(Screen.WindowWidth, Screen.WindowHeight);
            Console.CursorVisible = false;
        }

        private void InitializingScreen()
        {
            for (int x = 0; x < screen.GetLength(0); x++)
            {
                for (int y = 0; y < screen.GetLength(1); y++)
                {
                    if (x == 0 || y == 0 || x == coordX - 1 || y == coordY - 1) screen[x, y] = false; //false - граница;
                    else screen[x, y] = true;
                }
            }
        }

        protected void PrintBorder()
        {
            for (int x = 0; x < screen.GetLength(0); x++)
            {
                WriteElementOfBorder(x,0);
                WriteElementOfBorder(x, coordY - 1);
            }
            for (int y = 0; y < screen.GetLength(1); y++)
            {
                WriteElementOfBorder(0, y);
                WriteElementOfBorder(coordX - 1, y);
            }
        }
        private static void WriteElementOfBorder(int x,int y)
        {
            Cursor(x, y);
            Write("+");
        }

        protected void WriteFinalLetterihg(string s)
        {
            Console.Clear();
            Cursor(Console.WindowHeight / 2 , (Console.WindowWidth / 2) - (s.Length / 2)); // Расположение посередине экрана
            Write(s);

            Sleep(2000);
        }


        #region Псевдонимы
        protected static void Write(string x) => Console.Write(x);
        protected static void Write(char x) => Console.Write(x);
        protected static void Cursor(int x, int y) => Console.SetCursorPosition(y, x);
        protected static void Sleep(int x) => System.Threading.Thread.Sleep(x);
        #endregion


    }

}
