using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using IngaiaService02.Domain;
using Newtonsoft.Json;
using Xunit;

namespace IngaiaService02.Test.IntegrationTest
{
    [Trait("Category", "integration")]
    public class PropertyValueApiTest
    {

        private readonly TestContext _testContext;

        public PropertyValueApiTest()
        {
            _testContext = new TestContext();
        }


        [Theory(DisplayName = "Calcula valor do imovel ")]
        [InlineData(10)]
        [InlineData(1000)]
        public async Task CalculatePropertyValue(double meter)
        {
            var response = await _testContext.Client.GetAsync($"/PropertyValue/calculate?meter={meter}");
            var content = await  response.Content.ReadAsStringAsync();
            
            var objectResult = JsonConvert.DeserializeObject<PropertyResult>(content);
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
            Assert.NotNull(objectResult);
            Assert.IsType<PropertyResult>(objectResult);
        }


        [Theory(DisplayName = "Não calcula valor do imovel ")]
        [InlineData(5)]
        [InlineData(11000)]
        public async Task NotCalculatePropertyValue(double meter)
        {
            var response = await _testContext.Client.GetAsync($"/PropertyValue/calculate?meter={meter}");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        
        }


    }
}
