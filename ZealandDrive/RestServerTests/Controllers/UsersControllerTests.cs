using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestServer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestServer.Model;

namespace RestServer.Controllers.Tests
{
    [TestClass()]
    public class UsersControllerTests
    {
       private UsersController uc  = new UsersController(); 
        [TestMethod()]
        public void GetUsersTest()
        {
            foreach (User user in new List<User>())
            {
                user.name.ToString();
            }

            //Liste<User> liste = new List<User>(uc.GetUser());
        }

        //[TestMethod()]
        //public void GetUserTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void PutUserTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void PostUserTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DeleteUserTest()
        //{
        //    Assert.Fail();
        //}
    }
}