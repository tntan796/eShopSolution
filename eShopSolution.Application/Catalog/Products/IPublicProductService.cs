using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Public;
using eShopSolution.Application.Dtos;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public Task<PagedResult<ProductViewModel>> GetAllByCategoryById(GetProductPagingRequest request);
    }
}
