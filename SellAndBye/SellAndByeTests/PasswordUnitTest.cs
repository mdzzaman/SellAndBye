using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SellAndBye.Controllers;
using System.Web.Http.Results;
using SellAndBye.Models.InputModel;
using SellAndBye.Models.OutputModel;

namespace SellAndByeTests
{
    [TestClass]
    public class PasswordUnitTest
    {
        [TestMethod]
        public void UserGet()
        {
            PasswordInput password = new PasswordInput { OldPassword="123123",NewPassword="234234" };
            var controller = new PasswordController();
            var result = controller.Put(password) as OkNegotiatedContentResult<OutPutModel>; ;
            Assert.AreEqual(false,result.Content.IsError);
        }
    }
}
