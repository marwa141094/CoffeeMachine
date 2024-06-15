using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public interface ICoffeeMachineManager
    {
        Task<IEnumerable<string>> GetBeveragesAsync();
        Task<decimal?> GetBeveragePriceAsync(string name);
    }
}
