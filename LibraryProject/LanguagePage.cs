using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGraphics;

namespace VocabularyProject
{
    class LanguagePage : ConsoleView
    {
        public string NewWord
        {
            get
            {
                return addNewWord.NewWord;
            }
        }
        public string Language { get; set; }
        public MainMenu Parent { get; set; }
        public LanguagePage(MainMenu parent, string language)
        {
            Parent = parent;
            Language = language;
            Initialize();
        }


        void OnExitButtonClick(object s, EventArgs e)
        {
            Runing = false;
        }

        private void UpdateWords()
        {
            Words.Elements.Clear();
            List<string> wds = Parent.GetAllWordsInvoker(Language);
            foreach(var w in wds)
            {
                Words.Elements.Add(new ConsoleListElement(Words, w, ConsoleColor.Blue));
            }
        }

        private AddNewWordPage addNewWord;
        private ConsoleButton BackButton;
        private ConsoleButton AddWord;
        private ConsoleInput GetAllWordsFromLanguageInput;
        private ConsoleList Words;

        private void Initialize()
        {
            BackButton = new ConsoleButton("Back");
            AddWord = new ConsoleButton("Add new word");
            GetAllWordsFromLanguageInput = new ConsoleInput("Select all words from language");
            Words = new ConsoleList("Words");

            //GetAllWordsFromLanguageInput.OnClick += GetAllWordsFromLanguageInput_OnClick;
            BackButton.OnClick += OnExitButtonClick;
            OnStart += LanguagePage_OnStart;
            AddWord.OnClick += AddWord_OnClick;

            Controls.Add(BackButton);
            Controls.Add(AddWord);
            Controls.Add(Words);
            //Controls.Add(GetAllWordsFromLanguageInput);
        }

        private void AddWord_OnClick(object sender, EventArgs e)
        {
            addNewWord = new AddNewWordPage(this);
            addNewWord.Run();
        }

        private void LanguagePage_OnStart(object sender, EventArgs e)
        {
            Title = $"Language - {Language}";
            UpdateWords();
        }
    }
}
