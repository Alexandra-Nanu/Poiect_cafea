using System.ComponentModel.DataAnnotations;
namespace Poiect_cafea.Models
{
    public class Order
    {
        public int ID { get; set; }

        public int? ClientID { get; set; }
        public Client? Client { get; set; }

        public int? CoffeeID { get; set; }
        public Coffee? Coffee { get; set; }

        [DataType(DataType.Date)]
        public DateTime ShippingDate { get; set; }
    }

}

