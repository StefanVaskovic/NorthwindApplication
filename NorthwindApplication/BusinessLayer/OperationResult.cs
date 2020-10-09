using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApplication.BusinessLayer
{
    public class OperationResult
    {
        public bool IsSuccessful => !Errors.Any();
        public IEnumerable<Dto> Data { get; set; } = new List<Dto>();
        public List<string> Errors { get; set; } = new List<string>();
    }
}
