using System;
using System.Runtime.Serialization;

namespace Inari.Model
{
    [DataContract]
    public class UserAttributes: IEntityAttributes
    {
        [DataMember(Name = "createdAt")]
        public DateTime CreatedAt { get; private set; }
        [DataMember(Name = "updatedAt")]
        public DateTime UpdatedAt { get; private set; }
        [DataMember(Name = "name")]
        public string Name { get; private set; }
        [DataMember(Name = "pastNames")]
        public string[] PastNames { get; private set; }
        [DataMember(Name = "slug")]
        public string Slug { get; private set; }
        [DataMember(Name = "about")]
        public string About { get; private set; }
        [DataMember(Name = "location")]
        public string Location { get; private set; }
        [DataMember(Name = "waifuOrHusbando")]
        public string WaifuOrHusbando { get; private set; }
        [DataMember(Name = "followersCount")]
        public string FollowersCount { get; private set; }
        [DataMember(Name = "followingCount")]
        public string FollowingCount { get; private set; }
        [DataMember(Name = "birthday")]
        public string Birthday { get; private set; }
        [DataMember(Name = "Gender")]
        public string Gender { get; private set; }
        [DataMember(Name = "commentsCount")]
        public int CommentsCount { get; private set; }
        [DataMember(Name = "favoritesCount")]
        public int FavoritesCount { get; private set; }
        [DataMember(Name = "likesGivenCount")]
        public int LikesGivenCount { get; private set; }
        [DataMember(Name = "reviewsCount")]
        public int ReviewsCount { get; private set; }
        [DataMember(Name = "likesReceivedCount")]
        public int LikesReceivedCount { get; private set; }
        [DataMember(Name = "postsCount")]
        public int PostsCount { get; private set; }
        [DataMember(Name = "ratingsCount")]
        public int RatingsCount { get; private set; }
        [DataMember(Name = "mediaReactionsCount")]
        public int MediaReactionsCount { get; private set; }
        [DataMember(Name = "proExpiresAt")]
        public DateTime? ProExpiresAt { get; private set; }
        [DataMember(Name = "title")]
        public string Title { get; private set; }
        [DataMember(Name = "avatar")]
        public MediaImageInfo Avatar { get; private set; }
        [DataMember(Name = "coverImage")]
        public MediaImageInfo CoverImage { get; private set; }
    }
}