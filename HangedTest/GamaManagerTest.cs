using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hanged;
using System.Linq;

namespace HangedTest
{
    [TestClass]
    public class GamaManagerTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var instance = new GameManager("WORD");
            var expected = new char[] { 'W', 'O', 'R', 'D' };
            Assert.AreEqual(expected[0], instance.Word[0]);
            Assert.AreEqual(expected[1], instance.Word[1]);
            Assert.AreEqual(expected[2], instance.Word[2]);
            Assert.AreEqual(expected[3], instance.Word[3]);

            Assert.AreEqual(6, instance.Trials);

            Assert.AreEqual(0,instance.Result.Count);
        }
        [TestMethod]
        [ExpectedException(typeof (Exception))]
        public void ConstructorExceptionTest()
        {
            var instance = new GameManager(null);
        }
        [TestMethod]
        public void GameManagerPutLetter()
        {
            var instance = new GameManager("WORD");
            instance.PutLether('C');
            Assert.AreEqual(5, instance.Trials);
            Assert.AreEqual(0, instance.Result.Count);
        }
        [TestMethod]
        public void Constructor2Test()
        {
            var instance = new GameManager("BANANAS");
            instance.PutLether('A');
            Assert.AreEqual(6, instance.Trials);
            Assert.AreEqual(3, instance.Result.Count);
            Assert.AreEqual(1, instance.Result.ElementAt(0));
            Assert.AreEqual(3, instance.Result.ElementAt(1));
            Assert.AreEqual(5, instance.Result.ElementAt(2));
        }
    }
}
