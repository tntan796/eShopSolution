using System.Collections.Generic;

namespace eShopSolution.Application.Dtos
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecord { set; get; }
    }
}
