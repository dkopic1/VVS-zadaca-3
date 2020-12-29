using Microsoft.VisualStudio.TestTools.UnitTesting;
using Studentski_Dom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Testovi
{
    // Mehmed Dziho
    [TestClass]
    public class LicniPodaciTest
    {
        static IEnumerable<object[]> NeispravanJMBG
        {
            get
            {
                return new[]
                {
                     new object[] { null },
                     new object[] { " " },
                     new object[] { "hmhm" },
                     new object[] { "123hnmhm" },
                     new object[] { "123456789123456" },
                     new object[] { "123456789123456" }
                 };
            }
        }


        [TestMethod]
        public void TestImeSetter()
        {
            LicniPodaci lp = new LicniPodaci();
            Exception exception = Assert.ThrowsException<FormatException>(() => lp.Ime = " ");
            Assert.ThrowsException<FormatException>(() => lp.Ime = null);
            Assert.AreEqual("Ime nije ispravno!", exception.Message);
        }

        [TestMethod]
        public void TestImeGetter()
        {
            LicniPodaci lp = new LicniPodaci();
            lp.Ime = "Hamo";
            Assert.AreEqual("Hamo", lp.Ime);
        }

        [TestMethod]
        public void TestPrezimeSetter()
        {
            LicniPodaci lp = new LicniPodaci();
            Exception exception = Assert.ThrowsException<FormatException>(() => lp.Prezime = " ");
            Assert.ThrowsException<FormatException>(() => lp.Prezime = null);
            Assert.AreEqual("Prezime nije ispravno!", exception.Message);
        }

        [TestMethod]
        public void TestPrezimeGetter()
        {
            LicniPodaci lp = new LicniPodaci();
            lp.Prezime = "Ljepotan";
            Assert.AreEqual("Ljepotan", lp.Prezime);
        }

        [TestMethod]
        public void TestMjestoRodjenjaProperty()
        {
            LicniPodaci lp = new LicniPodaci();

            // neispravno
            Assert.ThrowsException<FormatException>(() => lp.MjestoRodjenja= null);
            Exception exception = Assert.ThrowsException<FormatException>(() => lp.MjestoRodjenja= " ");            
            Assert.AreEqual("Mjesto rođenja je prazno!", exception.Message);

            // ispravno
            lp.MjestoRodjenja = "Mostar";
            Assert.AreEqual("Mostar", lp.MjestoRodjenja);
        }

        [TestMethod]
        public void TestEmailProperty()
        {
            LicniPodaci lp = new LicniPodaci();

            // neispravno
            Assert.ThrowsException<FormatException>(() => lp.Email = null);
            Exception exception = Assert.ThrowsException<FormatException>(() => lp.Email= " ");
            Assert.AreEqual("Polje email je prazno!", exception.Message);

            // ispravno
            lp.Email= "test@test.com";
            Assert.AreEqual("test@test.com", lp.Email);
        }

        [TestMethod]
        public void TestSlikaProperty()
        {
            LicniPodaci lp = new LicniPodaci();

            lp.Slika= "slika.jpg";
            Assert.AreEqual("slika.jpg", lp.Slika);
        }

        [TestMethod]
        [DynamicData("NeispravanJMBG")]
        public void TestJMBGPropertyNeispravan(string jmbg)
        {
            LicniPodaci lp = new LicniPodaci();
            Exception exception = Assert.ThrowsException<FormatException>(() => lp.JMBG = jmbg);
            Assert.AreEqual("Neispravan format matičnog broja!", exception.Message);
        }

        [TestMethod]        
        public void TestJMBGPropertyIspravan()
        {
            LicniPodaci lp = new LicniPodaci();
            string ispravanJMBG = "1234567891012";
            lp.JMBG = ispravanJMBG;
            Assert.AreEqual(ispravanJMBG, lp.JMBG);
        }

        [TestMethod]
        public void TestSpolProperty()
        {
            LicniPodaci lp = new LicniPodaci();

            lp.Spol = Spol.Muško;
            Assert.AreEqual(Spol.Muško, lp.Spol);
        }

        [TestMethod]
        public void TestDatumRodjenjaProperty()
        {
            LicniPodaci lp = new LicniPodaci();

            // neispravno
            Exception exception = Assert.ThrowsException<FormatException>(() => lp.DatumRodjenja = DateTime.Today.AddDays(12));
            Assert.AreEqual("Neispravan datum!", exception.Message);

            // ispravno
            lp.DatumRodjenja= new DateTime(1998, 7, 5);
            Assert.AreEqual(1998, lp.DatumRodjenja.Year);
        
        }

        [TestMethod]
        public void TestKonstruktor()
        {
            LicniPodaci lp = new LicniPodaci("Bakir", "Bake", "Sarajevo", "bake@gmail.com", "bake.jpg", "0104199201112", Spol.Muško, DateTime.Now);

            Assert.IsNotNull(lp);
            Assert.AreEqual("Bakir", lp.Ime);
            Assert.AreEqual("Bake", lp.Prezime);
            Assert.AreEqual("Sarajevo", lp.MjestoRodjenja);
            Assert.AreEqual("bake@gmail.com", lp.Email);
            Assert.AreEqual("bake.jpg", lp.Slika);
            Assert.AreEqual("0104199201112", lp.JMBG);
            Assert.IsInstanceOfType(lp.Spol, typeof(Spol));
        }
    }
}
