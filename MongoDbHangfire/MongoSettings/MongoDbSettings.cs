namespace MongoDbHangfire.MongoSettings
{
    public class MongoDbSettings
    {
        public string? Username { get; init; }
        public string? Password { get; init; }

        public string? Host { get; init; }
        public int Port { get; init; }

        public string? Database { get; set; }
        public string? ConnectionString => $"mongodb://{Username}:{Password}@{Host}:{Port}/{Database}";
    }
}
