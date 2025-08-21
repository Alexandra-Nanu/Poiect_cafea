namespace Poiect_cafea.Models
{
    public class Producer
    {
        public int ID { get; set; }
        public string ProducerName { get; set; }
        public ICollection<Coffee>? Coffees { get; set; }
    }
}
