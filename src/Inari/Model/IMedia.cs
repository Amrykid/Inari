using System.Collections.ObjectModel;

namespace Inari.Model
{
    public interface IMedia
    {
        string Slug { get; }
        string Synopsis { get; }
        ReadOnlyDictionary<string, string> Titles { get; }
        string CanonicalTitle { get; }
    }
}