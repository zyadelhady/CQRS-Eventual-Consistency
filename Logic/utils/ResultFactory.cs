using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.utils
{
	public static class ResultFactory
	{
		public static Result Fail(string error)
		{
			return new Result(true, error);
		}

		public static Result Ok()  
		{
			return new Result(false, string.Empty);
		}
	}
}
