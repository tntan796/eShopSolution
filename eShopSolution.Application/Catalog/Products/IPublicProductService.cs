using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Public;
using eShopSolution.Application.Dtos;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public PagedResult<ProductViewModel> GetAllByCategoryById(GetProductPagingRequest request);
    }
}
