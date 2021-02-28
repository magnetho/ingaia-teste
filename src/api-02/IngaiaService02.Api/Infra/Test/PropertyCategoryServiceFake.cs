using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IngaiaService02.Domain;

namespace IngaiaService02.Api.Infra.Test
{
    public class PropertyCategoryServiceFake:IPropertyCategoryService
    {
        public async Task<double> GetDefaultValueAsync()
        {    
            await Task.Delay(1);
            return 100;
        }
    }
}
