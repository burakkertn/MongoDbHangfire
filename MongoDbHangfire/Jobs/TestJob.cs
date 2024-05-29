namespace MongoDbHangfire.Jobs
{
    public class TestJob
    {

        public async  Task<Task> MyJob()
        {
            return Task.CompletedTask;
        }
    }
}
