using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidariza.Domain.DTO
{
    public class PagedResultDTO<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
