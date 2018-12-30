using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Inari.Model
{
    [DataContract]
    public class TrendingAnime
    {
        [DataMember(Name ="id")]
        public int Id { get; private set; }
        [DataMember(Name = "type")]
        public string Type { get; private set; }
        [DataMember(Name = "links")]
        public Dictionary<string, string> Links { get; private set; }
        [DataMember(Name = "attributes")]
        public Anime Attributes { get; private set; }

        [JsonConstructor]
        internal TrendingAnime(int id, string type, Dictionary<string, string> links, Anime attributes)
        {
            Id = id;
            Type = type;
            Links = links;
            Attributes = attributes;
        }

        public override string ToString()
        {
            return Attributes.CanonicalTitle ?? base.ToString();
        }
    }
}
