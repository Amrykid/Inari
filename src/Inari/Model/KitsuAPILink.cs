using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Inari.Model
{
    [DataContract]
    internal class KitsuAPILink
    {
        [DataMember]
        public Uri Url { get; private set; }

        [JsonConstructor()]
        internal KitsuAPILink(Uri uri)
        {
            Url = uri;
        }
    }
}