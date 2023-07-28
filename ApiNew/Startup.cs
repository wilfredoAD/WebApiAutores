using Microsoft.EntityFrameworkCore;

namespace ApiNew
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ApplicationDbcontext>(option =>
              option.UseSqlServer(Configuration.GetConnectionString("defauldConnetion")));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(S =>
            {
                S.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ApiNew", Version = "V1" });
            });
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        


    }
}
}
