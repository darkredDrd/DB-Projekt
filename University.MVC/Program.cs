using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using MongoDB.Driver;

using StackExchange.Redis;

using University.Application.Marks;
using University.Persistence;

namespace University.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<UniversityContext>(
                dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("UniversityDb")));

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateMarkCommand>());

            builder.Services.Configure<MongoDbSettings>(mongoDbSettings => builder.Configuration.GetSection("MongoDbSettings").Bind(mongoDbSettings));

            builder.Services.AddScoped(serviceProvider =>
            {
                var mongoDbSettings = serviceProvider.GetService<IOptions<MongoDbSettings>>().Value;
                var client = new MongoClient(mongoDbSettings.ConnectionString);
                var mongoDatabase = client.GetDatabase(mongoDbSettings.UniversityDbName) as MongoDatabaseBase;

                return mongoDatabase;
            });

            builder.Services.AddStackExchangeRedisCache(
                redisCacheOptions =>
                {
                    var redisSettings = builder.Configuration.GetSection("RedisSettings").Get<RedisSettings>();
                    redisCacheOptions.ConfigurationOptions = new ConfigurationOptions
                    {
                        AllowAdmin = true,
                        DefaultDatabase = 0,
                        Ssl = false,
                        Password = redisSettings.Password,
                        EndPoints = { { redisSettings.Host, redisSettings.Port } }
                    };
                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Students}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
