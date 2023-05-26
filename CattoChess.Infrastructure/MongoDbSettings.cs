namespace CattoChess.Infrastructure;

public sealed class MongoDbSettings
{
    public string DatabaseName { get; set; } = String.Empty;
    public string ConnectionString { get; set; } = String.Empty;
}