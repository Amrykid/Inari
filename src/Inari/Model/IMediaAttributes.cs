using System.Collections.ObjectModel;

namespace Inari.Model
{
    public interface IMediaAttributes
    {
        string Slug { get; }
        string Synopsis { get; }
        ReadOnlyDictionary<string, string> Titles { get; }
        string CanonicalTitle { get; }
    }
}