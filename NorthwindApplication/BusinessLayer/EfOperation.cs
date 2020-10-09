using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindApplication.DataLayer;

namespace NorthwindApplication.BusinessLayer
{
    public abstract class EfOperation : Operation
    {
        private NorthwindEntities context = new NorthwindEntities();
        public NorthwindEntities Context => context;
    }
}
