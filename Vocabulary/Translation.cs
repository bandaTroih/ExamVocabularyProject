using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Vocabulary
{
    [DataContract]
    public class Translation : IEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Language1Id { get; set; }
        [DataMember]
        public int Word1Id { get; set; }
        [DataMember]

        public int Language2Id { get; set; }
        [DataMember]
        public int Word2Id { get; set; }

    }
}
