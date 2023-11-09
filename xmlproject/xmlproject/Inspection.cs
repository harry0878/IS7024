﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using InspectionData;
//
//    var inspection = Inspection.FromJson(jsonString);

namespace InspectionData
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Inspection
    {
        [JsonProperty("recordnum_license")]
        public string RecordnumLicense { get; set; }

        [JsonProperty("license_no")]
        public string LicenseNo { get; set; }

        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postal_code")]
        [JsonConverter(typeof(ParseStringConverter))]
        public string PostalCode { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("license_status")]
        public string LicenseStatus { get; set; }

        [JsonProperty("recordnum_insp")]
        public string RecordnumInsp { get; set; }

        [JsonProperty("insp_type")]
        public string InspType { get; set; }

        [JsonProperty("insp_subtype")]
        public string InspSubtype { get; set; }

        [JsonProperty("action_date")]
        public string ActionDate { get; set; }

        [JsonProperty("action_sequence")]
        public string ActionSequence { get; set; }

        [JsonProperty("action_status")]
        public string ActionStatus { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("violation_description")]
        public string ViolationDescription { get; set; }

        [JsonProperty("violation_comments")]
        public string ViolationComments { get; set; }

        [JsonProperty("violation_key")]
        public string ViolationKey { get; set; }

        [JsonProperty("last_table_update")]
        public string LastTableUpdate { get; set; }

        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }
    }

    public partial class Inspection
    {
        public static List<Inspection> FromJson(string json) => JsonConvert.DeserializeObject<List<Inspection>>(json, InspectionData.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<Inspection> self) => JsonConvert.SerializeObject(self, InspectionData.Converter.Settings);
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

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
