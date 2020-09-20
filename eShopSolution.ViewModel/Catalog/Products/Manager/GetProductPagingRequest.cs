using eShopSolution.ViewModel.Common;
using System.Collections.Generic;

namespace eShopSolution.ViewModel.Catalog.Products.Manager
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { set; get; }
    }
}
