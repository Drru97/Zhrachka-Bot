using ZhrachkaBot.Abstractions;

namespace ZhrachkaBot.Domain
{
    public class CommandManager : ICommandManager
    {
        private readonly ICommandRepository _commandRepository;
        private readonly ICommandResultRepository _commandResultRepository;

        public CommandManager(ICommandRepository commandRepository, ICommandResultRepository commandResultRepository)
        {
            _commandRepository = commandRepository;
            _commandResultRepository = commandResultRepository;
        }

        public void Register(ICommand command, ICommandResult result)
        {
            if (_commandRepository.GetById(command.CommandId) == null &&
                _commandResultRepository.GetById(result.ResultId) == null)
            {
                _commandRepository.Add(command);
                result.CommandId = command.CommandId;
                _commandResultRepository.Add(result);
            }
        }

        public void Unregister(ICommand command)
        {
            if (_commandRepository.GetById(command.CommandId) != null)
            {
                var linkedCommandResult = _commandResultRepository.GetLinkedWithCommand(command);
                _commandRepository.Remove(command);
                if (linkedCommandResult != null)
                {
                    _commandResultRepository.Remove(linkedCommandResult);
                }
            }
        }
    }
}
