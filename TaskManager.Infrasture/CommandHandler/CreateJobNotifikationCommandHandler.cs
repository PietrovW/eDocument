using Hangfire;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.CommandHandler
{
    using eDocument.Infrastructure.Command;
    public class CreateJobNotifikationCommandHandler : IRequestHandler<CreateJobNotifikationCommand>
    {
        public async Task<Unit> Handle(CreateJobNotifikationCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                RecurringJob.RemoveIfExists(request.Name);
                RecurringJob.AddOrUpdate(() => JobNotifikation(), Cron.Minutely);
            });
            return Unit.Value;
        }

        public void JobNotifikation()
        {
        }
    }
}
