using eShopSolution.ViewModel.Common;
using System.Collections.Generic;

namespace eShopSolution.ViewModel.Catalog.Products
{
    public class GetManageProductPagingRequest: PagingRequestBase
    {
        public string Keyword { set; get; }
        public List<int> CategoryIds { set; get; }
    }
}
