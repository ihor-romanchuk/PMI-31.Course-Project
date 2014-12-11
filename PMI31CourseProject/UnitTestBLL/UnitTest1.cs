using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using PMI31CourseProject;
using PMI31CourseProject.Repository;
using ProjectDatabase;
using TypeMock;
using TypeMock.ArrangeActAssert;

namespace BLLUnitTests
{
    [TestClass]
    public class UnitTestsForRegistrationAction
    {
        [TestMethod, Isolated]
        public void TestMethodRegistrationCheckIfFailed()
        {
            ManageUsers testManageUser = new ManageUsers();
            RegistrationAction testAction = new RegistrationAction();
            testAction.username = "login";
            User user = new User();
            ManageUsers fakeManageUser = Isolate.Fake.Instance<ManageUsers>();
            Isolate.Swap.AllInstances<ManageUsers>().With(fakeManageUser);
            Isolate.WhenCalled(() => fakeManageUser.GetById("login")).WithExactArguments().WillReturn(user);
            RegistrationStatus status = testAction.RegistrationCheck(testManageUser);
            Assert.AreEqual(status, RegistrationStatus.Failed);
        }

        [TestMethod, Isolated]
        public void TestMethodRegistrationCheckIfGraduate()
        {
            ManageUsers testManageUser = new ManageUsers();
            RegistrationAction testAction = new RegistrationAction();
            testAction.username = "login";
            testAction.password = "1111";
            testAction.email = "test@gmail.com";
            testAction.fullName = "TestFullName";
            testAction.role = Role.Graduate;
            ManageUsers fakeManageUser = Isolate.Fake.Instance<ManageUsers>();
            Isolate.Swap.AllInstances<ManageUsers>().With(fakeManageUser);
            Isolate.WhenCalled(() => fakeManageUser.GetById("login")).WithExactArguments().WillReturn(null);
            RegistrationStatus status = testAction.RegistrationCheck(testManageUser);
            Assert.AreEqual(status, RegistrationStatus.RegistratedGraduate);
        }

        [TestMethod, Isolated]
        public void TestMethodRegistrationCheckIfLecturer()
        {
            ManageUsers testManageUser = new ManageUsers();
            RegistrationAction testAction = new RegistrationAction();
            testAction.username = "login";
            testAction.password = "1111";
            testAction.email = "test@gmail.com";
            testAction.fullName = "TestFullName";
            testAction.role = Role.Lecturer;
            ManageUsers fakeManageUser = Isolate.Fake.Instance<ManageUsers>();
            Isolate.Swap.AllInstances<ManageUsers>().With(fakeManageUser);
            Isolate.WhenCalled(() => fakeManageUser.GetById("login")).WithExactArguments().WillReturn(null);
            RegistrationStatus status = testAction.RegistrationCheck(testManageUser);
            Assert.AreEqual(status, RegistrationStatus.RegistratedLecturer);
        }
    }

    /// <summary>
    /// Unit tests class for testing class LoginAction
    /// </summary>
    [TestClass]
    public class UnitTestsForLoginAction
    {
<<<<<<< HEAD
        /// <summary>
        /// String field for set user login in tests
        /// </summary>
        private string userLogin = "testLogin";

        /// <summary>
        /// String field for set user password in tests
        /// </summary>
        private string userPassword = "testPassword";

        /// <summary>
        /// Test default constructor
        /// </summary>
=======
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
>>>>>>> origin/master
        [TestMethod]
        public void TestDefaultConstructor()
        {
            LoginAction loginAction = new LoginAction();
            Assert.IsTrue(loginAction.UserPassword.Equals(string.Empty) && loginAction.UserLogin.Equals(string.Empty));
        }

        /// <summary>
        /// Test constructor with parameters
        /// </summary>
        [TestMethod]
        public void TestConstructorWithParameters()
        {
            LoginAction loginAction = new LoginAction(userLogin, userPassword);
            Assert.IsTrue(loginAction.UserPassword.Equals(userPassword) && loginAction.UserLogin.Equals(userLogin));
        }

        /// <summary>
        /// Expect AuthenticationStatus.WrongPassword: user password isn't hashed
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodAuthenticationCheckExpectedAuthenticationStatusWrongPassword1()
        {
            ManageUsers testUser = new ManageUsers();
            User user = new User();
            user.Login = userLogin;
            user.Password = userPassword;
            user.Role = "admin";
            ManageUsers fake = Isolate.Fake.Instance<ManageUsers>();
            Isolate.Swap.AllInstances<ManageUsers>().With(fake);
            Isolate.WhenCalled(() => fake.GetById(userLogin)).WithExactArguments().WillReturn(user);
            LoginAction testLoginAction = new LoginAction(userLogin, userPassword);
            var expectedAuthenticationStatus = AuthenticationStatus.WrongPassword;
            var gottenAuthenticationStatus = testLoginAction.AuthenticationCheck(testUser);

            Assert.IsTrue(expectedAuthenticationStatus == gottenAuthenticationStatus);
        }

        /// <summary>
        /// Expect AuthenticationStatus.WrongPassword: try to login be another password
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodAuthenticationCheckExpectedAuthenticationStatusWrongPassword2()
        {
            ManageUsers testUser = new ManageUsers();
            User user = new User();
            user.Login = userLogin;
            user.Password = userPassword;
            user.Role = "admin";
            ManageUsers fake = Isolate.Fake.Instance<ManageUsers>();
            Isolate.Swap.AllInstances<ManageUsers>().With(fake);
            Isolate.WhenCalled(() => fake.GetById(userLogin)).WithExactArguments().WillReturn(user);
            string anotherPassword = "another_password";
            LoginAction testLoginAction = new LoginAction(userLogin, anotherPassword);
            var expectedAuthenticationStatus = AuthenticationStatus.WrongPassword;
            var gottenAuthenticationStatus = testLoginAction.AuthenticationCheck(testUser);

            Assert.IsTrue(expectedAuthenticationStatus == gottenAuthenticationStatus);
        }

