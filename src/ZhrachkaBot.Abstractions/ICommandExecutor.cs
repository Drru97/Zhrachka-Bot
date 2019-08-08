using System.Threading.Tasks;

namespace ZhrachkaBot.Abstractions
{
    public interface ICommandExecutor
    {
        ICommandResult Execute(ICommand command);
        Task<ICommandResult> ExecuteAsync(ICommand command);
    }
}
