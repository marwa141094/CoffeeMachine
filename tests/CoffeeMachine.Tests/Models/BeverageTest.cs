using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class BeverageTest
    {
        [Fact]
        public void Constructor()
        {
            var beverage = new Beverage();

            beverage.Name.Should().BeNullOrEmpty();
            beverage.Ingredients.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Name_ValueChanged()
        {
            var dictionnary = new Dictionary<string, int>
            {
                { "key1", 2 }
            };

            var beverage = new Beverage()
            {
                Name = "nameT",
                Ingredients = dictionnary,
            };

            beverage.Name = "nameM";

            beverage.Name.Should().Be("nameM");
            beverage.Ingredients.Count.Should().Be(1);
            beverage.Ingredients["key1"].Should().Be(2);
        }

        [Fact]
        public void Ingredients_ValueChanged()
        {
            var dictionnary = new Dictionary<string, int>
            {
                { "key1", 2 }
            };

            var beverage = new Beverage()
            {
                Name = "nameT",
                Ingredients = dictionnary,
            };

            beverage.Ingredients["key1"] = 3;
            beverage.Name.Should().Be("nameT");
            beverage.Ingredients.Count.Should().Be(1);
            beverage.Ingredients["key1"].Should().Be(3);
        }

    }
}
