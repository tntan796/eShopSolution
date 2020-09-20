using eShopSolution.ViewModel.Catalog.Products;
using eShopSolution.ViewModel.Catalog.Products.Public;
using eShopSolution.ViewModel.Common;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public Task<PagedResult<ProductViewModel>> GetAllByCategoryById(GetProductPagingRequest request);
    }
}
