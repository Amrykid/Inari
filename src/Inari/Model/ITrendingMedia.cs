using System.Collections.ObjectModel;

namespace Inari.Model
{
    public interface ITrendingMedia
    {
        int Id { get; }
        string Type { get; }
        ReadOnlyDictionary<string, string> Links { get; }
        IMedia Attributes { get; }
    }
}