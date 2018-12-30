using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Inari.Model
{
    [DataContract]
    public class TrendingMangaContainer
    {
        [DataMember]
        public IEnumerable<TrendingManga> Data { get; set; }
    }
}
