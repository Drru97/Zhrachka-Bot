using System.Threading.Tasks;

namespace ZhrachkaBot.Abstractions
{
    public interface ICommandResultRepository : IRepository<ICommandResult>
    {
        ICommandResult GetLinkedWithCommand(ICommand command);
    }
}
