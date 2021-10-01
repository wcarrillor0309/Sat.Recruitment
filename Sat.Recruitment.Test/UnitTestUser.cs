using Sat.Recruitment.Api.Controllers;

using Xunit;

namespace Sat.Recruitment.Test
{
    /// <summary>
    /// test class to know if a user is created or if it is duplicated
    /// </summary>
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTestUser
    {
        [Fact]
        public void ICanCreateNewUser()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;

            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void ICantNotCreateNewUser_ByDuplicate()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;

            Assert.False(result.IsSuccess);
            Assert.Equal("User is duplicated", result.Errors);
        }
    }
}