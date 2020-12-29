using Microsoft.VisualStudio.TestTools.UnitTesting;
using Studentski_Dom;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    // Harun Corbo
    [TestClass]
    public class KorisnikTest
    {
        static IEnumerable<object[]> NeispravanPassword
        {
            get
            {
                return new[]
                {
                     new object[] { null },
                     new object[] { "" },
                     new object[] { " " },
                     new object[] { "pass12" },
                     new object[] { "password!?" },
                 };
            }
        }

        [TestMethod]
        [DynamicData("NeispravanPassword")]
        public void TestSetNeispravanPassword(string password)
        {
            Student s = new Student();

            Exception ex = Assert.ThrowsException<FormatException>(() => s.Password = password);           
            StringAssert.Contains(ex.Message, "Password mora sadržati slova i brojeve!");            
        }

        [TestMethod]
        public void TestSetIspravanPassword()
        {
            Student s = new Student();
            s.Password = "password123";
            string hash = "password123".GetHashCode().ToString();
            string verifikacija = hash.Substring(hash.Length - 2);
            Assert.AreEqual(hash, s.DajHashiraniPassword(verifikacija));
        }
        

        [TestMethod]
        public void TestKorisnikUsernameExceptions()
        {
            Korisnik korisnik = new Student();
            Assert.ThrowsException<FormatException>(() => korisnik.Username = " ");
            Assert.ThrowsException<FormatException>(() => korisnik.Username = null);
        }

        [TestMethod]
        public void TestKorisnikGetUsername()
        {
            Korisnik korisnik = new Student();
            korisnik.Username = "Hamo";
            Assert.AreEqual("Hamo", korisnik.Username);
        }

        [TestMethod]
        public void TestKorisnikKonstruktor()
        {
            //Konstruktor studenta poziva konstruktor Korisnik
            Korisnik korisnik = new Student("Pipi", "Carapa123", null, null, null);
            Assert.IsInstanceOfType(korisnik, typeof(Korisnik));
            Assert.AreEqual("Pipi", korisnik.Username);
        }
    }
}
