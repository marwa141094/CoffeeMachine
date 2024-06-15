using CoffeeMachine;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CoffeeMachineController : ControllerBase
{
    private readonly ICoffeeMachineManager coffeeMachineManager;

    public CoffeeMachineController(ICoffeeMachineManager coffeeMachineManager)
    {
        this.coffeeMachineManager = coffeeMachineManager;
    }

    [HttpGet("beverages")]
    public async Task<ActionResult<IEnumerable<string>>> GetBeverages()
    {
        var beverages = await this.coffeeMachineManager.GetBeveragesAsync();
        return Ok(beverages);
    }

    [HttpGet("beverages/{name}")]
    public async Task<ActionResult<decimal>> GetBeveragePrice(string name)
    {
        var price = await this.coffeeMachineManager.GetBeveragePriceAsync(name);
        if (price == null)
        {
            return NotFound();
        }

        return Ok(price);
    }
}
