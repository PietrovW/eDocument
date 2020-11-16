using MassTransit;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.Context;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.CommandHandler
{
    public class CreateNotifikationCommandHandler : IConsumer<CreateNotifikationCommand>
    {
        private INotifikationWriteContext notifikationWrite;
        public CreateNotifikationCommandHandler(INotifikationWriteContext notifikationWrite)
        {
            this.notifikationWrite = notifikationWrite;
        }
        public async Task Consume(ConsumeContext<CreateNotifikationCommand> context)
        {
            string sql = string.Empty;
           await notifikationWrite.ExecuteAsync(sql);
        }
    }
}
