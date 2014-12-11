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
using ProjectDatabase;
using System.Linq.Expressions;

namespace BLLUnitTests
{
    /// <summary>
    /// Test class for class RegistrationAction
    /// </summary>
    [TestClass]
    public class UnitTestsForRegistrationAction
    {
        /// <summary>
        /// Test method CheckRoleIsGraduateForTrue
        /// </summary>
        [TestMethod]
        public void TestMethodCheckRoleIsGraduateForTrue()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Graduate;
            Assert.IsTrue(testAction.CheckRoleIsGraduate());
        }

        /// <summary>
        /// Test method CheckRoleIsGraduateForFalse 
        /// for class RegistrationAction
        /// </summary>
        [TestMethod]
        public void TestMethodCheckRoleIsGraduateForFalse()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Lecturer;
            Assert.IsFalse(testAction.CheckRoleIsGraduate());
        }

        /// <summary>
        /// Test method CheckRoleIsLecturerForTrue
        /// for class RegistrationAction
        /// </summary>
        [TestMethod]
        public void TestMethodCheckRoleIsLecturerForTrue()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Lecturer;
            Assert.IsTrue(testAction.CheckRoleIsLecturer());
        }

        /// <summary>
        /// Test method CheckRoleIsLectureForFalse
        /// for class RegistrationAction
        /// </summary>
        [TestMethod]
        public void TestMethodCheckRoleIsLectureForFalse()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Graduate;
            Assert.IsFalse(testAction.CheckRoleIsLecturer());
        }

        /// <summary>
        /// Test method SetRoleForUserForLecturer
        /// for class RegistrationAction
        /// </summary>
        [TestMethod]
        public void TestMethodSetRoleForUserForLecturer()
        {
            string roleName = "";
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Lecturer;
            testAction.SetRoleForUser(ref roleName);
            Assert.AreEqual(roleName, "lecturer");
        }

        /// <summary>
        /// Test method SetRoleForUserForGraduate
        /// for class RegistrationAction
        /// </summary>
        [TestMethod]
        public void TestMethodSetRoleForUserForGraduate()
        {
            string roleName = "";
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Graduate;
            testAction.SetRoleForUser(ref roleName);
            Assert.AreEqual(roleName, "graduate");
        }

        /// <summary>
        /// Test method TSetRegistrationStatusForGraduate
        /// for class RegistrationAction
        /// </summary>
        [TestMethod]
        public void TestMethodSetRegistrationStatusForGraduate()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Graduate;
            Assert.AreEqual(testAction.SetRegistrationStatus(), RegistrationStatus.RegistratedGraduate);
        }

        /// <summary>
        /// Test method RegistrationCheckIfFailed
        /// for class RegistrationAction
        /// </summary>
        [TestMethod]
        public void TestMethodSetRegistrationStatusForLecturer()
        {
            RegistrationAction testAction = new RegistrationAction();
            testAction.role = Role.Lecturer;
            Assert.AreEqual(testAction.SetRegistrationStatus(), RegistrationStatus.RegistratedLecturer);
        }

        /// <summary>
        /// Test method RegistrationCheckIfFailed
        /// for class ForRegistrationAction
        /// </summary>
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

        /// <summary>
        /// Test method RegistrationCheckIfGraduate
        /// for class RegistrationAction
        /// </summary>
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
            User user = new ProjectDatabase.User();
            ManageUsers fakeManageUser = Isolate.Fake.Instance<ManageUsers>();
            Isolate.Swap.AllInstances<ManageUsers>().With(fakeManageUser);
            Isolate.WhenCalled(() => fakeManageUser.GetById("login")).WithExactArguments().WillReturn(user);
            RegistrationStatus status = testAction.RegistrationCheck(testManageUser);
            Assert.AreEqual(status, RegistrationStatus.RegistratedGraduate);
        }

        /// <summary>
        /// Test method RegistrationCheckIfLecturer
        /// for class RegistrationAction
        /// </summary>
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
            User user = new ProjectDatabase.User();
            ManageUsers fakeManageUser = Isolate.Fake.Instance<ManageUsers>();
            Isolate.Swap.AllInstances<ManageUsers>().With(fakeManageUser);
            Isolate.WhenCalled(() => fakeManageUser.GetById("login")).WithExactArguments().WillReturn(user);
            RegistrationStatus status = testAction.RegistrationCheck(testManageUser);
            Assert.AreEqual(status, RegistrationStatus.RegistratedLecturer);
        }
    }

    /// <summary>
    /// Unit tests class for testing class LoginAction
    /// for class RegistrationAction
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

        /// <summary>
        /// Test method AuthenticationCheckExpectedAuthenticationStatusAdministrator
        /// for class LoginAction
        /// </summary>
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

        /// <summary>
        /// Test method AuthenticationCheckExpectedAuthenticationStatusLecturer
        /// for class LoginAction
        /// </summary>
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

        /// <summary>
        /// Test method AuthenticationCheckExpectedAuthenticationStatusGraduate
        /// for class LoginAction
        /// </summary>
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

    /// <summary>
    /// Unit tests class for testing class ManageUsers
    /// </summary>
    [TestClass]
    public class UnitTestsForManageUsers
    {

        /// <summary>
        /// Unit tests method TestMethodGetContacts
        /// for class ManageUsers
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodGetContacts()
        {
            UnitOfWork<User> unitOfWork = null;
            IEnumerable<User> users = null;
            UnitOfWork<User> fake = Isolate.Fake.Instance<UnitOfWork<User>>();
            Isolate.Swap.AllInstances<UnitOfWork<User>>().With(fake);
            Isolate.WhenCalled(() => fake.ContactRepository.GetAll()).WithExactArguments().WillReturn(null);
            ManageUsers testUser = new ManageUsers();
            Assert.IsTrue(users == testUser.GetContacts());
        }

        /// <summary>
        /// Unit tests method AddUserIsTrue
        /// for class ManageUsers
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodAddUserIsTrue()
        {
            UnitOfWork<User> unitOfWork = null;
            User user = new User();
            UnitOfWork<User> fake = Isolate.Fake.Instance<UnitOfWork<User>>();
            Isolate.Swap.AllInstances<UnitOfWork<User>>().With(fake);
            Isolate.WhenCalled(() => fake.ContactRepository.Add(user)).WithExactArguments().IgnoreCall();
            Isolate.WhenCalled(() => fake.Save()).WithExactArguments().IgnoreCall();
            ManageUsers testUser = new ManageUsers();
            Assert.IsTrue(testUser.AddUser(user));
        }

        /// <summary>
        /// Unit tests method AddUserIsNotNull
        /// for class ManageUsers
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodAddUserIsNotNull()
        {
            UnitOfWork<User> unitOfWork = null;
            User user = new User();
            UnitOfWork<User> fake = Isolate.Fake.Instance<UnitOfWork<User>>();
            Isolate.Swap.AllInstances<UnitOfWork<User>>().With(fake);
            Isolate.WhenCalled(() => fake.ContactRepository.Add(user)).WithExactArguments().IgnoreCall();
            Isolate.WhenCalled(() => fake.Save()).WithExactArguments().IgnoreCall();
            ManageUsers testUser = new ManageUsers();
            testUser.AddUser(user);
            Assert.IsNotNull(testUser);
        }

        /// <summary>
        /// Unit tests method UpdateUser
        /// for class ManageUsers
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodUpdateUser()
        {
            UnitOfWork<User> unitOfWork = null;
            User user = new User();
            user.Password = "qwerty";
            string login = string.Empty;
            UnitOfWork<User> fake = Isolate.Fake.Instance<UnitOfWork<User>>();
            Isolate.Swap.AllInstances<UnitOfWork<User>>().With(fake);
            Isolate.WhenCalled(() => fake.ContactRepository.GetById(login)).WithExactArguments().WillReturn(user);
            Isolate.WhenCalled(() => fake.Save()).WithExactArguments().IgnoreCall();
            ManageUsers testUser = new ManageUsers();
            Assert.IsTrue(testUser.UpdateUser(user, login));
        }

        /// <summary>
        /// Unit tests method DeleteUser
        /// for class ManageUsers
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodDeleteUser()
        {
            UnitOfWork<User> unitOfWork = null;
            User user = new User();
            string login = string.Empty;
            UnitOfWork<User> fake = Isolate.Fake.Instance<UnitOfWork<User>>();
            Isolate.Swap.AllInstances<UnitOfWork<User>>().With(fake);
            Isolate.WhenCalled(() => fake.ContactRepository.GetById(login)).WithExactArguments().WillReturn(user);
            Isolate.WhenCalled(() => fake.ContactRepository.Delete(user)).WithExactArguments().IgnoreCall();
            Isolate.WhenCalled(() => fake.Save()).WithExactArguments().IgnoreCall();
            ManageUsers testUser = new ManageUsers();
            Assert.IsTrue(testUser.DeleteUser(login));
        }

        /// <summary>
        /// Unit tests method DeleteUserIsTrue
        /// for class ManageUsers
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodDeleteUserIsTrue()
        {
            User user = new User();
            string login = string.Empty;
            user.Login = login;
            UnitOfWork<User> fake = Isolate.Fake.Instance<UnitOfWork<User>>();
            Isolate.Swap.AllInstances<UnitOfWork<User>>().With(fake);
            Isolate.WhenCalled(() => fake.ContactRepository.GetById(login)).WithExactArguments().WillReturn(user);
            Isolate.WhenCalled(() => fake.ContactRepository.Delete(user)).WithExactArguments().IgnoreCall();
            Isolate.WhenCalled(() => fake.Save()).WithExactArguments().IgnoreCall();
            ManageUsers testUser = new ManageUsers();
            testUser.AddUser(user);
            testUser.DeleteUser(login);
            testUser.GetIdByLogin(login);
            Assert.IsTrue(-1==testUser.GetIdByLogin(login));
        }

        /// <summary>
        /// Unit tests method GetIdByLogin
        /// for class ManageUsers
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodGetIdByLogin()
        {
            UnitOfWork<User> unitOfWork = null;
            User user = new User();
            string login = string.Empty;
            Expression<Func<User, bool>> expr = someUser => someUser.Login == login;
            UnitOfWork<User> fake = Isolate.Fake.Instance<UnitOfWork<User>>();
            Isolate.Swap.AllInstances<UnitOfWork<User>>().With(fake);
            Isolate.WhenCalled(() => fake.ContactRepository.GetMany(expr)).WithExactArguments().WillReturn(null);
            ManageUsers testUser = new ManageUsers();
            Assert.IsTrue(-1 == testUser.GetIdByLogin(login));
        }

        /// <summary>
        /// Unit tests method GetById
        /// for class ManageUsers
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodGetById()
        {
            UnitOfWork<User> unitOfWork = null;
            User user = new User();
            string login = string.Empty;
            user.Login = login;
            long id = 0;
            UnitOfWork<User> fake = Isolate.Fake.Instance<UnitOfWork<User>>();
            Isolate.Swap.AllInstances<UnitOfWork<User>>().With(fake);
            Isolate.WhenCalled(() => fake.ContactRepository.GetById(id)).WithExactArguments().WillReturn(user);
            ManageUsers testUser = new ManageUsers();
            Assert.IsTrue(user.Login == testUser.GetById(login).Login);
        }

        /// <summary>
        /// Unit tests method GetAllUsersByGraduateYear
        /// for class ManageUsers
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodGetAllUsersByGraduateYear()
        {
            UnitOfWork<User> unitOfWork = null;
            User user = new User();
            int graduationYear = 0;
            List<User> users = new List<User>();
            Expression<Func<User, bool>> expressionForGetAllUsersByGraduateYear = someUser => someUser.UserInfo.GraduateInfo.GraduationYear == graduationYear;
            UnitOfWork<User> fake = Isolate.Fake.Instance<UnitOfWork<User>>();
            Isolate.Swap.AllInstances<UnitOfWork<User>>().With(fake);
            Isolate.WhenCalled(() => fake.ContactRepository.GetMany(expressionForGetAllUsersByGraduateYear)).WithExactArguments().WillReturn(users);
            ManageUsers testUser = new ManageUsers();
            Assert.IsTrue(0 == testUser.GetAllUsersByGraduateYear(graduationYear).Count);
        }

        /// <summary>
        /// Unit tests method GetAllUsersByEntranceYear
        /// for class ManageUsers
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodGetAllUsersByEntranceYear()
        {
            UnitOfWork<User> unitOfWork = null;
            User user = new User();
            int entranceYear = 0;
            List<User> users = new List<User>();
            Expression<Func<User, bool>> expressionForGetAllUsersByGraduateYear = someUser => someUser.UserInfo.GraduateInfo.EntranceYear == entranceYear;
            UnitOfWork<User> fake = Isolate.Fake.Instance<UnitOfWork<User>>();
            Isolate.Swap.AllInstances<UnitOfWork<User>>().With(fake);
            Isolate.WhenCalled(() => fake.ContactRepository.GetMany(expressionForGetAllUsersByGraduateYear)).WithExactArguments().WillReturn(users);
            ManageUsers testUser = new ManageUsers();
            Assert.AreEqual(0, testUser.GetAllUsersByEntranceYear(entranceYear).Count);
        }

        /// <summary>
        /// Unit tests method GetAllUsersBySpeciality
        /// for class ManageUsers
        /// </summary>
        [TestMethod, Isolated]
        public void TestMethodGetAllUsersBySpeciality()
        {
            UnitOfWork<User> unitOfWork = null;
            User user = new User();
            string speciality = string.Empty;
            List<User> users = new List<User>();
            Expression<Func<User, bool>> expressionForGetAllUsersByGraduateYear = someUser => someUser.UserInfo.GraduateInfo.Speciality == speciality;
            UnitOfWork<User> fake = Isolate.Fake.Instance<UnitOfWork<User>>();
            Isolate.Swap.AllInstances<UnitOfWork<User>>().With(fake);
            Isolate.WhenCalled(() => fake.ContactRepository.GetMany(expressionForGetAllUsersByGraduateYear)).WithExactArguments().WillReturn(users);
            ManageUsers testUser = new ManageUsers();
            Assert.IsTrue(0 == testUser.GetAllUsersBySpeciality(speciality).Count);
        }

    }

    /// <summary>
    /// Unit tests class for testing class Security
    /// </summary>
    [TestClass]
    public class UnitTestsForSecurity
    {
        /// <summary>
        /// Testing hashing empty password
        /// </summary>
        [TestMethod]
        public void TestHashPasswordForEmptyPassword()
        {
            string password = string.Empty;
            Assert.AreEqual(password, Security.HashPassword(password));
        }

        /// <summary>
        /// Testing hashing some not empty password
        /// </summary>
        [TestMethod]
        public void TestHashPasswordForNotEmptyPassword()
        {
            string password = "password";
            Assert.AreEqual("e201065d0554652615c320c00a1d5bc8", Security.HashPassword(password));
        }

        /// <summary>
        /// Testing hashing the same passwords
        /// </summary>
        [TestMethod]
        public void TestHashPasswordForSamePasswords()
        {
            string password = "password";
            Assert.AreEqual(Security.HashPassword(password), Security.HashPassword(password));
        }

        /// <summary>
        /// Testing hashing the different passwords
        /// </summary>
        [TestMethod]
        public void TestHashPasswordForDifferentPasswords()
        {
            string password1 = "password";
            string password2 = "Password";
            Assert.AreNotEqual(Security.HashPassword(password1), Security.HashPassword(password2));
        }
    }
}
