using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass()]
	public  class TestSopulit2
	{
		[TestMethod()]
		public  void testSeuraavaSukupolvi38()
		{
			int[,] vaihe = {
			{ 1,0,1,1 },
			{ 0,1,1,0 },
			{ 1,0,0,0 },
			{ 1,0,0,1 }
			};
			Sopulit2.SeuraavaSukupolvi(vaihe);
			Assert.AreEqual( "0 1 0 0,1 0 0 0,1 1 0 0,1 1 1 0", Demo5.Sopulit.Jonoksi(vaihe," ",",") , "in method SeuraavaSukupolvi, line 46");
			Sopulit2.SeuraavaSukupolvi(vaihe);
			Assert.AreEqual( "0 0 0 0,1 1 0 0,0 0 1 0,0 1 1 0", Demo5.Sopulit.Jonoksi(vaihe," ",",") , "in method SeuraavaSukupolvi, line 48");
			Sopulit2.SeuraavaSukupolvi(vaihe);
			Assert.AreEqual( "0 0 0 0,0 0 0 0,0 1 1 0,0 1 1 0", Demo5.Sopulit.Jonoksi(vaihe," ",",") , "in method SeuraavaSukupolvi, line 50");
		}
		[TestMethod()]
		public  void testSeuraavaSukupolviTorus85()
		{
			int[,] s1 = {
			{ 1,0,1,1 },
			{ 0,0,0,0 },
			{ 1,0,0,0 },
			{ 1,0,0,1 }
			};
			int[,] s2 = new int[4,4];
			int[,] b02s1 = { {1,0,1,0,0,0,0,0,0},
			{0,1,0,0,0,0,0,0,0}
			};
			Sopulit2.SeuraavaSukupolviTorus(s1,s2,b02s1);
			Assert.AreEqual( "0 0 0 0,0 0 1 0,0 1 0 0,0 0 0 0", Demo5.Sopulit.Jonoksi(s2," ",",") , "in method SeuraavaSukupolviTorus, line 98");
			Sopulit2.SeuraavaSukupolviTorus(s2,s1,b02s1);
			Assert.AreEqual( "1 0 0 0,0 1 1 0,0 1 1 0,0 0 0 1", Demo5.Sopulit.Jonoksi(s1," ",",") , "in method SeuraavaSukupolviTorus, line 100");
			Sopulit2.SeuraavaSukupolviTorus(s1,s2,b02s1);
			Assert.AreEqual( "0 0 0 0,0 0 0 0,0 0 0 0,0 0 0 0", Demo5.Sopulit.Jonoksi(s2," ",",") , "in method SeuraavaSukupolviTorus, line 102");
			Sopulit2.SeuraavaSukupolviTorus(s2,s1,b02s1);
			Assert.AreEqual( "1 1 1 1,1 1 1 1,1 1 1 1,1 1 1 1", Demo5.Sopulit.Jonoksi(s1," ",",") , "in method SeuraavaSukupolviTorus, line 104");
		}
		[TestMethod()]
		public  void testLaskeNaapurit134()
		{
			int[,] alku = {
			{ 1,0,1,1,0 },
			{ 0,1,1,0,0 },
			{ 1,0,0,0,0 },
			{ 1,0,0,0,0 }
			};
			Assert.AreEqual( 1, Sopulit2.LaskeNaapurit(alku,0,0) , "in method LaskeNaapurit, line 141");
			Assert.AreEqual( 1, Sopulit2.LaskeNaapurit(alku,3,0) , "in method LaskeNaapurit, line 142");
			Assert.AreEqual( 4, Sopulit2.LaskeNaapurit(alku,0,1) , "in method LaskeNaapurit, line 143");
			Assert.AreEqual( 2, Sopulit2.LaskeNaapurit(alku,2,2) , "in method LaskeNaapurit, line 144");
			Assert.AreEqual( 0, Sopulit2.LaskeNaapurit(alku,3,2) , "in method LaskeNaapurit, line 145");
		}
		[TestMethod()]
		public  void testLaskeNaapuritTorus178()
		{
			int[,] alku = {
			{ 1,0,1,1 },
			{ 0,1,1,0 },
			{ 1,0,0,0 },
			{ 1,0,0,0 }
			};
			Assert.AreEqual( 3, Sopulit2.LaskeNaapuritTorus(alku,0,0) , "in method LaskeNaapuritTorus, line 185");
			Assert.AreEqual( 3, Sopulit2.LaskeNaapuritTorus(alku,3,0) , "in method LaskeNaapuritTorus, line 186");
			Assert.AreEqual( 5, Sopulit2.LaskeNaapuritTorus(alku,0,1) , "in method LaskeNaapuritTorus, line 187");
			Assert.AreEqual( 2, Sopulit2.LaskeNaapuritTorus(alku,2,2) , "in method LaskeNaapuritTorus, line 188");
			Assert.AreEqual( 2, Sopulit2.LaskeNaapuritTorus(alku,3,2) , "in method LaskeNaapuritTorus, line 189");
		}
	}

