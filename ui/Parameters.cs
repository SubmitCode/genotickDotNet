using System;
using System.Collections.Generic;

namespace com.alphatica.genotick.ui
{


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("SameParameterValue") public class Parameters
	public class Parameters
	{
		private readonly IDictionary<string, string> map = new Dictionary<string, string>();
		public Parameters(string[] args)
		{
			foreach (string arg in args)
			{
				string key = parseKey(arg);
				string value = parseValue(arg);
				map[key] = value;
			}
		}

		private string parseValue(string arg)
		{
			int eqPos = arg.IndexOf("=", StringComparison.Ordinal);
			if (eqPos >= 0)
			{
				return arg.Substring(eqPos + 1, arg.Length - (eqPos + 1));
			}
			else
			{
				return arg;
			}
		}

		private string parseKey(string arg)
		{
			int eqPos = arg.IndexOf("=", StringComparison.Ordinal);
			if (eqPos >= 0)
			{
				return arg.Substring(0,eqPos);
			}
			else
			{
				return arg;
			}
		}

		public virtual string getValue(string key)
		{
			return map[key];
		}

		public virtual void removeKey(string key)
		{
			map.Remove(key);
		}

		public virtual bool allConsumed()
		{
			return map.Count == 0;
		}

		public virtual ICollection<string> Unconsumed
		{
			get
			{
				return map.Values;
			}
		}
	}

}