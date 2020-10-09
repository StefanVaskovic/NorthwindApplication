using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApplication.BusinessLayer
{
    public class getCategoriesOperation : EfOperation
    {
        public override OperationResult Execute()
        {
            var query = Context.Categories.Select(c => new CategoryDto 
            {
                Id = c.CategoryID,
                Name = c.CategoryName
            });

            return new OperationResult
            {
                Data = query.ToList()
            };

        }
    }
}
