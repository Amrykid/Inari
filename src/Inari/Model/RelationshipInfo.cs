using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Inari.Model
{
    [DataContract]
    public class RelationshipInfo
    {
        [DataMember(Name = "links")]
        public ReadOnlyDictionary<string, string> Links { get; private set; }

        public KitsuAPILink GetRelationshipAsAPILink(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (Links == null) throw new Exception("No links available.");
            if (!Links.ContainsKey(key)) throw new ArgumentException(string.Format("Key {0} not found.", key), paramName: key);

            return new KitsuAPILink(new Uri(Links[key]));
        }
    }
}