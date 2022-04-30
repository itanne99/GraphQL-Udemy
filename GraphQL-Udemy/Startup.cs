using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL_Udemy.Data;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Mutation;
using GraphQL_Udemy.Query;
using GraphQL_Udemy.Schema;
using GraphQL_Udemy.Services;
using GraphQL_Udemy.Type;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.Types;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphQL_Udemy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            //Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://dev-19069193.okta.com/oauth2/default";
                options.Audience = "api://default";
                options.RequireHttpsMetadata = false; // TODO: May need to remove
            });

            //Genre Services
            services.AddTransient<IGenre, GenreService>();
            services.AddTransient<GenreType>();
            services.AddTransient<GenreInputType>();
            services.AddTransient<GenreQuery>();
            services.AddTransient<GenreMutation>();
            
            //Artist Services
            services.AddTransient<IArtist, ArtistService>();
            services.AddTransient<ArtistType>();
            services.AddTransient<ArtistInputType>();
            services.AddTransient<ArtistQuery>();
            services.AddTransient<ArtistMutation>();
            
            
            //Album Services
            services.AddTransient<IAlbum, AlbumService>();
            services.AddTransient<AlbumType>();
            services.AddTransient<AlbumInputType>();
            services.AddTransient<AlbumQuery>();
            services.AddTransient<AlbumMutation>();
            
            
            //Song Services
            services.AddTransient<ISong, SongService>();
            services.AddTransient<SongType>();
            services.AddTransient<SongInputType>();
            services.AddTransient<SongQuery>();
            services.AddTransient<SongMutation>();
            
            //Log Services
            services.AddTransient<ILog, LogService>();
            services.AddTransient<LogType>();
            services.AddTransient<LogQuery>();
            
            //Root Services
            services.AddTransient<RootQuery>();
            services.AddTransient<RootMutation>();
            services.AddTransient<ISchema, RootSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;
            }).AddSystemTextJson();

            services.AddDbContext<GraphQLDbContext>(option => option.UseNpgsql("Host=localhost; Database=graphQL; Username=JimmyCricket; Password=AppleBombs4152"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GraphQLDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/api",
                    Path = "/playground"
                });
            }

            dbContext.Database.EnsureCreated();
            app.UseAuthentication();
            app.UseGraphQL<ISchema>("/api");
            //app.UseGraphQL<ISchema>();
        }
    }
}