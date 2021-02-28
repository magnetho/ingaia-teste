using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IngaiaService02.Api.Infra.Test;
using IngaiaService02.Domain;
using Xunit;

namespace IngaiaService02.Test.UnitTest
{

    [Trait("Category", "Unit")]
    public class CalculatePropertyValueTest
    {
        public CalculatePropertyValueTest()
        {
            _calculatePropertyValue = new CalculatePropertyValue(new PropertyCategoryServiceFake());

        }

        private readonly  CalculatePropertyValue _calculatePropertyValue;

        [Theory(DisplayName = "Calcula valor do imovel com sucesso ")]
        [InlineData(10)]
        [InlineData(900)]
        public async Task CalculatePropertyValueSucess(double meter)
        {

            var result = await _calculatePropertyValue.CalculateAsync(meter);

            Assert.IsType<PropertyResult>(result);
            Assert.Equal(meter,result.Meter);


        }


        [Theory(DisplayName = "Calcula valor do imovel com falha ")]
        [InlineData(9)]
        [InlineData(12000)]
        public async Task CalculatePropertyValueFail(double meter)
        {

            bool isSuccess = true;
            try
            {
                var result = await _calculatePropertyValue.CalculateAsync(meter);
                isSuccess = true;

            }
            catch (Exception  exception)
            {
                isSuccess = false;
                Assert.Contains("Valor informado inválido! envie algo entre 10 e 1000", exception.Message);
            }
            
            Assert.False(isSuccess);
            

        }


    }
}
