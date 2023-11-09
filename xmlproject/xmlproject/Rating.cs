﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using RatingData;
//
//    var rating = Rating.FromJson(jsonString);

namespace RatingData
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Rating
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Street")]
        public string Street { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("Postal Code")]
        public long PostalCode { get; set; }

        [JsonProperty("Reviews")]
        public string Reviews { get; set; }

        [JsonProperty("No of Reviews")]
        public string NoOfReviews { get; set; }

        [JsonProperty("Comments")]
        public string Comments { get; set; }
    }

    public partial class Rating
    {
        public static List<Rating> FromJson(string json) => JsonConvert.DeserializeObject<List<Rating>>(json, RatingData.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<Rating> self) => JsonConvert.SerializeObject(self, RatingData.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}