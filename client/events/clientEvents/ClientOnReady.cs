using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace VioletExtends.events
{
    public partial class Events
    {
        public static async Task ClientOnReady(DiscordClient ctx, ReadyEventArgs args)
        {
            var activity = new DiscordActivity($"Vamos colher comigo?", ActivityType.Playing);
            await ctx.UpdateStatusAsync(activity, UserStatus.Online);

            Console.WriteLine($"[CLIENT] Conectado com sucesso à Gateway do Discord.");
        }
    }
}