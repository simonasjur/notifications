using Newtonsoft.Json.Converters;
using NotificationScheduler.DataAccess;
using NotificationScheduler.Repository.Helpers;
using NotificationScheduler.Repository.Helpers.Settings;
using NotificationScheduler.Repository.Repositories;
using NotificationScheduler.Repository.Repositories.Interfaces;
using NotificationScheduler.Repository.UnitsOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEntityFramework(options => builder.Configuration.Bind(EntityFrameworkSettings.Position, options));
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IMarketRepository, MarketRepository>();
builder.Services.AddTransient<INotificationRepository, NotificationRepository>();
builder.Services.AddTransient<NotificationUnitOfWork>();
builder.Services.AddTransient<ScheduleDatesResolver>();

builder.Services.Configure<List<ScheduleSettings>>(builder.Configuration.GetSection(ScheduleSettings.Position));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
});
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenNewtonsoftSupport();

var app = builder.Build();

app.RunDatabaseMigrations();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();