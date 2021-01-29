using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public class ConsoleInput : ConsoleObject, ISelectableClickable
    {
        public bool Selected { get; set; }
        public string Value { get; set; }
        public ConsoleColor SelectedColor { get; set; } = Config.SelectedColor;

        public event EventHandler OnClick;

        public ConsoleInput() : this(string.Empty, Config.DefaultColor)
        {
        }
        public ConsoleInput(ConsoleColor color) : this(string.Empty, color)
        {
        }
        public ConsoleInput(string text) : this(text, Config.DefaultColor)
        {
        }
        public ConsoleInput(string text, ConsoleColor color)
        {
            Text = text;
            Color = color;
        }


        public void Click()
        {
            Console.Clear();
            Console.ForegroundColor = Color;
            Console.Write(Text + " = ");
            Value = Console.ReadLine();
            Console.ResetColor();
            OnClick?.Invoke(this, new EventArgs());
        }
        public override void Draw()
        {
            if (Selected)
            {
                Console.Write(Config.SelectedPrefix);
                Console.ForegroundColor = SelectedColor;
                Console.WriteLine($"{Text} = \"{Value}\"");
            }
            else
            {
                Console.ForegroundColor = Color;
                Console.WriteLine($"{Text} = \"{Value}\"");
            }
            Console.ResetColor();
        }
    }
}
