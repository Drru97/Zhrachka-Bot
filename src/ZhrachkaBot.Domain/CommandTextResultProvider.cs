using System.Threading.Tasks;
using ZhrachkaBot.Abstractions;

namespace ZhrachkaBot.Domain
{
    public class CommandTextResultProvider : ICommandResultProvider
    {
        private readonly ICommandResultRepository _commandResultRepository;

        public CommandTextResultProvider(ICommandResultRepository commandResultRepository)
        {
            _commandResultRepository = commandResultRepository;
        }

        public CommandKind CommandKind => CommandKind.Text;

        public ICommandResult GetResult(ICommand command)
        {
            return _commandResultRepository.GetLinkedWithCommand(command);
        }

        public Task<ICommandResult> GetResultAsync(ICommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
