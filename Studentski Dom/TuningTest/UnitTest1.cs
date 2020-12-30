using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TuningTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            StudentskiDom s = new StudentskiDom(1000000);

            Student student = new Student();

            Console.WriteLine("Pocetak");

            s.UpisUDom(student, 4, true);

            Console.WriteLine("Kraj");
            // Zavrseno
        }

        [TestMethod]
        public void Test1()
        {
            StudentskiDom sd = new StudentskiDom(0);
            Assert.AreEqual(0, sd.Sobe.Count);
        }

        [TestMethod]
        public void Test2()
        {
            StudentskiDom sd = new StudentskiDom(1);
            Soba s = sd.Sobe[0];
            Assert.AreEqual(100, s.BrojSobe);
            Assert.AreEqual(2, s.Kapacitet);
        }

        [TestMethod]
        public void Test3()
        {
            StudentskiDom sd = new StudentskiDom(6);
            Soba s = sd.Sobe[1];
            Assert.AreEqual(101, s.BrojSobe);
            Assert.AreEqual(2, s.Kapacitet);
        }

        [TestMethod]
        public void Test4()
        {
            StudentskiDom sd = new StudentskiDom(3);
            Soba s = sd.Sobe[1];
            Assert.AreEqual(201, s.BrojSobe);
            Assert.AreEqual(3, s.Kapacitet);
        }

        [TestMethod]
        public void Test5()
        {
            StudentskiDom sd = new StudentskiDom(3);
            Soba s = sd.Sobe[2];
            Assert.AreEqual(302, s.BrojSobe);
            Assert.AreEqual(4, s.Kapacitet);
        }
    }
}
