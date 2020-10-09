using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApplication.BusinessLayer
{
    public class OperationManager
    {
		private static OperationManager singleton;

		private OperationManager()
		{

		}

		public static OperationManager Instance
		{
			get
			{
				if(singleton == null)
				{
					singleton = new OperationManager();
				}

				return singleton;
			}
			
		}

		public OperationResult ExecuteOperation(EfOperation op)
		{
			
			try
			{
				return op.Execute();
			}
			catch (Exception ex)
			{
				var result = new OperationResult();
				result.Errors.Add(ex.Message);
				return result;
			}
		}

	}
}
