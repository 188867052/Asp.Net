using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void AddNumberTest()
        {
            //��ȷ���ݣ�����Ǿɰ汾�Ѿ���У�������
            int i = 5, j = 6;
            int result = 11;

            Assert.AreEqual(result, i + j);
        }
    }
}
