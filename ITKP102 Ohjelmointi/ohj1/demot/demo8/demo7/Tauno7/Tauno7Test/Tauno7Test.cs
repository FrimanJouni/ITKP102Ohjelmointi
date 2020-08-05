using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass()]
	public  class TestTauno7
	{
		[TestMethod()]
		public  void testMuutaYli33()
		{
			int[] t = { 72, 22, 73, 2, 16, 62 };
			Assert.AreEqual(Tauno7.MuutaYli(t,20,0) ,  4, "in method MuutaYli, line 35");
			Assert.AreEqual(String.Join(", ", t) ,  "0, 0, 0, 2, 16, 0", "in method MuutaYli, line 36");
		}
	}

