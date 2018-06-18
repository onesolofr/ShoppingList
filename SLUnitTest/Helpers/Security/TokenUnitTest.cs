using Microsoft.VisualStudio.TestTools.UnitTesting;
using SLHelpers;

namespace SLUnitTest
{
    [TestClass]
    public class TokenUnitTest
    {
        [TestMethod]
        public void Build_A_Token_With_User()
        {
            TokenHelpers.BuildUserToken(new SLEntities.User { });
        }
    }
}
