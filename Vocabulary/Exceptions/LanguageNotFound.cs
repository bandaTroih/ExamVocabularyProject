using System;
using System.Collections.Generic;
using System.Text;

namespace Vocabulary.Exceptions
{
    public class LanguageNotFound : Exception
    {
        public LanguageNotFound(string message) : base(message)
        { }
    }
}
