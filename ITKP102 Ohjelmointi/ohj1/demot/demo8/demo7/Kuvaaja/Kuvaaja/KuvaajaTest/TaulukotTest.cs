using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo7;

namespace TestDemo7
{
	[TestClass()]
	public  class TestTaulukot
	{
		[TestMethod()]
		public  void testSumma26()
		{
			double[,] mat1 = { { 1, 2, 3 }, { 2, 2, 2 }, { 4, 2, 3 } };
			double[,] mat2 = { { 9, 2, 8 }, { 1, 2, 5 }, { 3, 19, -3 } };
			double[,] mat23 = { { 1, 2, 3 }, { 2, 2, 2 } };
			double[,] mat32 = { { 9, 2 }, { 1, 2 }, { 3, 19 } };
			double[,] mat = Taulukot.Summa(mat1, mat2);
			Assert.AreEqual( "10 4 11,3 4 7,7 21 0", Demo6.Matriisit.Jonoksi(mat," ","{0}",",") , "in method Summa, line 32");
			mat = Taulukot.Summa(mat23, mat32);
			Assert.AreEqual( "10 4,3 4", Demo6.Matriisit.Jonoksi(mat," ","{0}",",") , "in method Summa, line 34");
		}
		[TestMethod()]
		public  void testErotaLuvut57()
		{
			double[] luvut = Taulukot.ErotaLuvut("2 3 4 5 k      9 ;5");
			Assert.AreEqual( "2 3 4 5 0 9 5", String.Join(" ",luvut) , "in method ErotaLuvut, line 59");
		}
		[TestMethod()]
		public  void testLaskeKirjaimet81()
		{
			Assert.AreEqual( 2, Taulukot.LaskeKirjaimet("kissa",'s') , "in method LaskeKirjaimet, line 82");
			Assert.AreEqual( 1, Taulukot.LaskeKirjaimet("kissa",'k') , "in method LaskeKirjaimet, line 83");
			Assert.AreEqual( 0, Taulukot.LaskeKirjaimet("kissa",'K') , "in method LaskeKirjaimet, line 84");
		}
		[TestMethod()]
		public  void testErotaDouble105()
		{
			Assert.AreEqual( 0.0, Taulukot.ErotaDouble("") , 0.000001, "in method ErotaDouble, line 106");
			Assert.AreEqual( 2.3, Taulukot.ErotaDouble(" 2.3 ") , 0.000001, "in method ErotaDouble, line 107");
			Assert.AreEqual( 5, Taulukot.ErotaDouble("5 3") , 0.000001, "in method ErotaDouble, line 108");
			Assert.AreEqual( 5, Taulukot.ErotaDouble("5k3") , 0.000001, "in method ErotaDouble, line 109");
			Assert.AreEqual( 5000, Taulukot.ErotaDouble("5e3") , 0.000001, "in method ErotaDouble, line 110");
			Assert.AreEqual( 0.005, Taulukot.ErotaDouble("5E-3") , 0.000001, "in method ErotaDouble, line 111");
			Assert.AreEqual( 0.0, Taulukot.ErotaDouble("k") , 0.000001, "in method ErotaDouble, line 112");
			Assert.AreEqual( 1.0, Taulukot.ErotaDouble("k",1.0) , 0.000001, "in method ErotaDouble, line 113");
			Assert.AreEqual( 0.0, Taulukot.ErotaDouble("2..3") , 0.000001, "in method ErotaDouble, line 114");
		}
		[TestMethod()]
		public  void testErota136()
		{
			Assert.AreEqual( 0.0, Taulukot.Erota("",0.0) , 0.000001, "in method Erota, line 137");
			Assert.AreEqual( 2.3, Taulukot.Erota(" 2.3 ",0.0) , 0.000001, "in method Erota, line 138");
			Assert.AreEqual( 5, Taulukot.Erota("5 3",0.0) , 0.000001, "in method Erota, line 139");
			Assert.AreEqual( 0.0, Taulukot.Erota("k",0.0) , 0.000001, "in method Erota, line 140");
			Assert.AreEqual( 1.0, Taulukot.Erota("k",1.0) , 0.000001, "in method Erota, line 141");
			Assert.AreEqual( 0.0, Taulukot.Erota("2..3",0.0) , 0.000001, "in method Erota, line 142");
		}
	}
}

