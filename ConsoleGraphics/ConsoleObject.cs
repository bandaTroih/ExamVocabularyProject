using System;

namespace ConsoleGraphics
{
    public abstract class ConsoleObject : IDrawable
    {
        public string Text { get; set; }
        public ConsoleColor Color = Config.DefaultColor;

        public virtual void Draw()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(Text);
            Console.ResetColor();
        }
    }
}
