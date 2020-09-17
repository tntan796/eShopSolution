﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Catalog.Products.Dtos.Manager
{
    public class ProductUpdateRequest
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { set; get; }
        public string LanguageId { set; get; }
    }
}
