using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Inari.Model
{
    [DataContract]
    public class TrendingAnimeContainer
    {
        [DataMember]
        public IEnumerable<TrendingAnime> Data { get; set; }
    }
}