        [TestMethod, Isolated]
        public void TestMethodAuthenticationCheckExpectedAuthenticationStatusAdministrator()
        {
            ManageUsers testUser = new ManageUsers();
<<<<<<< HEAD
            User user = new User();
            user.Login = userLogin;
            user.Password = Security.HashPassword(userPassword);
            user.Role = "admin";
            ManageUsers fake = Isolate.Fake.Instance<ManageUsers>();
            Isolate.Swap.AllInstances<ManageUsers>().With(fake);
            Isolate.WhenCalled(() => fake.GetById(userLogin)).WithExactArguments().WillReturn(user);
            LoginAction testLoginAction = new LoginAction(userLogin, userPassword);
            var expectedAuthenticationStatus = AuthenticationStatus.Administrator;
            var gottenAuthenticationStatus = testLoginAction.AuthenticationCheck(testUser);

            Assert.IsTrue(expectedAuthenticationStatus == gottenAuthenticationStatus);
=======
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
>>>>>>> origin/master
        }

        [TestMethod, Isolated]
        public void TestMethodAuthenticationCheckExpectedAuthenticationStatusLecturer()
        {
            ManageUsers testUser = new ManageUsers();
            User user = new User();
            user.Login = userLogin;
            user.Password = Security.HashPassword(userPassword);
            user.Role = "lecturer";
            ManageUsers fake = Isolate.Fake.Instance<ManageUsers>();
            Isolate.Swap.AllInstances<ManageUsers>().With(fake);
            Isolate.WhenCalled(() => fake.GetById(userLogin)).WithExactArguments().WillReturn(user);
            LoginAction testLoginAction = new LoginAction(userLogin, userPassword);
            var expectedAuthenticationStatus = AuthenticationStatus.Lecturer;
            var gottenAuthenticationStatus = testLoginAction.AuthenticationCheck(testUser);

            Assert.IsTrue(expectedAuthenticationStatus == gottenAuthenticationStatus);
        }

        [TestMethod, Isolated]
        public void TestMethodAuthenticationCheckExpectedAuthenticationStatusGraduate()
        {
            ManageUsers testUser = new ManageUsers();
<<<<<<< HEAD
            User user = new User();
            user.Login = userLogin;
            user.Password = Security.HashPassword(userPassword);
            user.Role = "graduate";
            ManageUsers fake = Isolate.Fake.Instance<ManageUsers>();
            Isolate.Swap.AllInstances<ManageUsers>().With(fake);
            Isolate.WhenCalled(() => fake.GetById(userLogin)).WithExactArguments().WillReturn(user);
            LoginAction testLoginAction = new LoginAction(userLogin, userPassword);
            var expectedAuthenticationStatus = AuthenticationStatus.Graduate;
            var gottenAuthenticationStatus = testLoginAction.AuthenticationCheck(testUser);

            Assert.IsTrue(expectedAuthenticationStatus == gottenAuthenticationStatus);
=======
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
>>>>>>> origin/master
        }

        /// <summary>
        /// Expect AuthenticationStatus.NoUser: condition - logginedUser != null
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodAuthenticationCheckExpectedAuthenticationStatusNoUser1()
        {
            ManageUsers testUser = new ManageUsers();
            User user = new User();
            user.Login = userLogin;
            user.Password = Security.HashPassword(userPassword);
            user.Role = "this_role_is_absent_in_database";
            ManageUsers fake = Isolate.Fake.Instance<ManageUsers>();
            Isolate.Swap.AllInstances<ManageUsers>().With(fake);
            Isolate.WhenCalled(() => fake.GetById(userLogin)).WithExactArguments().WillReturn(user);
            LoginAction testLoginAction = new LoginAction(userLogin, userPassword);
            var expectedAuthenticationStatus = AuthenticationStatus.NoUser;
            var gottenAuthenticationStatus = testLoginAction.AuthenticationCheck(testUser);

            Assert.IsTrue(expectedAuthenticationStatus == gottenAuthenticationStatus);
        }

        /// <summary>
        /// Expect AuthenticationStatus.NoUser: condition - logginedUser == null
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodAuthenticationCheckExpectedAuthenticationStatusNoUser2()
        {
            ManageUsers testUser = new ManageUsers();
            User user = new User();
            user.Login = userLogin;
            user.Password = Security.HashPassword(userPassword);
            user.Role = "this_role_is_absent_in_database";
            ManageUsers fake = Isolate.Fake.Instance<ManageUsers>();
            Isolate.Swap.AllInstances<ManageUsers>().With(fake);
            Isolate.WhenCalled(() => fake.GetById(userLogin)).WithExactArguments().WillReturn(null);
            LoginAction testLoginAction = new LoginAction(userLogin, userPassword);
            var expectedAuthenticationStatus = AuthenticationStatus.NoUser;
            var gottenAuthenticationStatus = testLoginAction.AuthenticationCheck(testUser);

            Assert.IsTrue(expectedAuthenticationStatus == gottenAuthenticationStatus);
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
<<<<<<< HEAD
=======

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




>>>>>>> origin/master
}
