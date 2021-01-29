using System;
using System.Collections.Generic;
using System.Text;

namespace Vocabulary
{
    public class Translation : IEntity
    {
        public int Id { get; set; }
        public int Language1Id { get; set; }
        public int Word1Id { get; set; }

        public int Language2Id { get; set; }
        public int Word2Id { get; set; }

    }
}
