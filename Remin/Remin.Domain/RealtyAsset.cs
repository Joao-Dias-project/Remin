namespace Remin.Domain
{
    public class RealtyAsset
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Region Region { get; set; }
        public float Price { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
    }
}
