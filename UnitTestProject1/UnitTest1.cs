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
            Zespó³ zespó³ = new Zespó³("zespoltestowy1", null);
            Assert.AreEqual("zespoltestowy1", zespó³.Nazwa);
        }

        [TestMethod]
        public void TestLiscznikaZespol()
        {
            Zespó³ zespó³ = new Zespó³("zespoltestowy1", null);
            zespó³.DodajCz³onka(new Cz³onekZespo³u());
            Assert.AreEqual(1, zespó³.LiczbaCz³onków);
        }
        [TestMethod]
        [ExpectedException(typeof(System.FormatException))]
        public void TestWyjatkuDlaPESELCzlonekZespolu()
        {
            Cz³onekZespo³u cz = new Cz³onekZespo³u("", "", "", "aaa", P³cie.K, new System.DateTime(), "");  
        }

    }
}
