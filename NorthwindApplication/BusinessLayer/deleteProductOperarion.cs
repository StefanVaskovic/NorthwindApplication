using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApplication.BusinessLayer
{
    public class deleteProductOperarion:EfOperation
    {
        private List<int> _idsToDelete;

        public deleteProductOperarion(List<int> idsToDelete)
        {
            _idsToDelete = idsToDelete;
        }

        public override OperationResult Execute()
        {
            var result = new OperationResult();

            foreach (var id in _idsToDelete)
            {
                var product = Context.Products.Find(id);
                Context.Products.Remove(product);
            }
            Context.SaveChanges();

            return result;
        }
    }
}
