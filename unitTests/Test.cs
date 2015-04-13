using NUnit.Framework;
using System;
using Clicksign;

namespace unitTests
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			var clicksign = new Clicksign.Clicksign();
			var list = clicksign.List();

			Console.WriteLine (list.Count);
		}
	}
}

