namespace ZhrachkaBot.Abstractions
{
    public interface ICommandResultProviderResolver
    {
        ICommandResultProvider Resolve(ICommand command);
    }
}
