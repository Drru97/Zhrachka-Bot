using System;
using ZhrachkaBot.Abstractions;

namespace ZhrachkaBot.Domain.Commands
{
    public class TextCommandResult : ICommandResult
    {
        public string Text { get; set; }
        public Guid CommandId { get; set; }
        public Guid ResultId { get; set; }
        public DateTime CreatedDate { get; set; }
        public CommandResultKind ResultKind { get; } = CommandResultKind.Text;
    }
}
