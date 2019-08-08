namespace ZhrachkaBot.Abstractions
{
    public interface ICommandManager
    {
        void Register(ICommand command, ICommandResult result);
        void Unregister(ICommand command);
    }
}
