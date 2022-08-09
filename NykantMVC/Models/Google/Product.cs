using Newtonsoft.Json;

namespace NykantMVC.Models.Google
{
    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("offerId")]
        public string OfferId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("imageLink")]
        public string ImageLink { get; set; }
        [JsonProperty("additionalImageLinks")]
        public string[] AdditionalImageLinks { get; set; }
        [JsonProperty("contentLanguage")]
        public string ContentLanguage { get; set; }
        [JsonProperty("targetCountry")]
        public string TargetCountry { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("expirationDate")]
        public string ExpirationDate { get; set; }
        [JsonProperty("adult")]
        public bool Adult { get; set; }
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("googleProductCategory")]
        public string GoogleProductCategory { get; set; }
        [JsonProperty("multipack")]
        public string Multipack { get; set; }
        [JsonProperty("condition")]
        public string Condition { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("gtin")]
        public string Gtin { get; set; }
        [JsonProperty("itemGroupId")]
        public string ItemGroupId { get; set; }
        [JsonProperty("material")]
        public string Material { get; set; }
        [JsonProperty("mpn")]
        public string Mpn { get; set; }
        [JsonProperty("pattern")]
        public string Pattern { get; set; }
        [JsonProperty("price")]
        public Price Price { get; set; }
        [JsonProperty("salePrice")]
        public Price SalePrice { get; set; }
        [JsonProperty("salePriceEffectiveDate")]
        public string SalePriceEffectiveDate { get; set; }
        [JsonProperty("productHeight")]
        public ProductDimension ProductHeight { get; set; }
        [JsonProperty("productLength")]
        public ProductDimension ProductLength { get; set; }
        [JsonProperty("productWidth")]
        public ProductDimension ProductWidth { get; set; }
        [JsonProperty("productWeight")]
        public ProductWeight ProductWeight { get; set; }
        [JsonProperty("shipping")]
        public ProductShipping Shipping { get; set; }
        [JsonProperty("shippingWeight")]
        public ProductShippingWeight ShippingWeight { get; set; }
        [JsonProperty("sizes")]
        public string Sizes { get; set; }
        [JsonProperty("taxes")]
        public ProductTax Taxes { get; set; }
        [JsonProperty("customAttributes")]
        public CustomAttribute CustomAttributes { get; set; }
        [JsonProperty("identifierExists")]
        public bool IdentifierExists { get; set; }
        [JsonProperty("installment")]
        public Installment Installment { get; set; }
    }
}
