using System.Collections.ObjectModel;

namespace Inari.Model
{
    public interface IMediaAttributes: IEntityAttributes
    {
        string CanonicalTitle { get; }
        string Synopsis { get; }
        ReadOnlyDictionary<string, string> Titles { get; }
    }
}