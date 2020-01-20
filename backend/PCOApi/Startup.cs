using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PCOApi.Context;
using PCOApi.Repository;
using PCOApi.Services;
using PCOApi.Utils;

namespace PCOApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PCO API", Version = "v1" });
            });

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<UsuarioContext>(
                    options => options.UseSqlServer(
                        Configuration.GetConnectionString("ConexaoPadrao")));

            services.AddHttpContextAccessor();

            var builder = new ContainerBuilder();

            builder.Populate(services);
            builder.RegisterType<UsuarioService>().As<IUsuarioService>();
            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>();

            builder.RegisterAssemblyTypes(typeof(RepositoryUsuarioContext<>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRepositoryUsuarioContext<>));

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(option => option.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });

        }
    }
}
