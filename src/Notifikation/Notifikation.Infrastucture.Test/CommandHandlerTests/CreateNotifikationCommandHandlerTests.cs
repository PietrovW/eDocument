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
    public class CreateNotifikationCommandHandlerTests
    {
        [Test]
        public async Task CreateNotifikationCommand_CustomerDataCreateOnDatabase()
        {
            //Arange
            var writeIRepositoryMoq = new Mock<IWriteIRepository>();
            var readRepositoryMoq = new Mock<IReadRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<NotifikationProfile>());
            IMapper mapper = config.CreateMapper();
            var command = new CreateNotifikationCommand() { Notifikation = new NotifikatItemDTO() { Message = "test", User = new UserDTO() { Email = "test@test.pl", Name = "test" } } };
            var handler = new CreateNotifikationCommandHandler(writeIRepositoryMoq.Object, readRepositoryMoq.Object, mapper);

            //Act
            NotifikatItemDTO x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            writeIRepositoryMoq.Verify(x => x.Add<NotifikationEntity>(It.IsAny<NotifikationEntity>()));
        }

        [Test]
        public void CreateNotifikationCommand_CustomerDataReturnExistsNotifikatInfrastructureException()
        {
            //Arange
            var writeIRepositoryMoq = new Mock<IWriteIRepository>();
            var readRepositoryMoq = new Mock<IReadRepository>();
            readRepositoryMoq.Setup(f => f.Contains(It.IsAny<ISpecification<NotifikationEntity>>()))
                .Returns(true);
            //Contains
            var config = new MapperConfiguration(cfg => cfg.AddProfile<NotifikationProfile>());
            IMapper mapper = config.CreateMapper();
            var command = new CreateNotifikationCommand() { Notifikation = new NotifikatItemDTO() { Message = "test", User = new UserDTO() { Email = "test@test.pl", Name = "test" } } };
            var handler = new CreateNotifikationCommandHandler(writeIRepositoryMoq.Object, readRepositoryMoq.Object, mapper);

            //Act
            Action act = () => handler.Handle(command, new System.Threading.CancellationToken());
            // var act = handler.Handle(command, new System.Threading.CancellationToken());

            act.Should().Throw<ExistsNotifikatInfrastructureException>();
            //Asert
          //  act.Result.Should().BeEquivalentTo(typeof(ExistsNotifikatInfrastructureException));//<ExistsNotifikatInfrastructureException>();//.BeSameAs(typeof(ExistsNotifikatInfrastructureException));
        }
    }
}
