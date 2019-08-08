using System;
using System.Threading.Tasks;
using ZhrachkaBot.Abstractions;

namespace ZhrachkaBot.Domain
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandResultProviderResolver _resolver;

        public CommandExecutor(ICommandResultProviderResolver resolver)
        {
            _resolver = resolver;
        }

        public ICommandResult Execute(ICommand command)
        {
            var resultProvider = _resolver.Resolve(command);
            if (resultProvider == null)
            {
                // todo: handle when no executor for command
                throw new Exception("No result provider");
            }

            var executionResult = resultProvider.GetResult(command);
            if (executionResult == null)
            {
                // todo: handle when no execution result retrieved
                throw new Exception("No execution result");
            }

            return executionResult;
        }

        public Task<ICommandResult> ExecuteAsync(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
