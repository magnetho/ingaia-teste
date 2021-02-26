using IngaiaService01.Domain;
using System;

namespace IngaiaService01.Data
{
    public class PropertyCategoryData : IPropertyCategoryData
    {




        private  PropertyCategory propertyCategory = new PropertyCategory(100, "default");
        /// <summary>
        /// Método que busca  a categoria de imoveis  Padrão
        /// </summary>
        /// <returns>Retorna a categoria de imoveis padrão</returns>

        public PropertyCategory GeDefaultValue()
        {
            return propertyCategory;
        }

        /// <summary>
        /// Adiciona o immovel padrão 
        /// </summary>
        /// <param name="propertyCategory">imóvel padrão</param>
        public void  SetDefaultValue(PropertyCategory propertyCategory)
        {
           this.propertyCategory = propertyCategory;
        }



    }
}
