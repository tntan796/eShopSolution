using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModel.Catalog.ProductImage
{
    public class ProductImageCreateRequest
    {
        public string Caption { set; get; }
        public bool IsDefault { set; get; }
        public int SortOrder { set; get; }
        public IFormFile FileImage { set; get; }
    }
}
