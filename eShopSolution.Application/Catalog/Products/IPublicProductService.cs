using eShopSolution.ViewModel.Catalog.Products;
using eShopSolution.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public Task<PagedResult<ProductViewModel>> GetAllByCategoryById(string languageId, GetPublicProductPagingRequest request);
        public Task<List<ProductViewModel>> GetAll(string languageId);
    }
}
