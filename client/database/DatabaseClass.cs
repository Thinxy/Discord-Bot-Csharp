using MongoDB.Driver;
using VioletExtends.client;

namespace VioletExtends.database
{
    public class DatabaseCluster
    {
        public async Task<Type> getDocument<Type>(string id, string type)
        {
            try
            {
                IMongoCollection<Type> collection;

                switch (type)
                {
                    case "users":
                        collection = Program._mongoDbService!.GetCollection<Type>("users");
                        break;
                    default:
                        throw new Exception("Invalid document type.");
                }

                var filter = Builders<Type>.Filter.Eq("_id", id);
                var document = await collection.Find(filter).FirstOrDefaultAsync();

                if (document == null)
                {
                    var newDocument = Activator.CreateInstance<Type>();
                    var idProperty = typeof(Type).GetProperty("_id");
                    if (idProperty != null && idProperty.PropertyType == typeof(string))
                    {
                        idProperty.SetValue(newDocument, id);
                    }

                    await collection.InsertOneAsync(newDocument);
                    return newDocument;
                }

                return document;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error fetching document from the database: " + ex);
                throw;
            }
        }
    }
}
