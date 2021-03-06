﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Inari.Model
{
    [DataContract]
    public class Manga: IEntity
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }
        [DataMember(Name = "type")]
        public string Type { get; private set; }
        [DataMember(Name = "links")]
        public ReadOnlyDictionary<string, string> Links { get; private set; }
        [DataMember(Name = "attributes")]
        public IEntityAttributes Attributes { get; private set; }

        [JsonConstructor]
        internal Manga(int id, string type, ReadOnlyDictionary<string, string> links, MangaAttributes attributes)
        {
            Id = id;
            Type = type;
            Links = links;
            Attributes = attributes;
        }

        public override string ToString()
        {
            return ((IMediaAttributes)Attributes).CanonicalTitle ?? base.ToString();
        }
    }
}