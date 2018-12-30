using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Inari.Model
{
    [DataContract]
    public class MediaImageInfoDimension
    {
        [DataMember(Name = "width")]
        public int? Width { get; private set; }
        [DataMember(Name = "height")]
        public int? Height { get; private set; }

        [JsonConstructor]
        public MediaImageInfoDimension(int? width, int? height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            if (Width == null || Height == null) return base.ToString();

            return string.Format("{0}x{1}", Width, Height);
        }
    }
}