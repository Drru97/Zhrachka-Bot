using System;

namespace ZhrachkaBot.Abstractions
{
    public interface ICommand
    {
        Guid CommandId { get; set; }
        DateTime CreatedDate { get; set; }
        CommandKind CommandKind { get; }
    }
}
