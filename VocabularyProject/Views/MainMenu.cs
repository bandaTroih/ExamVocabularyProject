using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleGraphics;

namespace VocabularyProject.Views
{
    class MainMenu : ConsoleView, IApplictionView
    {
        #region Events
        public event EventHandler AddNewWordButtonClick;
        public event SearchWordHandler SearchWord;
        public event GetAllWordsHandler GetAllWordsFromLanguage;
        public event GetAllLanguagesHandler GetAllLanguages;
        public event GetAllWordTranslationsHandler GetAllWordTranslations;
        public event SerializeHandler Serialize;
        public event SerializeHandler DeSerialize;
        #endregion
        #region Invokers
        public List<string> SearchWordInvoker(string word)
            => SearchWord?.Invoke(word);
        public List<string> GetAllWordsInvoker(string language)
            => GetAllWordsFromLanguage?.Invoke(language);
        public List<string> GetAllLanguagesInvoker()
            => GetAllLanguages?.Invoke();
        public void AddNewWordButtonClickInvoker(object sender, EventArgs e)
            => AddNewWordButtonClick?.Invoke(sender, e);
        public List<Tuple<string, string>> GetAllWordTranslationsInvoker(string language, string word)
            => GetAllWordTranslations?.Invoke(language, word);
        public void SerializeInvoker()
            => Serialize?.Invoke();
        public void DeSerializeInvoker()
            => DeSerialize?.Invoke();
        #endregion
        #region Fields
        public string NewWordText => languagePage.NewWord;
        public List<Tuple<string, string>> NewWordTranslations  => languagePage.NewWordTranslations; 
        public string NewWordLanguage => languagePage.Language;
        #endregion
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
            string TiteBckp = Title;
            languagePage = new LanguagePage(this, (sender as ConsoleListElement).Text);
            languagePage.Run();
            Title = TiteBckp;
        }

        private LanguagePage languagePage;
        private ConsoleButton ExitButton;
        private ConsoleButton SaveData;
        private ConsoleList Languages;

        private void Initialize()
        {
            Title = "Library Project";
            ExitButton = new ConsoleButton("Exit");
            SaveData = new ConsoleButton("Save");
            Languages = new ConsoleList("Languages");

            ExitButton.OnClick += OnExitButtonClick;
            OnStart += MainMenu_OnStart;
            SaveData.OnClick += SaveData_OnClick;

            Controls.Add(ExitButton);
            Controls.Add(SaveData);
            Controls.Add(Languages);
        }

        private void SaveData_OnClick(object sender, EventArgs e)
        {
            SerializeInvoker();
        }

        private void MainMenu_OnStart(object sender, EventArgs e)
        {
            DeSerializeInvoker();
            UpdateLanguages();
        }

        public void ShowError(string text)
        {
            string TiteBckp = Title;
            new MessageBoxError(text).Run();
            Title = TiteBckp;
        }

        
    }
}
