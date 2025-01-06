namespace Poiect_cafea.Models
{
    public class Blend
    {
        public int ID { get; set; }
        public string BlendName { get; set; }
        public ICollection<CoffeeBlend>? CoffeeBlends { get; set; }

    }
}
