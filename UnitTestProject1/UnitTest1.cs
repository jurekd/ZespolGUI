using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNazwaWKonstruktorzeZespol()
        {
            Zesp� zesp� = new Zesp�("zespoltestowy1", null);
            Assert.AreEqual("zespoltestowy1", zesp�.Nazwa);
        }

        [TestMethod]
        public void TestLiscznikaZespol()
        {
            Zesp� zesp� = new Zesp�("zespoltestowy1", null);
            zesp�.DodajCz�onka(new Cz�onekZespo�u());
            Assert.AreEqual(1, zesp�.LiczbaCz�onk�w);
        }
        [TestMethod]
        [ExpectedException(typeof(System.FormatException))]
        public void TestWyjatkuDlaPESELCzlonekZespolu()
        {
            Cz�onekZespo�u cz = new Cz�onekZespo�u("", "", "", "aaa", P�cie.K, new System.DateTime(), "");  
        }

    }
}
