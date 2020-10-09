using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindApplication.DataLayer;

namespace NorthwindApplication.BusinessLayer
{
    public class insertProductOperation : EfOperation
    {
        private AddProductDto _dto;

        public insertProductOperation(AddProductDto dto)
        {
            // provera
            _dto = dto;
        }

        public override OperationResult Execute()
        {
            Context.Products.Add(new Products 
            {
                ProductName = _dto.Name,
                CategoryID = _dto.CategoryId,
                SupplierID = _dto.SupplierId,
                Discontinued =_dto.Discountinued
            });

            Context.SaveChanges();

            return new OperationResult();
        }
    }
}
