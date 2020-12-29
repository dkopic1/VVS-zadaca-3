using Microsoft.VisualStudio.TestTools.UnitTesting;
using Studentski_Dom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Testovi
{
    // Dino Kopic
    [TestClass]
    public class SobaTest
    {
        [TestMethod]
        public void TestBrojSobeProperty()
        {
            Soba s = new Soba(1, 10);

            Assert.AreEqual(1, s.BrojSobe);
        }

        [TestMethod]
        public void TestIsprazniSobu()
        {
            Student student1 = new Student();
            Student student2 = new Student();

            Soba soba = new Soba(1, 10);
            Assert.AreEqual(0, soba.Stanari.Count);

            soba.DodajStanara(student1);
            soba.DodajStanara(student2);

            Assert.AreEqual(2, soba.Stanari.Count);

            soba.IsprazniSobu();

            Assert.AreEqual(0, soba.Stanari.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDodajStanara()
        {
            Soba s = new Soba(1, 2);
            Student prvi = new Student("Prvi", "abcd1234", null, null, null);
            Student drugi = new Student("Drugi", "abcd1234", null, null, null);
            Student treci = new Student("Treci", "abcd12345", null, null, null);
            s.DodajStanara(prvi);
            s.DodajStanara(drugi);
            s.DodajStanara(treci);
        }

        [TestMethod]
        public void TestIzbaciStudenta()
        {
            Soba s = new Soba(1, 4);
            Student prvi = new Student("Prvi", "abcd1234", null, null, null);
            Student drugi = new Student("Drugi", "abcd1234", null, null, null);
            Student treci = new Student("Treci", "abcd12345", null, null, null);
            s.DodajStanara(prvi);
            s.DodajStanara(drugi);

            // Student nije stanar sobe
            Exception e = Assert.ThrowsException<ArgumentException>(() => s.IzbaciStudenta(treci));
            Assert.AreEqual("Student nije stanar sobe!", e.Message);

            // Ispravno
            s.IzbaciStudenta(prvi);
            Assert.AreEqual(1, s.Stanari.Count);
        }
    }
}
