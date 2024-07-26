using DSharpPlus;
using DSharpPlus.CommandsNext;
using VioletExtends.prefixCommands;

namespace VioletExtends.handlers
{
    public class CommandsHandler
    {
        public static void RegisterCommands(DiscordClient discord)
        {
            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new[] { "v" },
                EnableMentionPrefix = false,
                EnableDms = true,
                EnableDefaultHelp = false
            };

            var commandExtensions = discord.UseCommandsNext(commandsConfig);
            commandExtensions.RegisterCommands<CommonCommands>();

            Console.WriteLine("[CLIENT] Comandos carregados com sucesso na Shard Principal.");
        }
    }
}
