namespace Poiect_cafea.Models
{
    public class CoffeeBlend
    {
        public int ID { get; set; }
        public int CoffeeID { get; set; }
        public Coffee Coffee { get; set; }
        public int BlendID { get; set; }
        public Blend Blend { get; set; }
    }
}
