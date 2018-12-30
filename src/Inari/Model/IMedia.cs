using System.Collections.ObjectModel;

namespace Inari.Model
{
    public interface IMedia
    {
        int Id { get; }
        string Type { get; }
        ReadOnlyDictionary<string, string> Links { get; }
        IMediaAttributes Attributes { get; }
    }
}