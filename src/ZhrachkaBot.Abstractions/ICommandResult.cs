using System;

namespace ZhrachkaBot.Abstractions
{
    public interface ICommandResult
    {
        Guid CommandId { get; set; }
        Guid ResultId { get; set; }
        DateTime CreatedDate { get; set; }
        CommandResultKind ResultKind { get; }
    }
}
