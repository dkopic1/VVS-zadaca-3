using Microsoft.VisualStudio.TestTools.UnitTesting;
using Studentski_Dom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Testovi
{
    // Mehmed Dziho
    [TestClass]
    public class PaviljonTest
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestDajImePaviljona()
        {
            Paviljon p = new Paviljon();

            p.DajImePaviljona();
        }
    }
}
