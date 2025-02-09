using System;
using System.Collections.Generic;

namespace Игра_змейка
{
    internal class Level : Screen
    {
        public event Action ActionEATEAPPLE = delegate { };

        protected int level = 1;
        protected int speed = 1000;
        protected bool live = true;

        protected string Direction = "right";
        protected Dictionary<int, int[]> snake = new Dictionary<int, int[]>();
        protected int[] apple = new int[2];

        public Level() : base()
        {

        }
        protected void NewLevel()
        {
            level += 1;
            SpeedApp();

            if (NumberOfFreeFields <= 1)
            {
                YOUWIN();
            }
        }
        public void SpeedApp()
        {
            switch (level)
            {
                case 3: speed = 900; break;
                case 6: speed = 800; break;
                case 7: speed = 700; break;
                case 8: speed = 600; break;
                case 9: speed = 500; break;
                case 10: speed = 450; break;
                case 11: speed = 400; break;
            }
        }

        protected void EATEAPPLE()
        {
            NewLevel();
            ActionEATEAPPLE();
        }
        protected void GEMEOVER()
        {
            live = false;
            WriteFinalLetterihg("GameOver");
        }
        protected void YOUWIN()
        {
            live = false;
            WriteFinalLetterihg("You Win!!!");
        }
    }
}
