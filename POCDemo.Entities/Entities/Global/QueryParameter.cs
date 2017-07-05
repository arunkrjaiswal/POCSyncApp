using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BT.TS360.BLL.Entities.Global
{
    public class QueryParameter<TEntity>
    {
        public FilterDefinition<TEntity> ConditionFilter { get; set; }
        public FilterDefinition<TEntity> PreviewConditionFilter { get; set; }
        public Expression<Func<TEntity, Object>> OrderBy { get; set; }
        public Boolean Ascending { get; set; }
        public Boolean HasAdName { get; set; }
        public Boolean HasIsDefault { get; set; }
        public Int32 Take { get; set; }
        public Int32 Skip { get; set; }

        public Int32? Limit { get; set; }
    }

    public class SubQueryParameter<T> where T : BaseList
    {
        public List<T> Items { get; set; }
        public Func<T, Boolean> ConditionPageFilter { get; set; }
        public Func<T, Boolean> PreviewConditionFilter { get; set; }
        public Func<T, Object> OrderBy { get; set; }
        public Boolean Ascending { get; set; }
        public Boolean HasAdName { get; set; }
        public Boolean HasIsDefault { get; set; }
    }
}
