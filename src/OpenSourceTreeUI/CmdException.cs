using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OpenSourceTreeUI
{
	public class CmdException : Exception
	{
		public CmdException(string message = null) : base(message) { }

		public string command { get; set; }
	}
}
