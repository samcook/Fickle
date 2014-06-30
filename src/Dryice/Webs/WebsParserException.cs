﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dryice.Webs
{
	public class WebsParserException
		: Exception
	{
		public WebsParserException()
		{
		}

		public WebsParserException(string message)
			: base(message)
		{	
		}
	}
}