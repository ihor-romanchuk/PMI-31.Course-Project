using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using PMI31CourseProject;
using PMI31CourseProject.Repository;
using ProjectDatabase;

namespace BLLUnitTests
{
    [TestClass]
    public class UnitTestsForRegistrationAction
    {
        [TestMethod]
        public void TestMethodRegistrationCheckIfFailed()
        {
            ManageUsers testManege = new ManageUsers();
            RegistrationAction testAction = new RegistrationAction();
            RegistrationStatus status = testAction.RegistrationCheck(testManege);
            Assert.AreEqual(status, RegistrationStatus.Failed);
        }

        [TestMethod]
        public void TestMethodRegistrationCheckIfGraduate()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.username = "login";
            testAction.password = "1111";
            testAction.email = "mmm@gmail.com";
            testAction.fullName = "Name Surnane";
            testAction.role = Role.Graduate;
            ManageUsers testManege = new ManageUsers();
            RegistrationStatus status = testAction.RegistrationCheck(testManege);
            Assert.AreEqual(status, RegistrationStatus.RegistratedGraduate);
        }

        [TestMethod]
        public void TestMethodRegistrationCheckIfLecturer()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.username = "login";
            testAction.password = "1111";
            testAction.email = "mmm@gmail.com";
            testAction.fullName = "Name Surnane";
            testAction.role = Role.Lecturer;
            ManageUsers testManege = new ManageUsers();
            RegistrationStatus status = testAction.RegistrationCheck(testManege);
            Assert.AreEqual(status, RegistrationStatus.RegistratedLecturer);
        }
    }

    [TestClass]
    public class UnitTestsForLoginAction
    {


        //[TestMethod, Isolated]
        //public void TestAuthenticationCheckMethodForNoUser()
        //{
        //    ManageUsers testUser = new ManageUsers();

        //    User user = new User();
        //    user.Role = "admin";

        //    Assert.IsTrue(true); 
        //    ManageUsers fake = Isolate.Fake.Instance<ManageUsers>();
        //    //Isolate.Swap.AllInstances<ManageUsers>().With(fake);
        //    //Isolate.WhenCalled(() => fake.GetById("s")).WithExactArguments().WillReturn(user);
        //    //mock.Setup(x => x.GetById("nouser")).Returns(user);

        //    //var tt = testLoginAction.AuthenticationCheck(fake);
        //    //Isolate.WhenCalled(() => fake.GetById("5")).DoInstead(context =>
        //    //    {
        //    //        return user;
        //    //    });
        //    ManageUsers u = new ManageUsers();
        //    LoginAction testLoginAction = new LoginAction("s", "111111");
        //    var tt = testLoginAction.AuthenticationCheck(u);

        //    //Assert.IsTrue(AuthenticationStatus.WrongPassword.Equals( tt));
        //}

        //[TestMethod]
        //public void Test()
        //{
        //    ManageUsers testUser = new ManageUsers();
        //    LoginAction testLoginAction = new LoginAction("isAbcenteHere", "111111");
        //    testLoginAction.AuthenticationCheck(testUser);
        //    Assert.IsTrue(testLoginAction.AuthenticationCheck(testUser).Equals(AuthenticationStatus.NoUser));
        //    //ManageUsers testUser = new ManageUsers();
        //    ////UserOfSite loggingUser = testUser.GetById("qwer");
        //    ////testUser.AddUser(loggingUser);
        //    //RegistrationAction user = new RegistrationAction();
        //    //user.username = "qwer";
        //    //user.password = "11111";
        //    //user.email = "test@gmail.com";
        //    //user.role = Role.Graduate;
        //    //LoginAction testLoginAction = new LoginAction("qwer", "111111");
        //    //Assert.IsFalse(testLoginAction.AuthenticationCheck(testUser).Equals(AuthenticationStatus.NoUser));
        //}

        [TestMethod]
        public void TestLecturerStatusExpected()
        {
            ManageUsers testUser = new ManageUsers();
            RegistrationAction reg = new RegistrationAction { username = "lecturer1", password = "111", role = Role.Lecturer };
            reg.RegistrationCheck(testUser);
            LoginAction testLoginAction = new LoginAction("lecturer1", "111");
            var result = testLoginAction.AuthenticationCheck(testUser);
            Assert.IsTrue(result == (AuthenticationStatus.Lecturer));
        }

        [TestMethod]
        public void TestLecturerStatusWrongPasswordExpected()
        {
            ManageUsers testUser = new ManageUsers();
            LoginAction testLoginAction = new LoginAction("lecturer1", "222");
            var result = testLoginAction.AuthenticationCheck(testUser);
            Assert.IsTrue(result == (AuthenticationStatus.WrongPassword));
        }

        [TestMethod]
        public void TestGraduateStatusExpected()
        {
            ManageUsers testUser = new ManageUsers();
            RegistrationAction reg = new RegistrationAction { username = "graduate1", password = "111", role = Role.Graduate };
            reg.RegistrationCheck(testUser);
            LoginAction testLoginAction = new LoginAction("graduate1", "111");
            var result = testLoginAction.AuthenticationCheck(testUser);
            Assert.IsTrue(result == (AuthenticationStatus.Graduate));
        }

        [TestMethod]
        public void TestGraduateStatusWrongPasswordExpected()
        {
            ManageUsers testUser = new ManageUsers();
            LoginAction testLoginAction = new LoginAction("graduate1", "333");
            var result = testLoginAction.AuthenticationCheck(testUser);
            Assert.IsTrue(result == (AuthenticationStatus.WrongPassword));
        }

        [TestMethod]
        public void TestNoUserStatus()
        {
            ManageUsers testUser = new ManageUsers();
            LoginAction testLoginAction = new LoginAction("this_user_is_abent_in_database", "111");
            var result = testLoginAction.AuthenticationCheck(testUser);
            Assert.IsTrue(result == (AuthenticationStatus.Graduate));
        }
    }
}
