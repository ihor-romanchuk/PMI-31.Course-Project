using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using PMI31CourseProject;
using PMI31CourseProject.Repository;

namespace BLLUnitTests
{
    [TestClass]
    public class UnitTestsForLoginAction
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAuthenticationCheckMethodForNoUser()
        {
            ManageUsers testUser = new ManageUsers();

            LoginAction testLoginAction = new LoginAction("isAbcenteHere", "111111");
            testLoginAction.AuthenticationCheck(testUser);
        }

        [TestMethod]
        public void Test()
        {

            ManageUsers testUser = new ManageUsers();

            LoginAction testLoginAction = new LoginAction("isAbcenteHere", "111111");
            testLoginAction.AuthenticationCheck(testUser);
            Assert.IsTrue(testLoginAction.AuthenticationCheck(testUser).Equals(AuthenticationStatus.NoUser));
            //ManageUsers testUser = new ManageUsers();
            ////UserOfSite loggingUser = testUser.GetById("qwer");
            ////testUser.AddUser(loggingUser);
            //RegistrationAction user = new RegistrationAction();
            //user.username = "qwer";
            //user.password = "11111";
            //user.email = "test@gmail.com";
            //user.role = Role.Graduate;
            //LoginAction testLoginAction = new LoginAction("qwer", "111111");
            //Assert.IsFalse(testLoginAction.AuthenticationCheck(testUser).Equals(AuthenticationStatus.NoUser));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestLecturerStatus()
        {
            ManageUsers testUser = new ManageUsers();

            LoginAction testLoginAction = new LoginAction("lnu", "119");
            testLoginAction.AuthenticationCheck(testUser);
            Assert.IsTrue(testLoginAction.AuthenticationCheck(testUser).Equals(AuthenticationStatus.Lecturer));
        }
    }
}
