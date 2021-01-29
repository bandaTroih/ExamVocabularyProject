using System;
using System.Collections.Generic;
using System.Text;

namespace Vocabulary.Exceptions
{
    class TranslationNotFound : Exception
    {
        public TranslationNotFound(string message) : base(message)
        { }
    }
}
