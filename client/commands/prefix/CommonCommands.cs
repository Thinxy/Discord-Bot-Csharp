using System.Globalization;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace VioletExtends.prefixCommands
{
    public class CommonCommands : BaseCommandModule
    {
        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            try
            {
                int websocket_latency = ctx.Client.Ping;
                var message_latency = DateTimeOffset.UtcNow - ctx.Message.Timestamp;
                string formatted_message_latency = message_latency.TotalMilliseconds.ToString("F2", CultureInfo.InvariantCulture);

                await ctx.RespondAsync(content: $"🏓 Pong {ctx.User.Mention}! Meu ping com a conexão do Discord está em `{websocket_latency}ms`!\n\n**📌 Latência com o Servidor:** `{formatted_message_latency}ms`");
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
    }
}