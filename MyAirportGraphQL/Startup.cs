using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using HL.MyAirport.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyAirport.GraphQL;
using MyAirportGraphQL.GraphQLType;

namespace MyAirportGraphQL
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
            services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService)); 
            services.AddScoped<BagageType>(); 
            services.AddScoped<VolType>(); 
            services.AddScoped<AirportQuery>(); 
            services.AddScoped<AirportSchema>(); 
            services.AddGraphQL(options => { 
                    options.EnableMetrics = true; 
                    options.ExposeExceptions = true; });

            services.AddDbContext<MyAirportContext>(option => option.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyAirport;Integrated Security=True"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphQL<AirportSchema>();

            app.UseGraphiQLServer(new GraphQL.Server.Ui.GraphiQL.GraphiQLOptions { GraphiQLPath = "/graphql" });

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
