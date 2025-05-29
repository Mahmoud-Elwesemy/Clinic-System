
using Clinic.Core.Application.Abstraction;
using Clinic.Core.Application;
using Clinic.Core.Application.Mapping;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities_Helper;
using Clinic.Infrastructure.Presistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Clinic.Core.Domin.UnitOfWork.Contract;
using Clinic.Infrastructure.Presistence.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Clinic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services
            builder.Services.AddControllers();
            //builder.Services.AddOpenApi();

            builder.Services.AddDbContext<ApplicationContext>(options =>
                {
                    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("con"));
                });

            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            builder.Services.AddScoped(typeof(IUnitOfWork),typeof(UnitOfWork));
            builder.Services.AddScoped(typeof(IServiceManager),typeof(ServiceManager));
            builder.Services.AddHttpContextAccessor();
           


            builder.Services.AddIdentity<ApplicationUser,ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationContext>().
                AddDefaultTokenProviders();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            #region Configure ]Authentication
            var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
            if(jwtSettings == null)
            {
                throw new Exception("JWT settings are not configured properly.");
            }
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey!))
                };
            });

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                //options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
            });
            #endregion

            #region Configure Of Swagger
            // for testing
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1",new OpenApiInfo
                    {
                        Title = "Clinic Management System API",
                        Version = "v1",
                        Description = "API for handling users, roles, and authentication"
                    });

                    // ✅ Configure JWT Bearer token support
                    options.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Enter JWT token in the format: Bearer {your token}"
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                    });
                }); 
            #endregion

            #endregion

            var app = builder.Build();

            #region Configure Middleware
            if(app.Environment.IsDevelopment())
            {              
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers(); 
            #endregion

            app.Run();
        }
    }
}
