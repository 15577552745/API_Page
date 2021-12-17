using API_Page.data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;


namespace API_Page
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configure other services up here
            var multiplexer = ConnectionMultiplexer.Connect("81.69.245.185:6379,password=123123Root");
            services.AddSingleton<IConnectionMultiplexer>(multiplexer);
            
            
            var sqlConnection = Configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<ApiDBContent>(option => option.UseSqlServer(sqlConnection));
            services.AddMvc();
            services.AddControllers();
          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_Page", Version = "v1" });
            });

            //ע��cors
            services.AddCors(option => option.AddPolicy("any",build=>
                build.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
            );
            services.AddTransient<UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_Page v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //ע��Cors����
            app.UseCors("any");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
