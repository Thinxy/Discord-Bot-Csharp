using DSharpPlus;
using DSharpPlus.SlashCommands;
using VioletExtends.slashCommands;

namespace VioletExtends.handlers
{
    public class SlashCommandsHandler
    {
        public static void RegisterSlashCommands(DiscordClient discord)
        {
            var slashConfig = new SlashCommandsConfiguration();

            var slashCommands = discord.UseSlashCommands(slashConfig);
            slashCommands.RegisterCommands<CommonSlashCommands>();

            Console.WriteLine("[CLIENT] Slash commands registrado com sucesso na shard principal.");
        }
    }
}