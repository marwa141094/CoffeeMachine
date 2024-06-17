using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class CoffeeMachineManager : ICoffeeMachineManager
    {
        private static readonly List<Ingredient> ingredients = new List<Ingredient>
    {
        new Ingredient { Name = "Lait en poudre", PricePerDose = 0.10m },
        new Ingredient { Name = "Eau", PricePerDose = 0.05m },
        new Ingredient { Name = "Café", PricePerDose = 0.30m },
        new Ingredient { Name = "Chocolat en poudre", PricePerDose = 0.40m },
        new Ingredient { Name = "Thé", PricePerDose = 0.30m }
    };

        private static readonly List<Beverage> beverages = new List<Beverage>
    {
        new Beverage { Name = "Espresso", Ingredients = new Dictionary<string, int> { { "Eau", 1 }, { "Café", 2 } } },
        new Beverage { Name = "Lait", Ingredients = new Dictionary<string, int> { { "Lait en poudre", 2 }, { "Eau", 1 } } },
        new Beverage { Name = "Capuccino", Ingredients = new Dictionary<string, int> { { "Lait en poudre", 2 }, { "Eau", 1 }, { "Café", 1 }, { "Chocolat en poudre", 1 } } },
        new Beverage { Name = "Chocolat chaud", Ingredients = new Dictionary<string, int> { { "Lait en poudre", 3 }, { "Chocolat en poudre", 2 } } },
        new Beverage { Name = "Café au lait", Ingredients = new Dictionary<string, int> { { "Lait en poudre", 1 }, { "Eau", 2 }, { "Café", 1 } } },
        new Beverage { Name = "Mokaccino", Ingredients = new Dictionary<string, int> { { "Lait en poudre", 1 }, { "Eau", 2 }, { "Café", 1 }, { "Chocolat en poudre", 2 } } },
        new Beverage { Name = "Thé", Ingredients = new Dictionary<string, int> { { "Eau", 2 }, { "Thé", 1 } } }
    };

        public Task<IEnumerable<string>> GetBeveragesAsync()
        {
            return Task.FromResult(beverages.Select(b => b.Name));
        }

        public Task<decimal?> GetBeveragePriceAsync(string name)
        {
            var beverage = beverages.FirstOrDefault(b => b.Name.ToLower() == name.ToLower());
            if (beverage == null)
            {
                return Task.FromResult<decimal?>(null); // Indicate that the beverage was not found
            }

            decimal costPrice = 0;
            foreach (var ingredient in beverage.Ingredients)
            {
                var ingredientInfo = ingredients.FirstOrDefault(i => i.Name.ToLower() == ingredient.Key.ToLower());
                if (ingredientInfo != null)
                {
                    costPrice += ingredient.Value * ingredientInfo.PricePerDose;
                }
            }

            decimal sellingPrice = costPrice * 1.30m; // Applying 30% margin
            return Task.FromResult<decimal?>(sellingPrice);
        }
    }
}
