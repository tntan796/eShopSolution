using eShopSolution.Data.Entities;
using eShopSolution.ViewModel.Catalog.ProductImage;
using eShopSolution.ViewModel.Catalog.Products;
using eShopSolution.ViewModel.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<ProductViewModel> GetProductById(int productId, string languageId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task AddViewCount(int productId);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task<int> AddImage(int productId, ProductImageCreateRequest productImage);
        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest productImage);
        Task<int> RemoveImage(int imageId);
        Task<ProductImageViewModel> GetProductImageById(int productId, int imageId);
        Task<List<ProductImageViewModel>> GetListImages(int productId);
    }
}
