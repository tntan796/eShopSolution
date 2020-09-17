using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Dtos;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public PagedViewModel<ProductViewModel> GetAllByCategoryById(int categoryId, int pageIndex, int pageSize);
    }
}
