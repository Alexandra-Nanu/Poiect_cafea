using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poiect_cafea.Models
{
    public class Coffee
    {
        public int ID { get; set; }

        [Display(Name = "Coffee Name")]
        public string Name { get; set; }

        public int? OriginID { get; set; }
        public Origin? Origin { get; set; }

        [Column(TypeName ="decimal(6,2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        public int? ProducerID { get; set; }
        public Producer? Producer { get; set; }

        public ICollection<CoffeeBlend>? CoffeeBlends { get; set; }

        public ICollection<Order>? Orders { get; set; }

    }
}
