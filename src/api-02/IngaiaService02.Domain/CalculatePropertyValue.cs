using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IngaiaService02.Domain
{
    public class CalculatePropertyValue : ICalculatePropertyValue
    {

        public CalculatePropertyValue(IPropertyCategoryService propertyCategoryService)
        {
            this.propertyCategoryService = propertyCategoryService;
        }

        public readonly IPropertyCategoryService propertyCategoryService;

        /// <summary>
        /// Calcula o valor de um imovel 
        /// </summary>
        /// <param name="meter">Quantidade de metros quadrados de um imovel</param>
        /// <returns>Retorna objeto com o valor do imovel, quantidade de metros quadrado e o valor do metro quadrado </returns>

        public async Task<PropertyResult> CalculateAsync(double meter)
        {
            if (meter >= 10 && meter <= 10000)
            {
                var defaultValue = await propertyCategoryService.GetDefaultValueAsync();

                return new PropertyResult(meter, defaultValue);

            }

            throw new Exception("Valor informado inválido! envie algo entre 10 e 10000");


        }



    }
}
