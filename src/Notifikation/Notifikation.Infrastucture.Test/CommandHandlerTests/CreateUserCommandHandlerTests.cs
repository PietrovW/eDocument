using AutoMapper;
using eDocument.Infrastructure.Repositories;
using eDocument.Infrastructure.Specification;
using FluentAssertions;
using Moq;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.CommandHandler;
using Notifikation.Infrastructure.DTO;
using Notifikation.Infrastructure.Entity;
using Notifikation.Infrastructure.Exceptions;
using Notifikation.Infrastructure.Profiles;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Notifikation.Infrastucture.Test.CommandHandlerTests
{
    [TestFixture]
    public class CreateUserCommandHandlerTests
    {

        [Test]
        public async Task CreateUserCommand_CustomerDataCreateOnDatabase()
        {
            //Arange
            var writeIRepositoryMoq = new Mock<IWriteIRepository>();
            var readRepositoryMoq = new Mock<IReadRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<NotifikationProfile>());
            IMapper mapper = config.CreateMapper();
            var command = new CreateUserCommand() {  User = new UserDTO() { Email = "test@test.pl", Name = "test" }};
            var handler = new CreateUserCommandHandler(writeIRepositoryMoq.Object, readRepositoryMoq.Object, mapper);

            //Act
            UserDTO x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            writeIRepositoryMoq.Verify(x => x.Add<UserEntity>(It.IsAny<UserEntity>()));
        }

        [Test]
        public async Task CreateUserCommand_CustomerDataReturnNoNoExistsUserInfrastructureException()
        {
            //Arange
            var writeIRepositoryMoq = new Mock<IWriteIRepository>();
            var readRepositoryMoq = new Mock<IReadRepository>();
            readRepositoryMoq.Setup(f => f.Contains(It.IsAny<ISpecification<UserEntity>>()))
                .Returns(true);
         
            var config = new MapperConfiguration(cfg => cfg.AddProfile<NotifikationProfile>());
            IMapper mapper = config.CreateMapper();
            var command = new CreateUserCommand() { User = new UserDTO() { Email = "test@test.pl", Name = "test" } };
            var handler = new CreateUserCommandHandler(writeIRepositoryMoq.Object, readRepositoryMoq.Object, mapper);

            //Act
            Func<Task<UserDTO>> act = () => handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            await act.Should().ThrowAsync<NoExistsUserInfrastructureException>();
        }
    }
}
