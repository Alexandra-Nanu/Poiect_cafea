namespace Poiect_cafea.Models
{
    public class CoffeeData
    {
        public IEnumerable<Coffee> Coffees { get; set; }
        public IEnumerable<Blend> Blends { get; set; }
        public IEnumerable<CoffeeBlend> CoffeeBlends { get; set; }
    }
}
