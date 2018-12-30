using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Inari.Model
{
    [DataContract]
    public class MediaImageInfoMetadataDimension
    {
        [DataMember(Name = "tiny")]
        public MediaImageInfoDimension Tiny { get; private set; }
        [DataMember(Name = "small")]
        public MediaImageInfoDimension Small { get; private set; }
        [DataMember(Name = "medium")]
        public MediaImageInfoDimension Medium { get; private set; }
        [DataMember(Name = "large")]
        public MediaImageInfoDimension Large { get; private set; }
        [DataMember(Name = "original")]
        public MediaImageInfoDimension Original { get; private set; }

        [JsonConstructor]
        internal MediaImageInfoMetadataDimension(MediaImageInfoDimension tiny, MediaImageInfoDimension small, MediaImageInfoDimension medium, MediaImageInfoDimension large, MediaImageInfoDimension original)
        {
            Tiny = tiny;
            Small = small;
            Medium = medium;
            Large = large;
            Original = original;
        }
    }
}