using eDocument.Domain.Enums;
using MediatR;
using System;

namespace eDocument.Infrastructure.Command
{
    public class CreateJobNotifikationCommand : IRequest
    {
        public NotifikationEnum NotifikationEnum { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }

        public long IntervalMinutes { get; set; }
    }
}
