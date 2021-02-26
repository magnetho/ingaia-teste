using System;
using System.Collections.Generic;
using System.Text;

namespace IngaiaService01.Domain
{
    public class PropertyCategory
    {
        /// <summary>
        /// Valor da metro quadrado para a categoria de imóveis 
        /// </summary>        
        public double Value { get; }
        /// <summary>
        /// Nome da categoria de imóveis
        /// </summary>
        public string Name { get; }

        public PropertyCategory(double Value, string name)
        {

            this.Name = name;
            this.Value = Value;
        }

    }
}
