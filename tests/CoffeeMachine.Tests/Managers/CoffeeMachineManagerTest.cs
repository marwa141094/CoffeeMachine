using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class CoffeeMachineManagerTest
    {
        [Fact]
        public async Task GetBeveragesAsync()
        {
            var manager = new CoffeeMachineManager();

            var result = await manager.GetBeveragesAsync();

            var expectedList = new List<string>() {
            "Espresso",
            "Lait",
            "Capuccino",
            "Chocolat chaud",
            "Café au lait",
            "Mokaccino",
            "Thé"};

            result.Count().Should().Be(7);
            result.Should().BeEquivalentTo(expectedList);
        }

        [Fact]
        public async Task GetBeveragePriceAsync_CaseNameDoesNotExistInList()
        {
            var manager = new CoffeeMachineManager();

            var result = await manager.GetBeveragePriceAsync("toto");

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetBeveragePriceAsync()
        {
            var manager = new CoffeeMachineManager();

            var result = await manager.GetBeveragePriceAsync("Espresso");

            result.Should().Be((decimal)0.8450);
        }
    }
}
