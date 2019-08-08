using System.Threading.Tasks;

namespace ZhrachkaBot.Abstractions
{
    public interface ICommandResultProvider
    {
        CommandKind CommandKind { get; }
        
        ICommandResult GetResult(ICommand command);
        Task<ICommandResult> GetResultAsync(ICommand command);
    }
}
