using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Inari.Model
{
    [DataContract]
    public class EntityContainer<T> where T: IEntity
    {
        [DataMember]
        public IEnumerable<T> Data { get; set; }
    }
}

