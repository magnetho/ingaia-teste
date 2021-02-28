using System.Threading.Tasks;

namespace IngaiaService02.Domain
{
    public interface IPropertyCategoryService
    {
        Task<double> GetDefaultValueAsync();
    }
}