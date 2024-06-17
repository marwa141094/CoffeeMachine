using FluentAssertions;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class IngredientTest
    {
        [Fact]
        public void Constructor()
        {
            var ingredient = new Ingredient();

            ingredient.Name.Should().BeNullOrEmpty();
            ingredient.PricePerDose.Should().Be(0);
        }

        [Fact]
        public void Name_ValueChanged()
        {
            var ingredient = new Ingredient()
            {
                Name = "nameT",
                PricePerDose = 2,
            };

            ingredient.Name = "nameM";

            ingredient.Name.Should().Be("nameM");
            ingredient.PricePerDose.Should().Be(2);
        }

        [Fact]
        public void PricePerDose_ValueChanged()
        {
            var ingredient = new Ingredient()
            {
                Name = "nameT",
                PricePerDose = 2,
            };

            ingredient.PricePerDose = 4;

            ingredient.Name.Should().Be("nameT");
            ingredient.PricePerDose.Should().Be(4);
        }
    }
}
