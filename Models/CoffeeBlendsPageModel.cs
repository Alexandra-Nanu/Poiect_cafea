using Microsoft.AspNetCore.Mvc.RazorPages;
using Poiect_cafea.Data;

namespace Poiect_cafea.Models
{
    public class CoffeeBlendsPageModel:PageModel
    {
        public List<AssignedBlendData> AssignedBlendDataList;

        public void PopulateAssignedBlendData(Poiect_cafeaContext context, Coffee coffee)
        {
            var allBlends = context.Blend;
            var coffeeBlends = new HashSet<int>(
                coffee.CoffeeBlends.Select(b => b.BlendID)); 
            AssignedBlendDataList = new List<AssignedBlendData>();
            foreach (var ble in allBlends)
            {
                AssignedBlendDataList.Add(new AssignedBlendData
                {
                    BlendID = ble.ID,
                    Name = ble.BlendName,
                    Assigned = coffeeBlends.Contains(ble.ID)
                });
            }
        }

        public void UpdateCoffeeBlends(Poiect_cafeaContext context, string[] selectedBlends, Coffee coffeeToUpdate)
        {
            if (selectedBlends == null)
            {
                coffeeToUpdate.CoffeeBlends = new List<CoffeeBlend>();
                return;
            }

            var selectedBlendsHS = new HashSet<string>(selectedBlends);
            var coffeeBlends = new HashSet<int>(coffeeToUpdate.CoffeeBlends.Select(b => b.BlendID));
            foreach (var ble in context.Blend)
            {
                if (selectedBlendsHS.Contains(ble.ID.ToString()))
                {
                    if (!coffeeBlends.Contains(ble.ID))
                    {
                        coffeeToUpdate.CoffeeBlends.Add(
                            new CoffeeBlend
                            {
                                CoffeeID = coffeeToUpdate.ID,
                                BlendID = ble.ID
                            });
                    }
                }
                else
                {
                    if (coffeeBlends.Contains(ble.ID))
                    {
                        CoffeeBlend coffeeToRemove = coffeeToUpdate
                                .CoffeeBlends
                                .SingleOrDefault(i => i.BlendID == ble.ID);
                        context.Remove(coffeeToRemove);
                    }
                }
            }
        }
    }
}
