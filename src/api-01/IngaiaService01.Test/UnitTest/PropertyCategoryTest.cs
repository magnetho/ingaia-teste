using System;
using Bogus;
using Bogus.Extensions.Brazil;
using IngaiaService01.Api.Controllers;
using IngaiaService01.Data;
using IngaiaService01.Domain;
using Xunit;


namespace IngaiaService01.Test.UnitTest
{
    [Trait("Category", "Unit")]
    public class PropertyCategoryTest
    {

        private readonly Faker faker = new Faker();
        [Fact]
        public void ConstructorShoulCreateValid()
        {
            var expectedName = faker.Random.String();
            var expectedValue = faker.Random.Double();

            var propertycategory = new PropertyCategory(expectedValue, expectedName);

            Assert.Equal(expectedName, propertycategory.Name);
            Assert.Equal(expectedName, propertycategory.Name);

        }



        [Fact]
        public void DefaultValueValid()
        {
            var expectedName = faker.Random.String();
            var expectedValue = faker.Random.Double();

            var propertyCategoryData = new PropertyCategoryData();
            var propertycategory = new PropertyCategory(expectedValue, expectedName);
            propertyCategoryData.SetDefaultValue(propertycategory);
            var propertycategoryController = new PropertyCategoryController(propertyCategoryData);
                                 
            var resultApi =  propertycategoryController.Get();
            Assert.IsType<PropertyCategory>(resultApi);
            Assert.Equal(expectedName, resultApi.Name);
            Assert.Equal(expectedValue, resultApi.Value);           



        }



    }
}