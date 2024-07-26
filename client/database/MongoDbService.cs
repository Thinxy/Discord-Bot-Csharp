using MongoDB.Driver;

public class DatabaseService
{
    private readonly IMongoDatabase _database;

    public DatabaseService(string connectionURI, string databaseName)
    {
        try
        {
            var client = new MongoClient(connectionURI);
            _database = client.GetDatabase(databaseName);
            Console.WriteLine("[DATABASE] Conectado com sucesso ao MongoDB.");
        }
        catch (Exception error)
        {
            Console.WriteLine($"[ERROR] Erro ao conectar ao MongoDB: {error.Message}");
            throw;
        }
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        try
        {
            var collection = _database?.GetCollection<T>(collectionName);

            if (collectionName == "guilds")
            {
                return collection!;
            };

            Console.WriteLine($"[DATABASE] Acessando collection: {collectionName}");

#pragma warning disable CS8603
            return collection;
        }
        catch (Exception error)
        {
            Console.WriteLine($"[ERROR] Erro ao tentar acessar collection: {error.Message}");
            return null;
        }
    }
}
