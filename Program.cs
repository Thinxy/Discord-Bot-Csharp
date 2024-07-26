using DSharpPlus;
using VioletExtends.package;
using VioletExtends.database;
using VioletExtends.events;
using VioletExtends.handlers;

namespace VioletExtends.client
{
    internal class Program
    {
        private static DiscordClient? _discord;
        public static DatabaseService? _mongoDbService;
        public static DatabaseCluster? _database;

        static async Task Main(string[] args)
        {
            DotEnv.Load();

            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = Environment.GetEnvironmentVariable("Token")!,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };

            _discord = new DiscordClient(discordConfig);

            _discord.Ready += Events.ClientOnReady;
            _discord.MessageCreated += Events.ClientOnMessageCreate;

            CommandsHandler.RegisterCommands(_discord);
            SlashCommandsHandler.RegisterSlashCommands(_discord);

            _mongoDbService = new DatabaseService(Environment.GetEnvironmentVariable("MongoURI")!, "nameDB");
            _database = new DatabaseCluster();

            await _discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}