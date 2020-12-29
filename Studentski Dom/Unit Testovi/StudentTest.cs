using Microsoft.VisualStudio.TestTools.UnitTesting;
using Studentski_Dom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Testovi
{
    // Dino Kopic
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestStudentKonstruktor()
        {
            LicniPodaci lp = new LicniPodaci("Test", "Testic", "Mostar", "test@test.com", "slika.jpg", "1234567891012", Spol.Muško, new DateTime(1998, 7, 5));

            // Bez prebivalista
            Student s = new Student("user", "password123", lp, null, null);            

            Assert.AreEqual(lp.Ime, s.Podaci.Ime);           
            Assert.AreEqual(lp.DatumRodjenja, s.Podaci.DatumRodjenja);

            Assert.IsInstanceOfType(s.Prebivaliste, typeof(List<string>));
            Assert.AreEqual(0, s.Prebivaliste.Count );

            // Sa prebivalistem
            List<string> prebivaliste = new List<string>();
            prebivaliste.Add("adresa");
            prebivaliste.Add("opcina");
            prebivaliste.Add("kanton");

            s = new Student("user", "password123", lp, prebivaliste, null);

            Assert.AreEqual(prebivaliste, s.Prebivaliste);
        }
    }
}
