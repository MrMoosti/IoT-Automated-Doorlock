namespace Rfid.Persistence.MongoDb;

public struct DbConfigModel
{
    public string ConnectionString { get; }

    public DbConfigModel(string connectionString)
    {
        ConnectionString = connectionString;
    }
}