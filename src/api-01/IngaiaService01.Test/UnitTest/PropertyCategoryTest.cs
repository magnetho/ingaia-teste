using System;
using System.Net;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using IngaiaService01.Api.Controllers;
using IngaiaService01.Data;
using IngaiaService01.Domain;
using Xunit;


namespace IngaiaService01.Test.UnitTest
{
    [Trait("Category", "Unit")]
    public class PropertyCategoryTest
    {
     

        public  PropertyCategoryTest()
        {
            _faker = new Faker();
        }
     

        private readonly Faker _faker;


        [Fact]
        public void ConstructorShoulCreateValid()
        {
            var expectedName = _faker.Random.String();
            var expectedValue = _faker.Random.Double();

            var propertyCategory = new PropertyCategory(expectedValue, expectedName);

            Assert.Equal(expectedName, propertyCategory.Name);
            Assert.Equal(expectedName, propertyCategory.Name);

        }

        
        [Fact]
        public void DefaultValueValid()
        {
            var expectedName = _faker.Random.String();
            var expectedValue = _faker.Random.Double();

            var propertyCategoryData = new PropertyCategoryData();
            var propertyCategory = new PropertyCategory(expectedValue, expectedName);
            propertyCategoryData.SetDefaultValue(propertyCategory);

            Assert.Equal(expectedName, propertyCategoryData.GeDefaultValue().Name);
            Assert.Equal(expectedValue, propertyCategoryData.GeDefaultValue().Value);           



        }



    }
}