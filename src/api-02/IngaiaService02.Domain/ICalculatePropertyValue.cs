using System.Threading.Tasks;

namespace IngaiaService02.Domain
{
    public interface ICalculatePropertyValue
    {
        Task<PropertyResult> CalculateAsync(double meter);
    }
}