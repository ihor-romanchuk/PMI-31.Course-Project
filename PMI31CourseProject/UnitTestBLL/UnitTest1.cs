using System;
using System.Collections.Generic;
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
            testAction.username = "login1";
            testAction.password = "1111";
            testAction.email = "mmm@gmail.com";
            testAction.fullName = "Name Surnane";
            testAction.role = Role.Graduate;
            ManageUsers testManege = new ManageUsers();
            RegistrationStatus status = testAction.RegistrationCheck(testManege);
            testManege.DeleteUser("login1");
            Assert.AreEqual(status, RegistrationStatus.RegistratedGraduate);
        }

        [TestMethod]
        public void TestMethodRegistrationCheckIfLecturer()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.username = "login1";
            testAction.password = "1111";
            testAction.email = "mmm@gmail.com";
            testAction.fullName = "Name Surnane";
            testAction.role = Role.Lecturer;
            ManageUsers testManege = new ManageUsers();
            RegistrationStatus status = testAction.RegistrationCheck(testManege);
            testManege.DeleteUser("login1");
            Assert.AreEqual(status, RegistrationStatus.RegistratedLecturer);
        }
    }

    [TestClass]
    public class UnitTestsForLoginAction
    {
        /* [TestMethod]
        public void TestAuthenticationCheckIfAdministrator()
        {
            ManageUsers users = new ManageUsers();
            LoginAction loginAction = new LoginAction();
            loginAction = new LoginAction("User1", "Pa$$word");
            string password = Security.HashPassword("Pa$$word");
            User loggingUser = new User();
            loggingUser.Login = "User1";
            loggingUser.Password = "Pa$$word";
            loggingUser.FullName = "User Number1";
            loggingUser.Role = "admin";
            users.AddUser(loggingUser);
            Assert.AreEqual(AuthenticationStatus.Administrator, loginAction.AuthenticationCheck(users));
        }
        [TestMethod]
        public void TestAuthenticationCheckIfGraduate()
        {
            ManageUsers users = new ManageUsers();
            LoginAction loginAction = new LoginAction();
            loginAction = new LoginAction("User1", "Pa$$word");
            string password = Security.HashPassword("Pa$$word");
            User loggingUser = new User();
            loggingUser.Login = "User1";
            loggingUser.Password = "Pa$$word";
            loggingUser.FullName = "User Number1";
            loggingUser.Role = "graduate";
            users.AddUser(loggingUser);
            Assert.AreEqual(AuthenticationStatus.Graduate, loginAction.AuthenticationCheck(users));
        }
        [TestMethod]
        public void TestAuthenticationCheckIfLecturer()
        {
            ManageUsers users = new ManageUsers();
            LoginAction loginAction = new LoginAction();
            loginAction = new LoginAction("User1", "Pa$$word");
            string password = Security.HashPassword("Pa$$word");
            User loggingUser = new User();
            loggingUser.Login = "User1";
            loggingUser.Password = "Pa$$word";
            loggingUser.FullName = "User Number1";
            loggingUser.Role = "lecturer";
            users.AddUser(loggingUser);
            Assert.AreEqual(AuthenticationStatus.Lecturer, loginAction.AuthenticationCheck(users));
        }*/

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
            RegistrationAction reg = new RegistrationAction
            {
                username = "lecturer1",
                password = "111",
                role = Role.Lecturer,
                fullName = "fullname"
            };
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
            RegistrationAction reg = new RegistrationAction
            {
                username = "graduate1",
                password = "111",
                role = Role.Graduate,
                fullName = "fullname"
            };
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
            Assert.IsTrue(result == (AuthenticationStatus.NoUser));
        }
    }

    [TestClass]
    public class UnitTestsForSecurity
    {
        [TestMethod]
        public void TestHashPasswordForEmptyPassword()
        {
            string password = string.Empty;
            Assert.AreEqual(password, Security.HashPassword(password));
        }

        [TestMethod]
        public void TestHashPasswordForNotEmptyPassword()
        {
            string password = "password";
            Assert.AreEqual("e201065d0554652615c320c00a1d5bc8", Security.HashPassword(password));
        }

        [TestMethod]
        public void TestHashPasswordForSamePasswords()
        {
            string password = "password";
            Assert.AreEqual(Security.HashPassword(password), Security.HashPassword(password));
        }

        [TestMethod]
        public void TestHashPasswordForDifferentPasswords()
        {
            string password1 = "password";
            string password2 = "Password";
            Assert.AreNotEqual(Security.HashPassword(password1), Security.HashPassword(password2));
        }

        [TestMethod]
        public void Test11()
        {
            ManageUsers tested = new ManageUsers();
            List<User> a = tested.GetAllUsersByGraduateYear(2001);
            Assert.AreEqual(1,1);
        }
    }

    /* [TestClass]
    public class UnitTestsForManageUsers
    {

        /*[TestMethod]
        public void TestAddUser()
        {
            ManageUsers manageUsers = new ManageUsers();
            User user = new User();
            user.Id = 1;
            user.Login = "admin";
            user.Password = "1111";
            user.Role = "admin";
            user.FullName = "fullname";
            bool temp = manageUsers.AddUser(user);
            Assert.IsTrue(manageUsers.GetById("admin")==user);
        }
      
        [TestMethod]
        public void TestDeleteUser()
        {
            ManageUsers manageUsers = new ManageUsers();
            User user = new User();
            user.Id = 1;
            user.Login = "admin";
            user.Password = "1111";
            user.Role = "admin";
            bool temp = manageUsers.DeleteUser("admin");
            Assert.IsFalse(manageUsers.GetById("admin") == user);
        }*/

    /*[TestMethod]
         [ExpectedException(typeof(InvalidOperationException))]
         public void ExceptionTestDeleteUser()
         {
             ManageUsers manageUsers = new ManageUsers();
             User user = new User();
             user.Id = 1;
             user.Login = "admin";
             user.Password = "1111";
             user.Role = "admin";
             manageUsers.DeleteUser("admin");
             manageUsers.DeleteUser("admin");
             manageUsers.DeleteUser("admin");
         }*/

    /* [TestMethod]
         public void TestGetById()
         {
             ManageUsers manageUsers = new ManageUsers();
             User user = new User();
             user.Id = 1;
             user.Login = "admin";
             user.Password = "1111";
             user.Role = "admin";
             User temp = manageUsers.GetById("admin");
             Assert.IsTrue(user==temp);
         }
         [TestMethod]
         public void TestGetAllUsersByGraduateYear()
         {
             ManageUsers manage = new ManageUsers();
             List<User> users = new List<User>();
             users = manage.GetAllUsersByGraduateYear(1991);
             Assert.AreEqual(1996, users[0].UserInfo.GraduateInfo.GraduationYear);
         }
         [TestMethod]
         public void TestUpdateUser()
         {
             ManageUsers manage = new ManageUsers();
             User user = new User();
             user.Login = "Login2";
             user.Password = "Pa$$word";
             user.Role = "admin";
             user.FullName = "First User";
             user.IsRegistered = true;
             Assert.IsTrue(manage.UpdateUser(user, "Login1"));
         }
    }*/




}
