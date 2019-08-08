using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZhrachkaBot.Abstractions;

namespace ZhrachkaBot.Domain.Data
{
    public class InMemoryCommandRepository : ICommandRepository
    {
        private static readonly IDictionary<Guid, ICommand> Commands;

        static InMemoryCommandRepository()
        {
            Commands = new Dictionary<Guid, ICommand>();
        }

        public void Add(ICommand command)
        {
            if (Commands.ContainsKey(command.CommandId))
            {
                // todo: handle
            }

            Commands[command.CommandId] = command;
        }

        public Task AddAsync(ICommand command)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(ICommand command)
        {
            if (!Commands.ContainsKey(command.CommandId))
            {
                // todo: handle
            }

            Commands.Remove(command.CommandId);
        }

        public Task RemoveAsync(ICommand command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ICommand> GetAll()
        {
            return Commands.Values;
        }

        public Task<IEnumerable<ICommand>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public ICommand GetById(Guid id)
        {
            return !Commands.TryGetValue(id, out _) ? null : Commands[id];
        }

        public Task<ICommand> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
