using Microsoft.VisualStudio.TestTools.UnitTesting;
using Studentski_Dom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Testovi
{
    // Svi zajedno
    [TestClass]
    public class StudentskiDomTest
    {

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

        [TestMethod]
        public void TestKonstruktor()
        {
            StudentskiDom studentskiDom = new StudentskiDom(3);
            Assert.AreEqual(3, studentskiDom.Sobe.Count);
            Assert.AreEqual(2, studentskiDom.Sobe[0].Kapacitet);
            Assert.AreEqual(3, studentskiDom.Sobe[1].Kapacitet);
            Assert.AreEqual(4, studentskiDom.Sobe[2].Kapacitet);
        }

        [TestMethod]
        public void TestPropertya()
        {
            StudentskiDom studentskiDom = new StudentskiDom(2);
            Assert.AreEqual(0, studentskiDom.Studenti.Count);
            Assert.AreEqual(2, studentskiDom.Sobe.Count);
            Student s = new Student("Abc", "1234abcd", null, null, null);
            studentskiDom.RadSaStudentom(s, 0);
            studentskiDom.UpisUDom(s, 2, true);
            Assert.AreEqual(1, studentskiDom.Studenti.Count);
            Assert.IsTrue(studentskiDom.Studenti.Contains(s));
        }

        [TestMethod]
        public void TestGenerišiSljedećiBroj()
        {
            StudentskiDom s = new StudentskiDom(10);
            int trenutniBrojac;
            Int32.TryParse(StudentskiDom.GenerišiSljedećiBroj(), out trenutniBrojac);

            for (int i = trenutniBrojac; i <= 3; i++)
                Assert.AreEqual("" + (i + 1), StudentskiDom.GenerišiSljedećiBroj());
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void TestRadSaStudentom0()
        {
            StudentskiDom studentskiDom = new StudentskiDom(1);
            Student s = new Student("abcd", "1234abcd", null, null, null);
            studentskiDom.RadSaStudentom(s, 0);
            Assert.IsTrue(studentskiDom.Studenti.Contains(s));
            studentskiDom.RadSaStudentom(s, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRadSaStudentom1()
        {
            StudentskiDom studentskiDom = new StudentskiDom(1);
            Student s = new Student("abcd", "1234abcd", null, null, null);
            studentskiDom.UpisUDom(s, 2, true);
            studentskiDom.RadSaStudentom(s, 1);
            Assert.IsFalse(studentskiDom.Sobe[0].DaLiJeStanar(s));
            studentskiDom.RadSaStudentom(s, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public void TestRadSaStudentom2()
        {
            StudentskiDom studentskiDom = new StudentskiDom(1);
            Student s = new Student("abcd", "1234abcd", null, null, null);
            studentskiDom.RadSaStudentom(s, 0);
            studentskiDom.RadSaStudentom(s, 2);
            Assert.IsFalse(studentskiDom.Studenti.Contains(s));
            studentskiDom.RadSaStudentom(s, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestUpisUDom1()
        {
            StudentskiDom studentskiDom = new StudentskiDom(1);
            Student s = new Student("abcd", "1234abcd", null, null, null);
            studentskiDom.UpisUDom(s, 1, false);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestUpisUDom2()
        {
            StudentskiDom studentskiDom = new StudentskiDom(1);
            Student s = new Student("abcd", "1234abcd", null, null, null);
            Student s1 = new Student("abcd", "1234abcd", null, null, null);
            Student s2 = new Student("abcd", "1234abcd", null, null, null);
            studentskiDom.UpisUDom(s1, 1, true);
            studentskiDom.UpisUDom(s2, 1, true);
            studentskiDom.UpisUDom(s, 2, true);
        }

        [TestMethod]
        public void TestUpisUDom3()
        {
            StudentskiDom studentskiDom = new StudentskiDom(1);
            Student s1 = new Student("abcd", "1234abcd", null, null, null);
            Student s2 = new Student("abcd", "1234abcd", null, null, null);
            studentskiDom.UpisUDom(s1, 1, true);
            Assert.IsTrue(studentskiDom.Sobe[0].DaLiJeStanar(s1));
            studentskiDom.UpisUDom(s2, 2, false);
            Assert.IsTrue(studentskiDom.Sobe[0].DaLiJeStanar(s2));
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestDajStudenteIzPaviljona()
        {
            StudentskiDom studentskiDom = new StudentskiDom(1);
            List<Student> studenti = studentskiDom.DajStudenteIzPaviljona(new Paviljon());
            Assert.AreEqual(0, studenti.Count);
            studentskiDom.RadSaStudentom(new Student("abcd", "abcd1234", null, null, new Skolovanje()), 0);
            studenti = studentskiDom.DajStudenteIzPaviljona(new Paviljon());
        }
    }
}
