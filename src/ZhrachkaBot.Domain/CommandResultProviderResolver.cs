using System;
using System.Collections.Generic;
using System.Linq;
using ZhrachkaBot.Abstractions;

namespace ZhrachkaBot.Domain
{
    public class CommandResultProviderResolver : ICommandResultProviderResolver
    {
        private IEnumerable<ICommandResultProvider> _providers;

        public CommandResultProviderResolver(IEnumerable<ICommandResultProvider> providers)
        {
            _providers = providers;
        }

        public ICommandResultProvider Resolve(ICommand command)
        {
            var provider = _providers.FirstOrDefault(p => p.CommandKind == command.CommandKind);
            if (provider == null)
            {
                // todo: handle
                throw new Exception("Can't find result provider for that king of command.");
            }

            return provider;
        }
    }
}
