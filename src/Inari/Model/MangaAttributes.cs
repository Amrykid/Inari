using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Inari.Model
{
    [DataContract]
    public class MangaAttributes: IMediaAttributes
    {
        [DataMember(Name = "createdAt")]
        public DateTime CreatedAt { get; private set; }
        [DataMember(Name = "updatedAt")]
        public DateTime UpdatedAt { get; private set; }
        [DataMember(Name = "slug")]
        public string Slug { get; private set; }
        [DataMember(Name = "synopsis")]
        public string Synopsis { get; private set; }
        [DataMember(Name = "coverImageTopOffset")]
        public int CoverImageTopOffset { get; private set; }
        [DataMember(Name = "titles")]
        public ReadOnlyDictionary<string, string> Titles { get; private set; }
        [DataMember(Name = "canonicalTitle")]
        public string CanonicalTitle { get; private set; }
        [DataMember(Name = "abbreviatedTitles")]
        public string[] AbbreviatedTitles { get; private set; }
        [DataMember(Name = "averageRating")]
        public double? AverageRating { get; private set; }
        [DataMember(Name = "ratingFrequencies")]
        public ReadOnlyDictionary<string, string> RatingFrequencies { get; private set; }
        [DataMember(Name = "userCount")]
        public int UserCount { get; private set; }
        [DataMember(Name = "favoritesCount")]
        public int FavoritesCount { get; private set; }
        [DataMember(Name = "startDate")]
        public DateTime? StartDate { get; private set; }
        [DataMember(Name = "endDate")]
        public DateTime? EndDate { get; private set; }
        [DataMember(Name = "popularityRank")]
        public int PopularityRank { get; private set; }
        [DataMember(Name = "ratingRank")]
        public int? RatingRank { get; private set; }
        [DataMember(Name = "ageRating")]
        public string AgeRating { get; private set; }
        [DataMember(Name = "ageRatingGuide")]
        public string AgeRatingGuide { get; private set; }
        //todo enum
        [DataMember(Name = "subtype")]
        public string Subtype { get; private set; }
        //todo enum
        [DataMember(Name = "status")]
        public string Status { get; private set; }
        [DataMember(Name = "tba")]
        public string TBA { get; private set; }
        [DataMember(Name = "posterImage")]
        public MediaImageInfo PosterImage { get; private set; }
        [DataMember(Name = "coverImage")]
        public MediaImageInfo CoverImage { get; private set; }
        [DataMember(Name = "volumeCount")]
        public int? VolumeCount { get; private set; }
        [DataMember(Name = "chapterCount")]
        public int? ChapterCount { get; private set; }
        [DataMember(Name = "serialization")]
        public string Serialization { get; private set; }
    }
}