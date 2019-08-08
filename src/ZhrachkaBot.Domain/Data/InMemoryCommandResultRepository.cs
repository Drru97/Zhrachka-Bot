using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZhrachkaBot.Abstractions;

namespace ZhrachkaBot.Domain.Data
{
    public class InMemoryCommandResultRepository : ICommandResultRepository
    {
        private static readonly IDictionary<Guid, ICommandResult> CommandResults;

        static InMemoryCommandResultRepository()
        {
            CommandResults = new Dictionary<Guid, ICommandResult>();
        }

        public void Add(ICommandResult commandResult)
        {
            if (CommandResults.ContainsKey(commandResult.ResultId))
            {
                // todo: handle case when result already exists
            }

            CommandResults[commandResult.ResultId] = commandResult;
        }

        public Task AddAsync(ICommandResult commandResult)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(ICommandResult commandResult)
        {
            if (!CommandResults.ContainsKey(commandResult.ResultId))
            {
                // todo: handle case when result does not exist
            }

            CommandResults.Remove(commandResult.ResultId);
        }

        public Task RemoveAsync(ICommandResult commandResult)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ICommandResult> GetAll()
        {
            return CommandResults.Values;
        }

        public Task<IEnumerable<ICommandResult>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult GetById(Guid id)
        {
            return !CommandResults.TryGetValue(id, out _) ? null : CommandResults[id];
        }

        public Task<ICommandResult> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICommandResult GetLinkedWithCommand(ICommand command)
        {
            return CommandResults.Values.SingleOrDefault(cr => cr.CommandId == command.CommandId);
        }
    }
}
