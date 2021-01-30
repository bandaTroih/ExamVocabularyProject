using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGraphics;

namespace VocabularyProject.Views
{
    class AddNewWordPage : ConsoleView
    {
        public string NewWord => WordInput.Value;
        public Dictionary<string, List<string>> NewWordTranslations { get; set; }
        //{
        //    get
        //    {
        //        List<string> res = new List<string>();
        //        for (int i = 1; i < Translations.Elements.Count; i++)
        //            if ((Translations.Elements[i] as ConsoleInput).Value != string.Empty)
        //                res.Add((Translations.Elements[i] as ConsoleInput).Value);
        //        return new Dictionary<string, List<string>> { { "Russian", res } };
        //    }
        //}
        public string Language { get; set; }
        public LanguagePage Parent { get; set; }
        public AddNewWordPage(LanguagePage parent)
        {
            Parent = parent;
            Language = parent.Language;
            Initialize();
        }


        void OnBackButtonClick(object s, EventArgs e)
        {
            Runing = false;
        }


        private AddTranslationToWordPage addTranslationToWordPage;
        private ConsoleButton BackButton;
        private ConsoleInput WordInput;
        private ConsoleButton AddWord;
        private ConsoleList Translations;

        private void Initialize()
        {
            BackButton = new ConsoleButton("Back");
            AddWord = new ConsoleButton("Add new word");
            WordInput = new ConsoleInput("New word");
            Translations = new ConsoleList("Translations");

            BackButton.OnClick += OnBackButtonClick;
            OnStart += AddNewWordPage_OnStart;
            AddWord.OnClick += AddWord_OnClick;
            ConsoleButton addNewTranslation = new ConsoleButton("Add new one");
            addNewTranslation.OnClick += AddNewTranslation_OnClick;
            Translations.Elements.Add(addNewTranslation);

            Controls.Add(BackButton);
            Controls.Add(WordInput);
            Controls.Add(Translations);
            Controls.Add(AddWord);
        }

        private void AddNewTranslation_OnClick(object sender, EventArgs e)
        {
            string TitleBckp = Title;
            addTranslationToWordPage = new AddTranslationToWordPage(this);
            addTranslationToWordPage.Run();
            Title = TitleBckp;
            //Translations.Elements.Add(new ConsoleInput(NewWord));
        }

        private void AddWord_OnClick(object sender, EventArgs e)
        {
            Parent.Parent.AddNewWordButtonClickInvoker(Parent.Parent, e);
        }

        private void AddNewWordPage_OnStart(object sender, EventArgs e)
        {
            Title = $"New word for {Language} language";
        }
    }
}
