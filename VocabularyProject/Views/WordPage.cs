﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGraphics;

namespace VocabularyProject.Views
{
    class WordPage : ConsoleView
    {
        
        //public List<Tuple<string, string>> NewWordTranslations { get; set; } = new List<Tuple<string, string>>();

        public string Language { get; set; }
        public string Word { get; set; }
        public LanguagePage Parent { get; set; }
        public WordPage(LanguagePage parent, string word)
        {
            Word = word;
            Parent = parent;
            Language = parent.Language;
            Initialize();
        }


        void OnBackButtonClick(object s, EventArgs e)
        {
            Runing = false;
        }
        void UpdateTranslations()
        {
            //Translations.Elements.RemoveRange(1, Translations.Elements.Count - 1);
            Translations.Elements.Clear();
            foreach (var t in Parent.Parent.GetAllWordTranslationsInvoker(Language, Word))
                Translations.Elements.Add(new ConsoleListElement(Translations, $"{t.Item1} - {t.Item2}"));
        }


        //private AddTranslationToWordPage addTranslationToWordPage;
        private ConsoleButton BackButton;
        private ConsoleLabel WordText;
        private ConsoleList Translations;

        private void Initialize()
        {
            BackButton = new ConsoleButton("Back");
            //AddWord = new ConsoleButton("Add new word");
            WordText = new ConsoleLabel($"  {Word}");
            Translations = new ConsoleList("Translations");

            BackButton.OnClick += OnBackButtonClick;
            OnStart += WordPage_OnStart;
            //AddWord.OnClick += AddWord_OnClick;
            //ConsoleButton addNewTranslation = new ConsoleButton("  Add new one");
            //addNewTranslation.OnClick += AddNewTranslation_OnClick;
            //Translations.Elements.Add(addNewTranslation);

            Controls.Add(BackButton);
            Controls.Add(WordText);
            Controls.Add(Translations);
            //Controls.Add(AddWord);
        }

        //private void AddNewTranslation_OnClick(object sender, EventArgs e)
        //{
        //    string TitleBckp = Title;
        //    addTranslationToWordPage = new AddTranslationToWordPage(this);
        //    addTranslationToWordPage.Run();
        //    Title = TitleBckp;
        //    if (addTranslationToWordPage.NewWordTranslation.Item2 != string.Empty)
        //        NewWordTranslations.Add(addTranslationToWordPage.NewWordTranslation);

        //    UpdateTranslations();
        //}

        private void AddWord_OnClick(object sender, EventArgs e)
        {
            Parent.Parent.AddNewWordButtonClickInvoker(Parent.Parent, e);
        }

        private void WordPage_OnStart(object sender, EventArgs e)
        {
            Title = $"{Word}";
            UpdateTranslations();
        }
    }
}
