using AutoMapper;
using eDocument.Infrastructure.Repositories;
using MassTransit.Mediator;
using Moq;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.CommandHandler;
using Notifikation.Infrastructure.DTO;
using Notifikation.Infrastructure.Profiles;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Notifikation.Infrastucture.Test.CommandHandlerTests
{
   [TestFixture]
   public  class CreateNotifikationCommandHandlerTests
    {
        [Test]
        public async Task CreateNotifikationCommand_CustomerDataCreateOnDatabase()
        {
            //Arange
            var writeIRepositoryMoq = new Mock<IWriteIRepository>();
            var readRepositoryMoq = new Mock<IReadRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<NotifikationProfile>());
            IMapper mapper = config.CreateMapper();
            var command = new CreateNotifikationCommand();
            var handler = new CreateNotifikationCommandHandler(writeIRepositoryMoq.Object, readRepositoryMoq.Object, mapper);

            //Act
            NotifikatItemDTO x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            //Do the assertion

            //something like:
           // mediator.Verify(x => x.Publish(It.IsAny<CustomersChanged>()));
        }
    }
}
