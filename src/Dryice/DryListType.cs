﻿using System;

namespace Dryice
{
	public class DryListType
		: DryBaseType
	{
		public Type ListElementType { get; private set; }

		public DryListType(Type listElementType)
			: base("DryListType")
		{
			this.ListElementType = listElementType;
		}
	}
}
