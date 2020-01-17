using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Services.Managers.Interfaces;
using Services.Identity.Implementations;
using Data;
using Services.CustomModels;
using Microsoft.OpenApi.Models;
using System.Linq;
using Services.Managers.Implementations;

namespace WebApplication
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
			services.Configure<TokenModel>(Configuration.GetSection("tokenManagement"));
			var token = Configuration.GetSection("tokenManagement").Get<TokenModel>();

			
			
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
	.AddJwtBearer(options =>
	{
		options.SaveToken = true;
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
			ValidateIssuer = false,
			ValidateAudience = false,
			ValidateLifetime = true,

			ValidIssuer = "http://localhost:5000",
			ValidAudience = "http://localhost:5000",
		};
	});
			services.AddRouting();

			services.AddAutoMapper(typeof(Startup));
			services.AddControllers();
			services.AddAuthorization();
			

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchoolBook", Version = "v1" });
				c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = "JWT authorization",
					Name="Authorization",
					In=ParameterLocation.Header,
					Type=SecuritySchemeType.ApiKey
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{new OpenApiSecurityScheme{Reference = new OpenApiReference
					{
						Id = "Bearer",
						Type = ReferenceType.SecurityScheme
					}}, new List<string>()}
				});
			});
			
			services.AddScoped<SchoolBookContext>();
			services.AddScoped<IUserManager, UserManager>();
			services.AddScoped<IParentManager, ParentManager>();
			services.AddScoped<IStudentManager, StudentManager>();
			services.AddScoped<ITeacherManager, TeacherManager>();
			services.AddScoped<IGradeManager, GradeManager>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{



			app.UseHttpsRedirection();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("./v1/swagger.json", "SchoolBook V1");
				});
			}


			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	
	}
}
