using Infrastructure.Dependency;

namespace API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseService(Configuration);
        //services.ConfigureApplicaion();
        //services.ConfigureInfrastructure();
        //services.ConfigureSwagger(Configuration);

        //services.ConfigureEventBus(Configuration);
        //services.AddControllers(opt =>
        //{
        //    opt.Filters.Add(typeof(HttpGlobalExceptionFilter));
        //});

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
    }
}
