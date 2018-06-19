using Microsoft.VisualStudio.TestTools.UnitTesting;
using SLHelpers;
using System;

namespace SLUnitTest
{
    [TestClass]
    public class TokenUnitTest
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Build_A_Token_With_User_Is_NULL()
        {
            TokenHelpers.BuildUserToken(null);
        }
    }
}
