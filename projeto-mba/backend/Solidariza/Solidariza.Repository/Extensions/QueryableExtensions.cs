using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Solidariza.Repository.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int page, int pageSize)
        {
            if (page <= 0) page = 1;

            if (pageSize <= 0) pageSize = 10;

            var data = query.Skip((page - 1) * pageSize).Take(pageSize);
            return data;
        }

        public static IOrderedQueryable<T> OrderBySort<T>(this IQueryable<T> query, Dictionary<string, Expression<Func<T, object>>> includes, string sort, string orderby)
        {
            if (!string.IsNullOrEmpty(sort))
                if (includes.TryGetValue(sort, out var expression))
                {
                    if (orderby == "asc") return query.OrderBy(expression);

                    if (orderby == "desc") return query.OrderByDescending(expression);
                }

            var param = Expression.Parameter(typeof(T));
            var field = Expression.PropertyOrField(param, "DateCreated");
            var exp = Expression.Lambda(field, param);

            var orderBy = Expression.Call(
                typeof(Queryable),
                "OrderByDescending",
                new[] { typeof(T), field.Type },
                query.Expression,
                Expression.Quote(exp));

            return (IOrderedQueryable<T>)query.Provider.CreateQuery<T>(orderBy);
        }
    }
}
