using AutoFixture;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Commands.ChangePassword;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;
using VideoStore.Application.Service.Auth;
using Xunit;

namespace VideoStore.Tests.Application.Commands
{
    public class ChangePasswordCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsok_Executed_ReturnUnitValue()
        {
            var fixture = new Fixture();
            var userRepository = new Mock<IUserRepository>();
            var authService = new Mock<IAuthService>();

            var user = new User(1, "abc", "abc@gmail.com", "6f2cb9dd8f4b65e24e1c3f3fa5bc57982349237f11abceacd45bbcb74d621c25", "admin");
            var newPassoword = "6f2cb9dd8f4b65e24e1c3f3fa5bc57982349237f11abceacd45bbcb74d621c25";


            userRepository.Setup(u => u.GetByIdAsync(user.Id)).Returns(ConverUserInTaskUser(user));
            authService.Setup(u => u.ComputeSha256Hash(newPassoword)).Returns(newPassoword);

            var changePasswordCommand = new ChangePasswordCommand(1, "6f2cb9dd8f4b65e24e1c3f3fa5bc57982349237f11abceacd45bbcb74d621c25", newPassoword);

            var changePasswordCommandHandler = new ChangePasswordCommandHandler(userRepository.Object, authService.Object);

            var id = await changePasswordCommandHandler.Handle(changePasswordCommand, new System.Threading.CancellationToken());

            Assert.IsType<Unit>(id);
            Assert.True(Unit.Value.Equals(id));

            userRepository.Verify(g => g.GetByIdAsync(1), Times.Once);
            userRepository.Verify(g => g.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task PasswordInvalid_Executed_ReturnInvalidOperation()
        {
            var fixture = new Fixture();
            var userRepository = new Mock<IUserRepository>();
            var authService = new Mock<IAuthService>();

            var user = new User(1, "abc", "abc@gmail.com", "321", "admin");

            userRepository.Setup(u => u.GetByIdAsync(user.Id)).Returns(ConverUserInTaskUser(user));
            authService.Setup(u => u.ComputeSha256Hash("123"))
                .Returns((string pass) =>
                {
                    if (pass == "123") return "123";
                    else return string.Empty;
                });

            var changePasswordCommand = new ChangePasswordCommand(1, "222", "3213");

            var changePasswordCommandHandler = new ChangePasswordCommandHandler(userRepository.Object, authService.Object);

            InvalidOperationException except = await Assert.ThrowsAsync<InvalidOperationException>(() => changePasswordCommandHandler.Handle(changePasswordCommand, new System.Threading.CancellationToken()));

            Assert.Equal("Senha Digitada e inválida!", except.Message);
            userRepository.Verify(g => g.GetByIdAsync(1), Times.Once);
        }

        [Fact]
        public async Task UserNull_Executed_ReturnInvalidOperation()
        {
            var fixture = new Fixture();
            var userRepository = new Mock<IUserRepository>();
            var authService = new Mock<IAuthService>();

            var user = new User(2, "abc", "abc@gmail.com", "", "admin");

            userRepository.Setup(u => u.GetByIdAsync(user.Id)).Returns(ConverUserInTaskUser(user));
            authService.Setup(u => u.ComputeSha256Hash("123")).Returns("123");

            var changePasswordCommand = new ChangePasswordCommand(1, "123", string.Empty);

            var changePasswordCommandHandler = new ChangePasswordCommandHandler(userRepository.Object, authService.Object);

            InvalidOperationException except = await Assert.ThrowsAsync<InvalidOperationException>(() => changePasswordCommandHandler.Handle(changePasswordCommand, new System.Threading.CancellationToken()));

            Assert.Equal("Usuário não encontrado!", except.Message);

            userRepository.Verify(g => g.GetByIdAsync(1), Times.Once());
        }

        private Task<User> ConverUserInTaskUser(User user)
        {
            return Task.Run(() => user);
        }
    }
}
