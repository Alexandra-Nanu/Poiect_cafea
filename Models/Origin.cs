namespace Poiect_cafea.Models
{
    public class Origin
    {
        public int ID { get; set; }
        public string OriginName { get; set; }
        public ICollection<Coffee>? Coffees { get; set; }
    }
}
