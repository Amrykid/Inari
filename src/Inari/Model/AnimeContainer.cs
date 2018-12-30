using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Inari.Model
{
    [DataContract]
    public class AnimeContainer
    {
        [DataMember]
        public IEnumerable<Anime> Data { get; set; }
    }
}
