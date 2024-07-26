using System.Globalization;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace VioletExtends.slashCommands
{
    public class CommonSlashCommands : ApplicationCommandModule
    {
        [SlashCommand(name: "ping", description: "veja a latência atual da conexão da Violet com o Discord.")]
        public async Task PingCommand(InteractionContext ctx)
        {
            try
            {
                int websocket_latency = ctx.Client.Ping;
                var message_latency = DateTimeOffset.UtcNow - ctx.Interaction.CreationTimestamp;
                string formatted_message_latency = message_latency.TotalMilliseconds.ToString("F2", CultureInfo.InvariantCulture);

                await ctx.CreateResponseAsync(
                    InteractionResponseType.ChannelMessageWithSource,
                    new DiscordInteractionResponseBuilder()
                    .WithContent($"🏓 Pong {ctx.User.Mention}! Meu ping com a conexão do Discord está em `{websocket_latency}ms`!\n\n**📌 Latência com o Servidor:** `{formatted_message_latency}ms`")
                    );
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
    }
}