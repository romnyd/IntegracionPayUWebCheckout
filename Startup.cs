﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsopagosPayU.Models;
using AsopagosPayU.Repositories;
using AsopagosPayU.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AsopagosPayU
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Contexto>(x => x.UseMySql("server=www.asopagos.com;database=asopagos_legalAsop;uid=asopagos_fredyv;pwd=3ewiQm7u"));
            // services.AddDbContext<Contexto>(x => x.UseMySql("server=localhost;database=ASOPAGOSPAYU;uid=root;pwd=123456"));
            // services.AddDbContext<Contexto>(x => x.UseSqlite("Data Source=asopagospayu.db"));
            // Add framework services.
            services.AddMvc();

            // Registro de Servicios/Repositorios para el IOC. Si el proyecto crece y se necesitan muchas más clases, usar AUTOFAC y registrar estos servicios en una clase aparte. Documentación: http://docs.autofac.org/en/latest/integration/aspnetcore.html 
            services.AddTransient<IServicioCliente, ServicioCliente>();
            services.AddTransient<IRepositorioCliente, RepositorioCliente>();
            services.AddTransient<IServicioTransaccion, ServicioTransaccion>();
            services.AddTransient<IRepositorioTransaccion, RepositorioTransaccion>();
            services.AddTransient<IServicioAplicativo, ServicioAplicativo>();
            services.AddTransient<IRepositorioAplicativo, RepositorioAplicativo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
