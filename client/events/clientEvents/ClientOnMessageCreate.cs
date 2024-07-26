using DSharpPlus;
using DSharpPlus.EventArgs;

namespace VioletExtends.events
{
    public partial class Events
    {
        public static async Task ClientOnMessageCreate(DiscordClient sender, MessageCreateEventArgs args)
        {
            if (args.Author.IsBot)
                return;

            var botMention = $"<@!{sender.CurrentUser.Id}>";
            var botMention2 = $"<@{sender.CurrentUser.Id}>";

            if (args.Message.Content.Contains(botMention) || args.Message.Content.Contains(botMention2))
            {
                await args.Message.RespondAsync($"Olá {args.Author.Mention}! Eu me chamo **Violet** e sou uma bot feita para trazer alegria para o servidor com meus sistemas de economia!");
            }

            return;
        }
    }
}