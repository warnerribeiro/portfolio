namespace Unit.Web.Api.Parser
{
    using global::Web.Api.Contracts;
    using global::Web.Api.Parser;
    using Model.Poco;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class UserParserTest
    {
        [Fact]
        public void ContractsToUser()
        {
            var user = new ContractReturnUser
            {
                UserId = 1,
                UserName = "Administrador",
                Password = "admin",
                Role = "ADMIN",
                Salt = "Salt"
            };

            var userParsed = UserParser.Converter(user);

            Assert.NotNull(userParsed);
            Assert.Equal(user.UserId, userParsed.UserId);
            Assert.Equal(user.UserName, userParsed.UserName);
            Assert.Equal(user.Password, userParsed.Password);
            Assert.Equal(user.Role, userParsed.Role);
            Assert.NotEqual(user.Salt, userParsed.Salt);
            Assert.Null(userParsed.Salt);
        }

        [Fact]
        public void UserToContracts()
        {
            var user = new User
            {
                UserId = 1,
                UserName = "Administrador",
                Password = "admin",
                Role = "ADMIN",
                Salt = "Salt"
            };

            var userParsed = UserParser.Converter(user);

            Assert.NotNull(userParsed);
            Assert.Equal(user.UserId, userParsed.UserId);
            Assert.Equal(user.UserName, userParsed.UserName);
            Assert.Equal(user.Password, userParsed.Password);
            Assert.Equal(user.Role, userParsed.Role);
            Assert.NotEqual(user.Salt, userParsed.Salt);
            Assert.Null(userParsed.Salt);
        }
        [Fact]
        public void UserToContractsList()
        {
            var user = new List<User>
            {
                new User
                {
                    UserId = 1,
                    UserName = "Administrador",
                    Password = "admin",
                    Role = "ADMIN",
                    Salt = "Salt"
                },
                 new User
                {
                    UserId = 1,
                    UserName = "User",
                    Password = "user",
                    Role = "USER",
                    Salt = "Salt"
                },
                  new User
                {
                    UserId = 1,
                    UserName = "Employee",
                    Password = "Emp",
                    Role = "EMPLOYEE",
                    Salt = "Salt"
                }
            };

            var userParsed = UserParser.Converter(user);

            Assert.NotEmpty(userParsed);
            Assert.Equal(user.Count, userParsed.ToList().Count);
        }
    }
}