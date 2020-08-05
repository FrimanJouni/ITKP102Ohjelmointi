using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tauno72;

	[TestClass()]
	public  class TestTauno72
	{
		[TestMethod()]
		public  void TestSisatulo45()
		{
			int[,] maski = { {1,1,1},{1,1,0},{0,1,1} };
			int[,] luvut = { {255,34,120,222},{35,50,60,70},{50,90,102,10},{20,34,44,55} };
			Assert.AreEqual( 363, Sisatulo(luvut,maski,2,1) , "in method Sisatulo, line 48");
			Assert.AreEqual( 686, Sisatulo(luvut,maski,1,1) , "in method Sisatulo, line 49");
			Assert.AreEqual( 598, Sisatulo(luvut,maski,1,2) , "in method Sisatulo, line 50");
			Assert.AreEqual( 471, Sisatulo(luvut,maski,2,2) , "in method Sisatulo, line 51");
		}
		[TestMethod()]
		public  void TestSisatulo55()
		{
			int[,] naapurit = { {1,1,1},{1,0,1},{1,1,1} };
			int[,] alkuSukupolvi = {
			{ 1,0,1,1 },
			{ 0,1,1,0 },
			{ 1,0,0,0 },
			{ 1,0,0,1 }
			};
			Assert.AreEqual( 4, Sisatulo(alkuSukupolvi,naapurit,2,1) , "in method Sisatulo, line 63");
			Assert.AreEqual( 4, Sisatulo(alkuSukupolvi,naapurit,1,1) , "in method Sisatulo, line 64");
			Assert.AreEqual( 3, Sisatulo(alkuSukupolvi,naapurit,1,2) , "in method Sisatulo, line 65");
			Assert.AreEqual( 3, Sisatulo(alkuSukupolvi,naapurit,2,2) , "in method Sisatulo, line 66");
		}
	}

