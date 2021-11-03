using System;

namespace _172_Desafio_OutRefIn
{
    class Game
    {
        private Player player;
        private ConsoleEngine engine;
        public Game()
        {
            player = new Player()
            {
                Position = new Vector2
                {
                    X = 10,
                    Y = 10
                },
                RectSize = new Vector2
                {
                    X = 2,
                    Y = 1,
                }
            };
            engine = new ConsoleEngine(player);
        }

        public void Play()
        {
            while (true)
            {
                engine.Draw();
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

                if (key.Key == ConsoleKey.D)
                {
                    Move(ref player.Position, new Vector2(5, 0));
                }

                if (key.Key == ConsoleKey.A)
                {
                    Move(ref player.Position, new Vector2(-5, 0));
                }

                if (key.Key == ConsoleKey.W)
                {
                    Move(ref player.Position, new Vector2(0, -5));
                }

                if (key.Key == ConsoleKey.S)
                {
                    Move(ref player.Position, new Vector2(0, 5));
                }
            }
        }

        private void Move(ref Vector2 playerPosition, in Vector2 targetPosition)
        {
            engine.ReturnBounds(out Vector2 start, out Vector2 end);

            playerPosition.Y = Math.Clamp(playerPosition.Y + targetPosition.Y, start.Y, end.Y - player.RectSize.Y);
            playerPosition.X = Math.Clamp(playerPosition.X + targetPosition.X, start.X, end.X - player.RectSize.X);

        }
    }
}
