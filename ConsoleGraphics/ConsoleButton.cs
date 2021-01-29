using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public class ConsoleButton : ConsoleObject, ISelectableClickable
    {
        public ConsoleColor SelectedColor = Config.SelectedColor;
        public bool Selected { get; set; }
        ConsoleColor ISelectable.SelectedColor { get; set; } = Config.SelectedColor;

        public ConsoleButton() : this(string.Empty, Config.DefaultColor)
        {
        }
        public ConsoleButton(ConsoleColor color) : this(string.Empty, color)
        {
        }
        public ConsoleButton(string text) : this(text, Config.DefaultColor)
        {
        }
        public ConsoleButton(string text, ConsoleColor color)
        {
            Text = text;
            Color = color;
        }

        public override void Draw()
        {
            if(Selected)
            {
                Console.Write(Config.SelectedPrefix);
                Console.ForegroundColor = SelectedColor;
                Console.WriteLine(Text);
            }
            else
                base.Draw();
            Console.ResetColor();
        }

        public void Click()
        {
            OnClick?.Invoke(this, new EventArgs());
        }

        public event EventHandler OnClick;
    }
}
