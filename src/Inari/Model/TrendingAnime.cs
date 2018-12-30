using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;

namespace Inari.Model
{
    [DataContract]
    public class TrendingAnime: ITrendingMedia
    {
        [DataMember(Name ="id")]
        public int Id { get; private set; }
        [DataMember(Name = "type")]
        public string Type { get; private set; }
        [DataMember(Name = "links")]
        public ReadOnlyDictionary<string, string> Links { get; private set; }
        [DataMember(Name = "attributes")]
        public IMedia Attributes { get; private set; }

        [JsonConstructor]
        internal TrendingAnime(int id, string type, ReadOnlyDictionary<string, string> links, Anime attributes)
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
