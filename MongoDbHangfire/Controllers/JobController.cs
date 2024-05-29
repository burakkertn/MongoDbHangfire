using Microsoft.AspNetCore.Mvc;
using MongoDbHangfire.Jobs;


namespace MongoDbHangfire.Controllers
{
    public class JobController : Controller
    {
        private readonly TestJob _testJob;

        public JobController(TestJob testJob)
        {
            _testJob = testJob;
        }

        #region ExecuteJob
        public async Task<IActionResult> ExecuteaaaaJob()
        {
            await _testJob.MyJob();
            return Json(true);
        }
        #endregion



    }
}
