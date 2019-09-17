using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoriskOpgave1;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Bog bog;

        [TestInitialize]
        public void BeforeTest()
        {
            bog = new Bog("Min titel", "Alexander", 350, "0123456789123");
        }

        [TestMethod]
        public void TestTitel()
        {
            Assert.AreEqual("Min titel", bog.Titel);

            bog.Titel = "Min nye titel";
            Assert.AreEqual("Min nye titel", bog.Titel);
        }

        [TestMethod]
        public void TestTitelException()
        {
            try
            {
                bog.Titel = "M";
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Titel skal være længere end 2 tegn", e.Message);
            }
        }

        [TestMethod]
        public void TestForfatter()
        {
            Assert.AreEqual("Alexander", bog.Forfatter);

            bog.Forfatter = "Karsten";
            Assert.AreEqual("Karsten", bog.Forfatter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSidetalLowException()
        {
            bog.Sidetal = 5;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSidetalHighException()
        {
            bog.Sidetal = 1001;
        }

        [TestMethod]
        public void TestSidetal()
        {
            bog.Sidetal = 500;
            Assert.AreEqual(500, bog.Sidetal);
        }

        [TestMethod]
        public void Testisbn13()
        {
            Assert.AreEqual(bog.Isbn13, "0123456789123");

            bog.Isbn13 = "HejmeddigOkay";
            Assert.AreEqual(bog.Isbn13, "HejmeddigOkay");
        }

        [TestMethod]
        public void Testisbn13Length()
        {
            Assert.AreEqual(bog.Isbn13.Length, 13);
        }

        [TestMethod]
        public void Testisbn13LengthException()
        {
            try
            {
                bog.Isbn13 = "Hej";
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("isbn13 skal være 13 tegn langt", e.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorTitel()
        {
            bog = new Bog("M", "Alexander", 350, "0123456789123");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructorSidetal()
        {
            bog = new Bog("Min titel", "Alexander", 5, "0123456789123");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorIsbn13()
        {
            bog = new Bog("Min titel", "Alexander", 350, "Hej");
        }
    }
}
