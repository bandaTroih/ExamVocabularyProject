using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGraphics;

namespace VocabularyProject.Views
{
    class LanguagePage : ConsoleView
    {
        public string NewWord => addNewWord.NewWord;
        public List<Tuple<string, string>> NewWordTranslations => addNewWord.NewWordTranslations;
        public string Language { get; set; }
        public MainMenu Parent { get; set; }
        public LanguagePage(MainMenu parent, string language)
        {
            Parent = parent;
            Language = language;
            Initialize();
        }


        void OnBackButtonClick(object s, EventArgs e)
        {
            Runing = false;
        }

        private void UpdateWords()
        {
            Words.Elements.Clear();
            List<string> wds = Parent.GetAllWordsInvoker(Language);
            foreach(var w in wds)
            {
                ConsoleListElement ce = new ConsoleListElement(Words, w, ConsoleColor.Blue);
                ce.OnClick += Ce_OnClick;
                Words.Elements.Add(ce);
            }
        }

        private void Ce_OnClick(object sender, EventArgs e)
        {
            string TiteBckp = Title;
            wordPage = new WordPage(this, (sender as ConsoleListElement).Text);
            wordPage.Run();
            Title = TiteBckp;
        }

        private WordPage wordPage;
        private AddNewWordPage addNewWord;
        private ConsoleButton BackButton;
        private ConsoleButton AddWord;
        private ConsoleList Words;

        private void Initialize()
        {
            BackButton = new ConsoleButton("Back");
            AddWord = new ConsoleButton("Add new word");
            Words = new ConsoleList("Words");

            BackButton.OnClick += OnBackButtonClick;
            OnStart += LanguagePage_OnStart;
            AddWord.OnClick += AddWord_OnClick;

            Controls.Add(BackButton);
            Controls.Add(AddWord);
            Controls.Add(Words);
        }

        private void AddWord_OnClick(object sender, EventArgs e)
        {
            string TiteBckp = Title;
            addNewWord = new AddNewWordPage(this);
            addNewWord.Run();
            Title = TiteBckp;
            UpdateWords();
        }

        private void LanguagePage_OnStart(object sender, EventArgs e)
        {
            Title = $"Language - {Language}";
            UpdateWords();
        }
    }
}
