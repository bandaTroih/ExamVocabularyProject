using System;
using System.Collections.Generic;
using System.Text;

namespace Vocabulary.Exceptions
{
    class WordNotFound : Exception
    {
        public WordNotFound(string message) : base(message)
        { }
    }
}
