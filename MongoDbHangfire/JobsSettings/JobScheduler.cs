using Hangfire;
using MongoDbHangfire.Controllers;

namespace MongoDbHangfire.JobsSettings
{
    public class JobScheduler
    {
        private readonly IServiceProvider _serviceProvider;

        public JobScheduler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void ConfigureJobs()
        {

        }
    }
}
