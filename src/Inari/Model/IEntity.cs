using System.Collections.ObjectModel;

namespace Inari.Model
{
    public interface IEntity
    {
        int Id { get; }
        string Type { get; }
        ReadOnlyDictionary<string, string> Links { get; }
        IEntityAttributes Attributes { get; }
    }
}