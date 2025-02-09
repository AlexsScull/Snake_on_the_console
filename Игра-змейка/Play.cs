using System;
using System.Threading.Tasks;

namespace Игра_змейка
{
    internal class Play : Apple
    {
        public Play() : base()
        {
            PrintApple();
            PrintSnake();
            PrintBorder();

            Task.Run(() => InteractionWithPlayer());
            Go();
        }

        private void InteractionWithPlayer()
        {
            while (live)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                char x = Convert.ToChar(key.Key);
                if (x == 'W') { TryMenaDirection_1Yslovie_2Napravlenie("down", "up"); }
                if (x == 'A') { TryMenaDirection_1Yslovie_2Napravlenie("right", "left"); }
                if (x == 'S') { TryMenaDirection_1Yslovie_2Napravlenie("up", "down"); }
                if (x == 'D') { TryMenaDirection_1Yslovie_2Napravlenie("left", "right"); }
                if (x == ' ' || x == '\r') { GEMEOVER(); }
            }
        }

        private void TryMenaDirection_1Yslovie_2Napravlenie(string NonE, string E)
        {
            if (Proverka(NonE, E))
            {
                Direction = E;
            }
        }

        private bool Proverka(string NonE, string E)
        {
            return Direction != NonE && Proverka2KeyBSheke(E);
        }
    }
}
