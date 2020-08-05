using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;
using Jypeli.WP7;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo7;

namespace TestDemo7
{
	[TestClass()]
	public  class TestKuvaaja
	{
		[TestMethod()]
		public  void testLahimmanIndeksi194()
		{
			Vector[] luvut = { new Vector(1,2),new Vector(3,4),new Vector(5,2),new Vector(5,5) };
			Assert.AreEqual( 1, Kuvaaja.LahimmanIndeksi(luvut,new Vector(3,5)) , "in method LahimmanIndeksi, line 196");
			Assert.AreEqual( 0, Kuvaaja.LahimmanIndeksi(luvut,new Vector(0,0)) , "in method LahimmanIndeksi, line 197");
			Assert.AreEqual( 2, Kuvaaja.LahimmanIndeksi(luvut,new Vector(5,3)) , "in method LahimmanIndeksi, line 198");
			Assert.AreEqual( 3, Kuvaaja.LahimmanIndeksi(luvut,new Vector(15,5)) , "in method LahimmanIndeksi, line 199");
		}
	}
}

