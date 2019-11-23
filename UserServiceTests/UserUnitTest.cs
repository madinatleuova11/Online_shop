using IShop.Interfaces;
using IShop.Models;
using IShop.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IShop.UserServiceTests
{
    public class UserUnitTest
    {
        static DateTime birthday = new DateTime(1999, 01, 10);
        List<User> users = new List<User>
        {
            new User() { FullName = "test user 1", DateOfBirth=birthday,cardID=1 },
            new User() { FullName = "test user 2",DateOfBirth=birthday,cardID=2 },
        };

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IUserRepository>();
            var userService = new Services.UserService(fakeRepository);

            var user = new User() { FullName = "test user 1", DateOfBirth = birthday, cardID = 1 };
            await userService.AddAndSave(user);
        }

        [Fact]
        public async Task GetUsersTest()
        {
             DateTime birthday = new DateTime(1999, 01, 10);
            var users = new List<User>
            {
                new User() { FullName = "test user 1", DateOfBirth=birthday,cardID=1 },
                new User() { FullName = "test user 2",DateOfBirth=birthday,cardID=2 },
            };

            var fakeRepositoryMock = new Mock<IUserRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(users);


            var userService = new Services.UserService(fakeRepositoryMock.Object);

            var resultUsers = await userService.GetUsers();

            Assert.Collection(resultUsers, movie =>
            {
                Assert.Equal("test user 1", movie.FullName);
            },
            movie =>
            {
                Assert.Equal("test user 2", movie.FullName);
            });
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IUserRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(users);


            var userService = new Services.UserService(fakeRepositoryMock.Object);

            await userService.DeleteUser(2);
        }
    }
}
