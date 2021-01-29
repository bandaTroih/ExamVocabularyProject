using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleGraphics;

namespace VocabularyProject
{
    class MainMenu : ConsoleView, IApplictionView
    {
        public event EventHandler AddNewWordButtonClick;
        
        public event SearchWordHandler SearchWord;
        public event GetAllWordsHandler GetAllWordsFromLanguage;
        public event GetAllLanguagesHandler GetAllLanguages;

        public List<string> SearchWordInvoker(string word)
            => SearchWord?.Invoke(word);

        public List<string> GetAllWordsInvoker(string language)
            => GetAllWordsFromLanguage?.Invoke(language);

        public List<string> GetAllLanguagesInvoker()
            => GetAllLanguages?.Invoke();

        public void AddNewWordButtonClickInvoker(object sender, EventArgs e)
            => AddNewWordButtonClick?.Invoke(sender, e);


        public string NewWordText => languagePage.NewWord; 
        
        public List<string> NewWordTranslations  => throw new NotImplementedException(); 

        public string NewWordLanguage => languagePage.Language;

        public MainMenu()
        {
            
            Initialize();
        }


        void OnExitButtonClick(object s, EventArgs e)
        {
            Runing = false;
        }

        
        private void UpdateLanguages()
        {
            Languages.Elements.Clear();
            List<string> lngs = GetAllLanguages?.Invoke();
            foreach (var l in lngs)
            {
                ConsoleListElement cle = new ConsoleListElement(Languages, l, ConsoleColor.Blue);
                cle.OnClick += Language_OnClick;
                Languages.Elements.Add(cle);
            }
        }

        private void Language_OnClick(object sender, EventArgs e)
        {
            languagePage = new LanguagePage(this, (sender as ConsoleListElement).Text);
            languagePage.Run();
        }

        private LanguagePage languagePage;
        private ConsoleButton ExitButton;
        private ConsoleButton AddLanguage;
        private ConsoleInput GetAllWordsFromLanguageInput;
        private ConsoleList Languages;

        private void Initialize()
        {
            Title = "Library Project";
            ExitButton = new ConsoleButton("Exit");
            AddLanguage = new ConsoleButton("Add new Language");
            GetAllWordsFromLanguageInput = new ConsoleInput("Select all words from language");
            Languages = new ConsoleList("Languages");

            //GetAllWordsFromLanguageInput.OnClick += GetAllWordsFromLanguageInput_OnClick;
            ExitButton.OnClick += OnExitButtonClick;
            OnStart += MainMenu_OnStart;

            Controls.Add(ExitButton);
            Controls.Add(Languages);
            //Controls.Add(GetAllWordsFromLanguageInput);
        }

        private void MainMenu_OnStart(object sender, EventArgs e)
        {
            UpdateLanguages();
        }

        public void ShowError(string text)
        {
            new MessageBoxError(text).Run();
        }

        
    }
}
