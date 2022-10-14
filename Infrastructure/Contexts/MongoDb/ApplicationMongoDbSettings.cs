using Application.Interfaces;

namespace Infrastructure.Contexts.MongoDb
{
    public class ApplicationMongoDbSettings:IMongoSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
