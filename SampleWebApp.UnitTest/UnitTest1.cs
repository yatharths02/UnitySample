using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;

namespace SampleWebApp.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            AccountsRepository acc = new AccountsRepository();
            //Act
            var output = acc.Login("yatharth", "sharma");
            //Assert
            Assert.IsNotNull(output);

        }
    }
}
