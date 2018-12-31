using System.Runtime.Serialization;

namespace Inari.Model
{
    [DataContract]
    public class UserRelationships
    {
        [DataMember(Name = "waifu")]
        public RelationshipInfo Waifu { get; private set; }
        [DataMember(Name = "husbando")]
        public RelationshipInfo Husbando { get; private set; }
        [DataMember(Name = "pinnedPost")]
        public RelationshipInfo PinnedPost { get; private set; }
        [DataMember(Name = "followers")]
        public RelationshipInfo Followers { get; private set; }
        [DataMember(Name = "following")]
        public RelationshipInfo Following { get; private set; }
        [DataMember(Name = "blocks")]
        public RelationshipInfo Blocks { get; private set; }
        [DataMember(Name = "linkedAccounts")]
        public RelationshipInfo LinkedAccounts { get; private set; }
        [DataMember(Name = "profileLinks")]
        public RelationshipInfo ProfileLinks { get; private set; }
        [DataMember(Name = "userRoles")]
        public RelationshipInfo UserRoles { get; private set; }
        [DataMember(Name = "libraryEntries")]
        public RelationshipInfo LibraryEntries { get; private set; }
        [DataMember(Name = "favorites")]
        public RelationshipInfo Favorites { get; private set; }
        [DataMember(Name = "reviews")]
        public RelationshipInfo Reviews { get; private set; }
        [DataMember(Name = "stats")]
        public RelationshipInfo Stats { get; private set; }
        [DataMember(Name = "notificationSettings")]
        public RelationshipInfo NotificationSettings { get; private set; }
        [DataMember(Name = "oneSignalPlayers")]
        public RelationshipInfo OneSignalPlayers { get; private set; }
        [DataMember(Name = "categoryFavorites")]
        public RelationshipInfo CategoryFavorites { get; private set; }
        [DataMember(Name = "quotes")]
        public RelationshipInfo Quotes { get; private set; }
    }
}