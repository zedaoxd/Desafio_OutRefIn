using System;

namespace _172_Desafio_OutRefIn
{
    class ConsoleEngine
    {
        private Player player;
        private const int screenWidth = 100;
        private const int screenStartX = 10;
        private const int screenStartY = 2;
        private const int screenHeight = 20;

        public ConsoleEngine(Player player)
        {
            this.player = player;
        }

        public void Draw()
        {
            Console.Clear();
            DrawUtils.Rectangle(screenWidth, screenHeight, screenStartX, screenStartY, ConsoleColor.Red);
            DrawUtils.Rectangle(player.RectSize.X, player.RectSize.Y, player.Position.X, player.Position.Y);
        }

        public void ReturnBounds(out Vector2 start, out Vector2 end)
        {
            start = new Vector2(screenStartX, screenStartY);
            end = new Vector2(screenStartX + screenWidth, screenStartY + screenHeight);
        }
    }
}
