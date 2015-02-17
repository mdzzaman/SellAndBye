using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SellAndBye.Controllers;
using SellAndBye.DataModel;
using System.Web.Http;
using System.Web.Http.Results;
using SellAndBye.Models.OutputModel;

namespace SellAndByeTests
{
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public void UserGet()
        {
            var controller = new UserController();
            var result = controller.Get() as OkNegotiatedContentResult<User>; ;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UserPut()
        {
            User user = new User { Id = "e2d5dfff-76f0-4176-b301-a7f2698a7f51", Name="selim@gmail.com", Mobile="6666555" };
            var controller = new UserController();
            var result = controller.Put(user) as OkNegotiatedContentResult<OutPutModel>; ;
            Assert.AreEqual(false, result.Content.IsError);
        }

        [TestMethod]
        public void UserDelete()
        {
            var controller = new UserController();
            var result = controller.Delete("f993e87a-dc81-4017-9ad0-b831773c0cb2") as OkNegotiatedContentResult<OutPutModel>; ;
            Assert.AreEqual(false, result.Content.IsError);
        }
    }
}
