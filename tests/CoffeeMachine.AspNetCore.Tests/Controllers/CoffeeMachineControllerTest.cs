using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeMachine.AspNetCore.Tests
{
    public class CoffeeMachineControllerTest
    {
        [Fact]
        public async Task GetBeveragesAsync()
        {
            var beverages = new List<string>() {
            "Espresso",
            "Lait",
            "Capuccino",
            "Chocolat chaud",
            "Café au lait",
            "Mokaccino",
            "Thé"};

            var manager = new Mock<ICoffeeMachineManager>(MockBehavior.Strict);
            manager.Setup(m => m.GetBeveragesAsync())
                .ReturnsAsync(beverages)
                .Verifiable();

            var controller = new CoffeeMachineController(manager.Object);

            var result = await controller.GetBeveragesAsync() as ObjectResult;

            var beveragesList = (result.Value as IEnumerable<string>).ToList();

            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            beveragesList.Should().BeEquivalentTo(beverages);

            manager.VerifyAll();
        }

        [Fact]
        public async Task GetBeveragePriceAsync_CaseReturnNotFound()
        {
            var manager = new Mock<ICoffeeMachineManager>(MockBehavior.Strict);
            manager.Setup(m => m.GetBeveragePriceAsync("InvalidBeverage"))
                .ReturnsAsync((decimal?)null)
                .Verifiable();

            var controller = new CoffeeMachineController(manager.Object);

            var result = await controller.GetBeveragePriceAsync("InvalidBeverage") as NotFoundResult;
            
            result.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
            manager.VerifyAll();
        }

        [Fact]
        public async Task GetBeveragePriceAsync()
        {
            var manager = new Mock<ICoffeeMachineManager>(MockBehavior.Strict);
            manager.Setup(m => m.GetBeveragePriceAsync("Espresso"))
                .ReturnsAsync((decimal)2.4)
                .Verifiable();

            var controller = new CoffeeMachineController(manager.Object);

            var result = await controller.GetBeveragePriceAsync("Espresso") as ObjectResult;

            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().Be((decimal)2.4);
            manager.VerifyAll();
        }
    }
}
