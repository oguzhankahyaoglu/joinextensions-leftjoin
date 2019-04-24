using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LeftJoin
{
    public static class RightJoinExtensions
    {
        public static IQueryable<TResult> RightJoin<TLeft, TRight, TKey, TResult>(
            this IQueryable<TLeft> left, 
            IQueryable<TRight> right,
            Expression<Func<TLeft, TKey>> leftKey,
            Expression<Func<TRight, TKey>> rightKey,
            Func<TLeft, TRight, TResult> resultFunc
        )
        {
            var query = right.LeftJoin(left, rightKey, leftKey, (i, o) => resultFunc(o, i));
            return query;
        }

    }
}
