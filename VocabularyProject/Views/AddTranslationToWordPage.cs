using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGraphics;

namespace VocabularyProject.Views
{
    class AddTranslationToWordPage : ConsoleView
    {
        public Tuple<string, string> NewWordTranslation
            => new Tuple<string, string>(Languages.Checked.Text, TranslationInput.Value);

        public string Language { get; set; }
        public AddNewWordPage Parent { get; set; }
        public AddTranslationToWordPage(AddNewWordPage parent)
        {
            Parent = parent;
            Language = parent.Language;
            Initialize();
        }


        void OnBackButtonClick(object s, EventArgs e)
        {
            Runing = false;
        }



        private ConsoleButton BackButton;
        private ConsoleInput TranslationInput;
        private ConsoleButton AddTranslation;
        private ConsoleRadioBox Languages;

        private void Initialize()
        {
            BackButton = new ConsoleButton("Back");
            AddTranslation = new ConsoleButton("Add new translation");
            TranslationInput = new ConsoleInput("Translation");
            Languages = new ConsoleRadioBox("Select language");

            BackButton.OnClick += OnBackButtonClick;
            OnStart += AddTranslationToWordPage_OnStart;
            AddTranslation.OnClick += AddNewTranslation_OnClick;
            foreach (var l in Parent.Parent.Parent.GetAllLanguagesInvoker())
                if(l != Language)
                    Languages.Elements.Add(new ConsoleRadioBoxElement(Languages, l));



            Controls.Add(BackButton);
            Controls.Add(TranslationInput);
            Controls.Add(Languages);
            Controls.Add(AddTranslation);
        }

        private void AddNewTranslation_OnClick(object sender, EventArgs e)
        {
            Runing = false;
            //Translations.Elements.Add(new ConsoleInput(NewWord));
        }

        private void AddTranslationToWordPage_OnStart(object sender, EventArgs e)
        {
            Title = $"New Translation";
        }
    }
}
