using Flurl.Http;
using IngaiaService02.Api.Model;
using IngaiaService02.Domain;
using System;
using System.Threading.Tasks;

namespace IngaiaService02.Api.Infra.Services

{
    public class PropertyCategoryService : IPropertyCategoryService
    {

        public PropertyCategoryService(PropertyCategorySettings propertyCategorySettings)
        {
            this._propertyCategorySettings = propertyCategorySettings;
        }

        private readonly PropertyCategorySettings _propertyCategorySettings;

        /// <summary>
        /// Busca o valor padrão do metro quadrado
        /// </summary>
        /// <returns>Retorna o valor padrão do m2</returns>
        public async Task<double> GetDefaultValueAsync()
        {
            try
            {
                var resultApi = await (_propertyCategorySettings.BaseUrl + "/PropertyCategory/default")
                                          .GetJsonAsync<PropertyCategoryModel>();
                return resultApi.Value;
            }
            catch( Exception ex)
            {

                throw new Exception("Erro Api 01:" + ex.Message);
            }
                    

        }


    }
}
