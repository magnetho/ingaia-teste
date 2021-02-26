
using IngaiaService01.Data;
using IngaiaService01.Domain;
using Microsoft.AspNetCore.Mvc;


namespace IngaiaService01.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyCategoryController : ControllerBase
    {


       public PropertyCategoryController(IPropertyCategoryData propertyCategory)
        {
            PropertyCategory = propertyCategory;
        }

        private IPropertyCategoryData PropertyCategory { get; }
        /// <summary>
        /// Busca a  categoria de imovel padrão assim como o valor do m2.
        /// </summary>
        /// <returns>Retorna uma descrição e o valor do m2 da categoria padrão</returns>

        [HttpGet("default")]
        public PropertyCategory Get()
        {
            return PropertyCategory.GeDefaultValue();
        }
    }
}
