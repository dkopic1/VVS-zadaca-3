using Microsoft.VisualStudio.TestTools.UnitTesting;
using Studentski_Dom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Testovi
{  
    [TestClass]
    public class Zadatak1Testovi
    {
        // Harun Corbo
        [TestMethod]
        public void TestDajHashiraniPassword_1()
        {
            Student t = new Student();

            string pravi = "password123";
            t.Password = "password123";

            string hashirani = pravi.GetHashCode().ToString();
            string verifikacija1 = hashirani.Substring(hashirani.Length - 2);

            Assert.AreEqual(t.DajHashiraniPassword(verifikacija1), hashirani);
        }

        // Dino Kopic
        [TestMethod]
        public void TestDajHashiraniPassword_2()
        {
            Student t = new Student();          
            t.Password = "password123";

            string verifikacija = "greska";

            Assert.IsNull(t.DajHashiraniPassword(verifikacija));
        }

        // Mehmed Dziho
        [TestMethod]
        public void TestPređiNaSljedećuGodinu1()
        {           
            // Dodat cemo tri skolovanja da napunimo bazu
            Skolovanje s1 = new Skolovanje();
            Skolovanje s2 = new Skolovanje();
            Skolovanje s3 = new Skolovanje();

            Skolovanje s = new Skolovanje();

            // I ciklus, sa prve na drugu godinu studija
            string indeks = s.BrojIndeksa;
            s.PređiNaSljedećuGodinu();
            Assert.AreEqual(2, s.GodinaStudija);
            Assert.AreEqual(1, s.CiklusStudija);
            Assert.AreEqual(1, s.CiklusStudija);
            Assert.AreEqual(indeks, s.BrojIndeksa);

            // I ciklus, sa druge na trecu godinu studija
            s.PređiNaSljedećuGodinu();
            Assert.AreEqual(3, s.GodinaStudija);

            // II ciklus, upis u prvu godinu studija
            string stariIndeks = s.BrojIndeksa;
            s.PređiNaSljedećuGodinu();
            Assert.AreEqual(1, s.GodinaStudija);
            Assert.AreEqual(2, s.CiklusStudija);
            Assert.AreNotEqual(stariIndeks, s.BrojIndeksa);

            // II ciklus, s prve godine na drugu            
            s.PređiNaSljedećuGodinu();
            Assert.AreEqual(2, s.GodinaStudija);
            Assert.AreEqual(2, s.CiklusStudija);       
        }

        // Dino Kopic
        [TestMethod]
        public void TestPlacanje1()
        {
            Student t = new Student();
            t.AzurirajStanjeRacuna(500);

            t.Placanje(400);

            Assert.AreEqual(t.StanjeRacuna, 98.5);
        }
        
        // Mehmed Dziho
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPlacanje2()
        {
            Student t = new Student();
            t.AzurirajStanjeRacuna(500);

            t.Placanje(550);
        }

        // Mehmed Dziho
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPremjestajStudenta1()
        {
            Student student1 = new Student("Prvi", "abcd1234", null, null, null);
            Student student2 = new Student("Drugi", "abcd1234", null, null, null);
            StudentskiDom studentskiDom = new StudentskiDom(2);
            studentskiDom.UpisUDom(student1, 5, true);
            studentskiDom.UpisUDom(student2, 5, false);
            studentskiDom.PremjestajStudenta(student1, true);
        }

        // Harun Corbo
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestPremjestajStudenta2()
        {
            StudentskiDom studentskiDom = new StudentskiDom(2);
            Student prvi = new Student("Prvi", "abcd1234", null, null, null);
            Student drugi = new Student("Drugi", "abcd1234", null, null, null);
            Student treci = new Student("Treci", "abcd1234", null, null, null);
            studentskiDom.UpisUDom(prvi, 2, false);
            studentskiDom.UpisUDom(drugi, 2, false);
            studentskiDom.UpisUDom(treci, 5, true);

            studentskiDom.PremjestajStudenta(treci, false);
        }

        // Harun Corbo
        [TestMethod]
        public void TestPremjestajStudenta3()
        {
            StudentskiDom studentskiDom = new StudentskiDom(2);
            Student prvi = new Student("Prvi", "abcd1234", null, null, null);
            Student drugi = new Student("Drugi", "abcd1234", null, null, null);
            studentskiDom.UpisUDom(prvi, 2, false);
            studentskiDom.UpisUDom(drugi, 2, false);

            Assert.IsTrue(studentskiDom.Sobe[0].DaLiJeStanar(drugi));
            Assert.IsFalse(studentskiDom.Sobe[1].DaLiJeStanar(drugi));

            Assert.AreEqual(2, studentskiDom.Sobe[0].Stanari.Count);
            Assert.AreEqual(0, studentskiDom.Sobe[1].Stanari.Count);

            studentskiDom.PremjestajStudenta(drugi, false);

            Assert.AreEqual(1, studentskiDom.Sobe[0].Stanari.Count);
            Assert.AreEqual(1, studentskiDom.Sobe[1].Stanari.Count);

            Assert.IsFalse(studentskiDom.Sobe[0].DaLiJeStanar(drugi));
            Assert.IsTrue(studentskiDom.Sobe[1].DaLiJeStanar(drugi));
        }
    }
}
