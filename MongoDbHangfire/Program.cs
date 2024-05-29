using Hangfire.Mongo.Migration.Strategies.Backup;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo;
using Hangfire;
using MongoDB.Driver;
using MongoDbHangfire.JobsSettings;
using MongoDbHangfire.MongoSettings;
using MongoDbHangfire.Jobs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

var mongoDbSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
var mongoUrl = new MongoUrlBuilder
{
    Username = mongoDbSettings.Username,
    Password = mongoDbSettings.Password,
    Server = new MongoServerAddress(mongoDbSettings.Host, mongoDbSettings.Port),
    DatabaseName = mongoDbSettings.Database
}.ToMongoUrl();

var migrationOptions = new MongoMigrationOptions
{
    BackupStrategy = new CollectionMongoBackupStrategy(),
    MigrationStrategy = new MigrateMongoMigrationStrategy()
};

var mongoStorageOptions = new MongoStorageOptions
{
    MigrationOptions = migrationOptions
};

builder.Services.AddHangfire(config =>
{
    config.UseMongoStorage(mongoUrl.ToString(), mongoStorageOptions);
});

builder.Services.AddHangfireServer(options =>
{
    options.Queues = new[] { "default" };
    var queuePollInterval = builder.Configuration["HangfireSettings:QueuePollInterval"];
    options.SchedulePollingInterval = !string.IsNullOrEmpty(queuePollInterval)
        ? TimeSpan.Parse(queuePollInterval)
        : TimeSpan.FromMinutes(1);
    options.WorkerCount = 99;
});

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<TestJob>();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseHangfireDashboard();

var serviceProvider = builder.Services.BuildServiceProvider();
var jobScheduler = new JobScheduler(serviceProvider);
jobScheduler.ConfigureJobs();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
