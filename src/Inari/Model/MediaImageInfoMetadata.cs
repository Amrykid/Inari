using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Inari.Model
{
    [DataContract]
    public class MediaImageInfoMetadata
    {
        [DataMember(Name = "dimensions")]
        public MediaImageInfoMetadataDimension Dimensions { get; private set; }

        [JsonConstructor]
        public MediaImageInfoMetadata(MediaImageInfoMetadataDimension dimensions)
        {
            Dimensions = dimensions;
        }
    }
}