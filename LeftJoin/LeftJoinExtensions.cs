using System;
using System.Linq;
using System.Linq.Expressions;

namespace LeftJoin
{
    public static class LeftJoinExtensions
    {
        public static IQueryable<TResult> LeftJoin<TLeft, TRight, TKey, TResult>(
            this IQueryable<TLeft> left, 
            IQueryable<TRight> right,
            Expression<Func<TLeft, TKey>> leftKey,
            Expression<Func<TRight, TKey>> rightKey,
            Func<TLeft, TRight, TResult> resultFunc
            )
        {
            /*
            var query = (
                    from l in left
                    join r in right on leftKey(l) equals rightKey(r)
                    into j1
                    from r1 in j1.DefaultIfEmpty()
                    select resultFunc(l, r1)
                    );
             */
            var query = left
                .GroupJoin(right, leftKey, rightKey, (l, j1) => new {l, j1})
                .SelectMany(t => t.j1.DefaultIfEmpty(), (t, r1) => resultFunc(t.l, r1));
            return query;
        }
    }
}
