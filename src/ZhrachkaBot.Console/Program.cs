using System;
using Microsoft.Extensions.DependencyInjection;
using ZhrachkaBot.Abstractions;
using ZhrachkaBot.Domain;
using ZhrachkaBot.Domain.Commands;
using ZhrachkaBot.Domain.Data;

namespace ZhrachkaBot.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = RegisterDependencies();

            System.Console.WriteLine("Bot initialized");

            var manager = provider.GetService<ICommandManager>();
            var executor = provider.GetService<ICommandExecutor>();

            System.Console.WriteLine("Deps instantiated");

            var textCommand = new TextCommand
            {
                CommandId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                CommandText = "hi all"
            };
            var textCommandResult = new TextCommandResult
            {
                ResultId = Guid.NewGuid(),
                CommandId = textCommand.CommandId,
                CreatedDate = DateTime.Now,
                Text = "you are welcome"
            };

            manager.Register(textCommand, textCommandResult);

            System.Console.WriteLine("Command registered");

            var executionResult = executor.Execute(textCommand);
            System.Console.WriteLine("Command executed");
            System.Console.WriteLine((executionResult as TextCommandResult)?.Text);
            System.Console.ReadLine();
        }

        private static IServiceProvider RegisterDependencies()
        {
            var services = new ServiceCollection();

            services.AddTransient<ICommandExecutor, CommandExecutor>();
            services.AddTransient<ICommandManager, CommandManager>();
            services.AddSingleton<ICommandRepository, InMemoryCommandRepository>();
            services.AddSingleton<ICommandResultRepository, InMemoryCommandResultRepository>();
            services.AddTransient<ICommandResultProvider, CommandTextResultProvider>();
            services.AddTransient<ICommandResultProviderResolver, CommandResultProviderResolver>();

            return services.BuildServiceProvider();
        }
    }
}