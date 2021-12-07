using AutoMapper;
using eDocument.Infrastructure.Repositories;
using Moq;
using NUnit.Framework;
using OCR.Infrastructure.Command;
using OCR.Infrastructure.CommandHandler;
using OCR.Infrastructure.DTO;
using OCR.Infrastructure.Profiles;
using OCR.Infrastructure.Services;
using System.Threading.Tasks;

namespace OCR.Infrastucture.Test.CommandHandlerTests
{
    internal class CreateDocumentCommandHandlerTests
    {
        [Test]
        public async Task CreateDocumentCommand_CustomerDataCreateOnFile()
        {
            //Arange
            var ocrRServiceMoq = new Mock<IOCRService>();
            var writeIRepository  = new Mock<IWriteIRepository > ();
            var command = new CreateDocumentCommand() { FileName="test",UserId=1 };
            var config = new MapperConfiguration(cfg => cfg.AddProfile<OCRProfile>());
            var handler = new CreateDocumentCommandHandler(ocrRServiceMoq.Object, writeIRepository.Object, config.CreateMapper());

            //Act 
            DocumentDTO x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            ocrRServiceMoq.Verify(x => x.GetText(It.IsAny<byte[]>()), Times.Once);
        }
    }
}
