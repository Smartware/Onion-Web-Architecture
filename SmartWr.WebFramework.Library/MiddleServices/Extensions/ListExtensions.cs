using SmartWr.WebFramework.Library.MiddleServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.MiddleServices.Extensions
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ListExtensions
    {
        public static PaginatedList<T> ToPaginatedList<T>(this IList<T> list, int pageIndex, int pageSize, int total)
        {
            return new PaginatedList<T>(list, pageIndex, pageSize, total);
        }
    }
}
