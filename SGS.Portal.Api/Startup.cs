﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SGS.Portal.Api.Services;

namespace SGS.Portal.Api
{
    public class Startup
    {
        private IConfiguration _config { get; }
        private IHostingEnvironment _env;

        public Startup(IConfiguration configuration
            , IHostingEnvironment environment)
        {
            _config = configuration;
            _env = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ISmsSender, SmsSender>();

            //CORS
            services.AddCors(cfg =>
            {

                cfg.AddPolicy("Portal", bldr =>
                {
                    bldr.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("https://sgs.portal");
                });

                cfg.AddPolicy("AnyGET", bldr =>
                {
                    bldr.AllowAnyHeader()
                        .WithMethods("GET")
                        .AllowAnyOrigin();
                });

                cfg.AddPolicy("Any", bldr =>
                {
                    bldr.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });

            });

            services.AddMvc()
                .AddJsonOptions(opt =>
                    opt.SerializerSettings.ReferenceLoopHandling
                    = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                    .AddXmlDataContractSerializerFormatters()// to add xml serializer
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/api/Errors/500");
                app.UseStatusCodePagesWithReExecute("/api/Errors/{0}");
            }

            app.UseMvc();
        }
    }
}