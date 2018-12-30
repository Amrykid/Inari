using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Inari.Model
{
    [DataContract]
    public class MangaContainer
    {
        [DataMember]
        public IEnumerable<Manga> Data { get; set; }
    }
}
