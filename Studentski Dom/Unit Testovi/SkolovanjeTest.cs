using Microsoft.VisualStudio.TestTools.UnitTesting;
using Studentski_Dom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Testovi
{
    // Harun Corbo
    [TestClass]
    public class SkolovanjeTest
    {
        [TestMethod]
        public void TestBrojIndeksaSetter()
        {
            Skolovanje s = new Skolovanje();
            string stariIndeks = s.BrojIndeksa;
            s.BrojIndeksa = StudentskiDom.GenerišiSljedećiBroj();
            Assert.IsNotNull(s.BrojIndeksa);
            Assert.AreNotEqual(stariIndeks, s.BrojIndeksa);
        }
    }
}
