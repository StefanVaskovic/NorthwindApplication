using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApplication.BusinessLayer
{
    public class updateProductOperation : EfOperation
    {
        private ProductsDto _dto;

        public updateProductOperation(ProductsDto dto)
        {
            _dto = dto;
        }

        public override OperationResult Execute()
        {
            var product = Context.Products.Find(_dto.Id);

            product.SupplierID = _dto.SupplierId;
            product.ProductName = _dto.Name;

            Context.SaveChanges();

            return new OperationResult();
        }
    }
}
