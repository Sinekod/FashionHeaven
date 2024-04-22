using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Core.Models
{
    public class PeginatedList<T>
    {
        public PeginatedList(List<T> items, int count , int pageIndex, int pageSize)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages =(int)Math.Ceiling(count/(double)pageSize);
        }

        public List<T> Items { get; set; }

        public  int TotalItems { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage => (PageIndex > 1);

        public bool HasNextPage => (PageIndex < TotalPages);

        public int FirstItemIndex => (PageIndex - 1) * PageSize + 1;

        public int LastItemIndex => Math.Min(PageIndex * PageSize,TotalItems);

        public static async Task<PeginatedList<T>> CreateAsync(IQueryable <T> sourse ,int pageIndex,int pageSize)
        {
            var count = await sourse.CountAsync();
            var items = await sourse.Skip((pageIndex-1)*pageSize).Take(pageSize).ToListAsync();
            return new PeginatedList<T>(items,count,pageIndex,pageSize);
        }



    }
}
