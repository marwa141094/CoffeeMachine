using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class Beverage
    {
        public string Name { get; set; }
        public Dictionary<string, int> Ingredients { get; set; }
    }
}
