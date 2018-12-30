using System;
using System.Runtime.Serialization;

namespace Inari.Model
{
    [DataContract]
    public class MediaImageInfo
    {
        [DataMember(Name = "tiny")]
        public Uri Tiny { get; private set; }
        [DataMember(Name = "small")]
        public Uri Small { get; private set; }
        [DataMember(Name = "medium")]
        public Uri Medium { get; private set; }
        [DataMember(Name = "large")]
        public Uri Large { get; private set; }
        [DataMember(Name = "original")]
        public Uri Original { get; private set; }
        [DataMember(Name = "meta")]
        public MediaImageInfoMetadata Meta { get; private set; }
    }
}