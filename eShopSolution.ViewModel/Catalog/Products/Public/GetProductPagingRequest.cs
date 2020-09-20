using eShopSolution.ViewModel.Common;

namespace eShopSolution.ViewModel.Catalog.Products.Public
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { set; get; }
    }
}
