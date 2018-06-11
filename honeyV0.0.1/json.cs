// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var products = Products.FromJson(jsonString);

namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Products
    {
        [JsonProperty("products")]
        public Product[] ProductsProducts { get; set; }
    }

    public partial class Product
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("handle")]
        public string Handle { get; set; }

        [JsonProperty("body_html")]
        public string BodyHtml { get; set; }

        [JsonProperty("published_at")]
        public DateTimeOffset PublishedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("product_type")]
        public string ProductType { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("variants")]
        public Variant[] Variants { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("options")]
        public Option[] Options { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("variant_ids")]
        public object[] VariantIds { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public partial class Option
    {
        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("values")]
        public string[] Values { get; set; }
    }

    public partial class Variant
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("option1")]
        public string Option1 { get; set; }

        [JsonProperty("option2")]
        public object Option2 { get; set; }

        [JsonProperty("option3")]
        public object Option3 { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("requires_shipping")]
        public bool RequiresShipping { get; set; }

        [JsonProperty("taxable")]
        public bool Taxable { get; set; }

        [JsonProperty("featured_image")]
        public object FeaturedImage { get; set; }

        [JsonProperty("available")]
        public bool Available { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("grams")]
        public long Grams { get; set; }

        [JsonProperty("compare_at_price")]
        public string CompareAtPrice { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public enum Name { UsSize };

    public partial class Products
    {
        public static Products FromJson(string json) => JsonConvert.DeserializeObject<Products>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Products self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new NameConverter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class NameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Name) || t == typeof(Name?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "US Size")
            {
                return Name.UsSize;
            }
            throw new Exception("Cannot unmarshal type Name");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Name)untypedValue;
            if (value == Name.UsSize)
            {
                serializer.Serialize(writer, "US Size"); return;
            }
            throw new Exception("Cannot marshal type Name");
        }
    }
}
