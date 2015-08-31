using System;
using System.Collections.Generic;
using System.Linq;

namespace UserGroup.Models
{
    public class PagedListViewModel<T> where T : Entity
    {
        public PagedListViewModel(IQueryable<T> items, int pageSize = 10, int page = 0)
        {
            PageSize = pageSize;
            Page = page;
            TotalCount = items.Count();
            TotalPages = (int)Math.Ceiling((double)TotalCount / pageSize);
            Items = items.Skip(page*pageSize).Take(pageSize).ToList();
        }
        public IEnumerable<T> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}