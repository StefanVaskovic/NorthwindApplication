using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApplication.BusinessLayer
{
    public class AddProductDto : Dto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public bool Discountinued { get; set; }
    }
}
