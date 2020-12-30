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
    }
}
