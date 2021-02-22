using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specs)
        {
            var query = inputQuery;

            if(specs.Criteria != null)
            {
                query = query.Where(specs.Criteria); //could be something like p => p.ProductId == id
            }

            query = specs.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
