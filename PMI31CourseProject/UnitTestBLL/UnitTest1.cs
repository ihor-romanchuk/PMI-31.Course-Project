using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using PMI31CourseProject;
using PMI31CourseProject.Repository;
using ProjectDatabase;
using TypeMock;
using TypeMock.ArrangeActAssert;
using DAL;

namespace BLLUnitTests
{
    [TestClass]
    public class UnitTestsForRegistrationAction
    {
        [TestMethod]
        public void TestMethodCheckRoleIsGraduateForTrue()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Graduate;
            Assert.IsTrue(testAction.CheckRoleIsGraduate());
        }

        [TestMethod]
        public void TestMethodCheckRoleIsGraduateForFalse()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Lecturer;
            Assert.IsFalse(testAction.CheckRoleIsGraduate());
        }

        [TestMethod]
        public void TestMethodCheckRoleIsLecturerForTrue()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Lecturer;
            Assert.IsTrue(testAction.CheckRoleIsLecturer());
        }

        [TestMethod]
        public void TestMethodCheckRoleIsLectureForFalse()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Graduate;
            Assert.IsFalse(testAction.CheckRoleIsLecturer());
        }

        [TestMethod]
        public void TestMethodSetRoleForUserForLecturer()
        {
            string roleName = "";
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Lecturer;
            testAction.SetRoleForUser(ref roleName);
            Assert.AreEqual(roleName, "lecturer");
        }

        [TestMethod]
        public void TestMethodSetRoleForUserForGraduate()
        {
            string roleName = "";
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Graduate;
            testAction.SetRoleForUser(ref roleName);
            Assert.AreEqual(roleName, "graduate");
        }

        [TestMethod]
        public void TestMethodSetRegistrationStatusForGraduate()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Graduate;
            Assert.AreEqual(testAction.SetRegistrationStatus(), RegistrationStatus.RegistratedGraduate);
        }

        [TestMethod]
        public void TestMethodSetRegistrationStatusForLecturer()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Lecturer;
            Assert.AreEqual(testAction.SetRegistrationStatus(), RegistrationStatus.RegistratedLecturer);
        }

        [TestMethod, Isolated]
        public void TestMethodRegistrationCheckIfFailed()
        {
            ManageUsers testManageUser = new ManageUsers();
            RegistrationAction testAction = new RegistrationAction();
            testAction.username = "login";
            User user = null;
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
            User user = new User();
            ManageUsers fakeManageUser = Isolate.Fake.Instance<ManageUsers>();
            Isolate.Swap.AllInstances<ManageUsers>().With(fakeManageUser);
            Isolate.WhenCalled(() => fakeManageUser.GetById("login")).WithExactArguments().WillReturn(user);
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
            User user = new User();
            ManageUsers fakeManageUser = Isolate.Fake.Instance<ManageUsers>();
            Isolate.Swap.AllInstances<ManageUsers>().With(fakeManageUser);
            Isolate.WhenCalled(() => fakeManageUser.GetById("login")).WithExactArguments().WillReturn(user);
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
    }

    [TestClass]
    public class TestManageUsers
    {
        //[TestMethod]
        //public void TestMethodGetContacts()
        //{
        //    IEnumerable<User> users ;
        //    UnitOfWork<User> unitOfWork = new UnitOfWork<User>();
        //    Repository<User> fake = Isolate.Fake.Instance<Repository<User>>();
        //    Isolate.Swap.AllInstances < Repository<User>>().With(fake);
        //    Isolate.WhenCalled(() => fake.GetAll()).WithExactArguments().WillReturn(users);
        //}

    }
}
