namespace Inari.Model
{
    public interface IEntityAttributes
    {
        string Slug { get; }
    }

    public static class EntityAttributesExtensions
    {
        public static T As<T>(this IEntityAttributes mediaAttributes) where T : IEntityAttributes
        {
            return (T)mediaAttributes;
        }
    }
}