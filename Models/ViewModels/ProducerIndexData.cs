using Poiect_cafea.Models;
using System.Security.Policy;

namespace Poiect_cafea.Models.ViewModels
{
    public class ProducerIndexData
    {
        public IEnumerable<Producer> Producers{ get; set; }
        public IEnumerable<Coffee> Coffees { get; set; }
    }
}
