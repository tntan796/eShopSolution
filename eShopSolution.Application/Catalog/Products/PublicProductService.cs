using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Public;
using eShopSolution.Application.Dtos;
using eShopSolution.Data.EF;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eShopSolution.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly EShopDbContext _context;
        public PublicProductService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryById(GetProductPagingRequest request)
        {
            // 1. Select Join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations
                            on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories
                            on p.Id equals pic.ProductId
                        join c in _context.Categories
                            on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            // 2. Filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0) 
            {
                query = query.Where(t => t.pic.CategoryId == request.CategoryId);
            }

            // 3. Paging
            int totalRow = await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(t => new ProductViewModel()
                {
                    Id = t.p.Id,
                    Name = t.pt.Name,
                    DateCreated = t.p.DateCreated,
                    Description = t.pt.Description,
                    Details = t.pt.Details,
                    LanguageId = t.pt.LanguageId,
                    OriginalPrice = t.p.OriginalPrice,
                    Price = t.p.Price,
                    SeoAlias = t.pt.SeoAlias,
                    SeoDescription = t.pt.SeoDescription,
                    SeoTitle = t.pt.SeoTitle,
                    Stock = t.p.Stock,
                    ViewCount = t.p.ViewCount
                });

            // 4. Select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = await data.ToListAsync()
            };
            return pagedResult;
        }
    }
}
