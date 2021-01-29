using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public class ConsoleLabel : ConsoleObject
    {
        public ConsoleLabel() : this(string.Empty, Config.DefaultColor)
        {
        }
        public ConsoleLabel(ConsoleColor color) : this(string.Empty, color)
        {
        }
        public ConsoleLabel(string text) : this(text, Config.DefaultColor)
        {
        }
        public ConsoleLabel(string text, ConsoleColor color)
        {
            Text = text;
            Color = color;
        }
    }
}
