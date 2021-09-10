using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Data
{
    public class SpecificationEvaluator<T> where T : Base
    {
        public static IQueryable<T> GetQuery(IQueryable<T> input, ISpecification<T> spec)
        {
            if (spec.Criteria != null)
            {
                input = input.Where(spec.Criteria);
            }

            input = spec.Includes.Aggregate(input, (current, include) => current.Include(include));

            return input;
        }
    }
}