using System;
using ZhrachkaBot.Abstractions;

namespace ZhrachkaBot.Domain.Commands
{
    public class TextCommand : ICommand
    {
        public Guid CommandId { get; set; }
        public DateTime CreatedDate { get; set; }
        public CommandKind CommandKind => CommandKind.Text;
        public virtual string CommandText { get; set; }
    }
}
