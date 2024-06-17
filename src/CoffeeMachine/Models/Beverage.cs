using System.Collections.Generic;

namespace CoffeeMachine
{
    public class Beverage
    {
        public string Name { get; set; }
        public Dictionary<string, int> Ingredients { get; set; }
    }
}
