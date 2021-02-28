using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace IngaiaService01.Test.IntegrationTest
{
    [Trait("Category", "Integration")]
    public class PropertyCategoryApiTest
    {
        public PropertyCategoryApiTest()
        {
            _testContext = new TestContext();
        }
        private readonly TestContext _testContext;

        [Fact]
        public async Task GetDefaultValue()
        {
            var response = await _testContext.Client.GetAsync("/PropertyCategory/default");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);

        }


    }
}
