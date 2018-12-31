using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Inari.Model
{
    [DataContract]
    public class User: IEntity
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }
        [DataMember(Name = "type")]
        public string Type { get; private set; }
        [DataMember(Name = "links")]
        public ReadOnlyDictionary<string, string> Links { get; private set; }
        [DataMember(Name = "attributes")]
        public IEntityAttributes Attributes { get; private set; }

        //[DataMember(Name = "relationships")]
        //public ReadOnlyDictionary<string, ReadOnlyDictionary<string, string>> Relationships { get; private set; }

        [JsonConstructor]
        internal User(int id, string type, ReadOnlyDictionary<string, string> links, UserAttributes attributes)
        {
            Id = id;
            Type = type;
            Links = links;
            Attributes = attributes;
            //Relationships = relationships;
        }

        public override string ToString()
        {
            return Attributes.As<UserAttributes>().Name ?? base.ToString();
        }
    }
}
