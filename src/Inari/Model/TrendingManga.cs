using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Inari.Model
{
    [DataContract]
    public class TrendingManga: ITrendingMedia
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }
        [DataMember(Name = "type")]
        public string Type { get; private set; }
        [DataMember(Name = "links")]
        public ReadOnlyDictionary<string, string> Links { get; private set; }
        [DataMember(Name = "attributes")]
        public IMedia Attributes { get; private set; }

        [JsonConstructor]
        internal TrendingManga(int id, string type, ReadOnlyDictionary<string, string> links, Manga attributes)
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