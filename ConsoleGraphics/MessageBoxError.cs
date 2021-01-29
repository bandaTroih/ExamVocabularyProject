using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public class MessageBoxError : ConsoleView
    {
        public MessageBoxError(string message) : this(message, "Error")
        {
        }
        public MessageBoxError(string message, string caption)
        {
            Initialize();
            Title = caption;
            MessageLabel.Text = message;
        }


        void OnOkButtonClick(object s, EventArgs e)
        {
            Runing = false;
        }


        public ConsoleLabel MessageLabel;
        public ConsoleButton OkButton;

        private void Initialize()
        {
            MessageLabel = new ConsoleLabel(ConsoleColor.Red);
            OkButton = new ConsoleButton("OK");

            OkButton.OnClick += OnOkButtonClick;
            


            Controls.Add(MessageLabel);
            Controls.Add(OkButton);
        }
    }
}
