using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo5;

namespace TestDemo5
{
	[TestClass()]
	public  class TestSopulit
	{
		[TestMethod()]
		public  void testJonoksi48()
		{
			int[,] luvut = {{1,2,3},{4,5,6},{7,8,9}};
			Assert.AreEqual( "1 2 3\n4 5 6\n7 8 9", Sopulit.Jonoksi(luvut) , "in method Jonoksi, line 50");
			Assert.AreEqual( "1 2 3,4 5 6,7 8 9", Sopulit.Jonoksi(luvut," ",",") , "in method Jonoksi, line 51");
			Assert.AreEqual( "[ 1:2:3 ]|[ 4:5:6 ]|[ 7:8:9 ]", Sopulit.Jonoksi(luvut,":","|","[ {0} ]") , "in method Jonoksi, line 52");
		}
		[TestMethod()]
		public  void testMuodostaUusiSukupolvi83()
		{
			int[,] alku = {
			{ 1,0,1,1 },
			{ 0,1,1,0 },
			{ 1,0,0,0 },
			{ 1,0,0,1 }
			};
			int[,] seuraava;
			seuraava = Sopulit.MuodostaUusiSukupolvi(alku);
			Assert.AreEqual( "0 0 1 1,1 0 1 1,1 0 1 0,0 0 0 0", Sopulit.Jonoksi(seuraava," ",",") , "in method MuodostaUusiSukupolvi, line 92");
			seuraava = Sopulit.MuodostaUusiSukupolvi(seuraava);
			Assert.AreEqual( "0 1 1 1,0 0 0 0,0 0 1 1,0 0 0 0", Sopulit.Jonoksi(seuraava," ",",") , "in method MuodostaUusiSukupolvi, line 94");
			seuraava = Sopulit.MuodostaUusiSukupolvi(seuraava);
			Assert.AreEqual( "0 0 1 0,0 1 0 0,0 0 0 0,0 0 0 0", Sopulit.Jonoksi(seuraava," ",",") , "in method MuodostaUusiSukupolvi, line 96");
		}
		[TestMethod()]
		public  void testSeuraavaSukupolvi117()
		{
			int[,] vaihe = {
			{ 1,0,1,1 },
			{ 0,1,1,0 },
			{ 1,0,0,0 },
			{ 1,0,0,1 }
			};
			Sopulit.SeuraavaSukupolvi(vaihe);
			Assert.AreEqual( "0 1 0 0,1 0 0 0,1 1 0 0,1 1 1 0", Sopulit.Jonoksi(vaihe," ",",") , "in method SeuraavaSukupolvi, line 125");
			Sopulit.SeuraavaSukupolvi(vaihe);
			Assert.AreEqual( "0 0 0 0,1 1 0 0,0 0 1 0,0 1 1 0", Sopulit.Jonoksi(vaihe," ",",") , "in method SeuraavaSukupolvi, line 127");
			Sopulit.SeuraavaSukupolvi(vaihe);
			Assert.AreEqual( "0 0 0 0,0 0 0 0,0 1 1 0,0 1 1 0", Sopulit.Jonoksi(vaihe," ",",") , "in method SeuraavaSukupolvi, line 129");
		}
		[TestMethod()]
		public  void testLaskeNaapurit160()
		{
			int[,] alku = {
			{ 1,0,1,1 },
			{ 0,1,1,0 },
			{ 1,0,0,0 },
			{ 2,0,0,0 }
			};
			Assert.AreEqual( 1, Sopulit.LaskeNaapurit(alku,0,0) , "in method LaskeNaapurit, line 167");
			Assert.AreEqual( 1, Sopulit.LaskeNaapurit(alku,3,0) , "in method LaskeNaapurit, line 168");
			Assert.AreEqual( 4, Sopulit.LaskeNaapurit(alku,0,1) , "in method LaskeNaapurit, line 169");
			Assert.AreEqual( 2, Sopulit.LaskeNaapurit(alku,2,2) , "in method LaskeNaapurit, line 170");
			Assert.AreEqual( 0, Sopulit.LaskeNaapurit(alku,3,2) , "in method LaskeNaapurit, line 171");
		}
		[TestMethod()]
		public  void testArvo196()
		{
			int[,] luvut = new int[3,3];
			Sopulit.Arvo(luvut,4,8);
			foreach (int luku in luvut)
			Assert.AreEqual( true, 4 <= luku && luku <= 8 , "in method Arvo, line 200");
		}
		[TestMethod()]
		public  void testTayta220()
		{
			int[,] luvut = new int[3,3];
			Sopulit.Tayta(luvut,7);
			foreach (int luku in luvut)
			Assert.AreEqual( 7, luku , "in method Tayta, line 224");
			Sopulit.Tayta(luvut,2);
			foreach (int luku in luvut)
			Assert.AreEqual( 2, luku , "in method Tayta, line 227");
		}
	}
}

