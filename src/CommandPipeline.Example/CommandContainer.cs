using Microsoft.Extensions.DependencyInjection;

namespace CommandPipeline.Microsoft.Extensions.DependencyInjection
{
    using System;
    using CommandPipeline.Infrastructure.Pipeline;

    public class CommandContainer : ICommandContainer
    {
        private readonly IServiceProvider sp;

        public CommandContainer(IServiceProvider sp)
        {
            this.sp = sp;
        }

        public ICommand Create(Type type) => (ICommand)sp.GetRequiredService(type);
    }
}
