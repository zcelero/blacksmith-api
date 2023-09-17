namespace BlacksmithAPI
{
    public class Material
    {
        public string Id { get; set; }
        public float PriceModifier { get; set; }

        public Material(string id, float priceModifier)
        {
            Id = id;
            PriceModifier = priceModifier;
        }
    }
}
