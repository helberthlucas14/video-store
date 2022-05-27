using AutoFixture;
using DevFreela.Application.Commands.LoginUser;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;
using VideoStore.Application.Service.Auth;
using VideoStore.Application.ViewModels;
using Xunit;

namespace VideoStore.Tests.Application.Commands
{
    public class LoginUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsok_Executed_LoginUserViewModel()
        {
            var fixture = new Fixture();
            var userRepository = new Mock<IUserRepository>();
            var authService = new Mock<IAuthService>();

            var user = new User(1, "abc", "abc@gmail.com", "123", "admin");

            var userEmail = user.Email;
            var userPassword = user.Password;

            userRepository.Setup(u => u.GetUserByEmailAndPasswordAsync(user.Email, user.Password))
                                 .Returns(ConverUserInTaskUser(user));

            authService.Setup(u => u.ComputeSha256Hash(user.Password)).Returns(user.Password);
            authService.Setup(u => u.GenerateJwtToken(user.Email, user.Role)).Returns("asdasfsdfkjldhl");

            var loginUserCommand = new LoginUserCommand(userEmail, userPassword);

            var loginUserCommandHandler = new LoginUserCommandHandler(authService.Object, userRepository.Object);

            var userViewModel = await loginUserCommandHandler.Handle(loginUserCommand, new System.Threading.CancellationToken());

            Assert.IsType<LoginUserViewModel>(userViewModel);
            Assert.NotNull(userViewModel.Token);
            Assert.NotEmpty(userViewModel.Token);

            userRepository.Verify(g => g.GetUserByEmailAndPasswordAsync(userEmail, userPassword), Times.Once);
            authService.Verify(g => g.ComputeSha256Hash(user.Password), Times.Once);
            authService.Verify(g => g.GenerateJwtToken(user.Email, user.Role), Times.Once);

        }

        [Fact]
        public async Task PasswordInvalid_Executed_ReturnUnitValue()
        {
            var fixture = new Fixture();
            var userRepository = new Mock<IUserRepository>();
            var authService = new Mock<IAuthService>();

            var user = new User(1, "abc", "abc@gmail.com", "123", "admin");

            var userEmail = "abc@gmail.com";
            var userPassword = "321";

            userRepository.Setup(u => u.GetUserByEmailAndPasswordAsync(userEmail, userPassword))
                .Returns(ConverUserInTaskUser(new User(2, "", "", "", "")));

            authService.Setup(u => u.ComputeSha256Hash(It.IsAny<string>()))
                .Returns((string pass) =>
                {
                    if (pass == "123") return "123";
                    else return "23333";
                });


            var loginUserCommand = new LoginUserCommand(userEmail, userPassword);

            var loginUserCommandHandler = new LoginUserCommandHandler(authService.Object, userRepository.Object);

            var loginResult = await loginUserCommandHandler.Handle(loginUserCommand, new System.Threading.CancellationToken());

            Assert.Null(loginResult);

            userRepository.Verify(g => g.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            authService.Verify(g => g.ComputeSha256Hash(It.IsAny<string>()), Times.Once);
            authService.Verify(g => g.GenerateJwtToken(user.Email, user.Role), Times.Never);
        }



        private Task<User> ConverUserInTaskUser(User user)
        {
            return Task.Run(() => user);
        }

    }
}
