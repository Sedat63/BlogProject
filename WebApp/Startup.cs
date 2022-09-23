using Entities.Concrete;
using Entities.Jwt;
using Entities.Mapping;
using Entities.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace WebApp
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
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins(new string[] { "https://localhost:3000" }));
            });


            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                     policy => policy.RequireRole("Admin"));
                
            });

            #region JWT TOKEN CONFIG
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = tokenOptions.Audience,
                    ValidIssuer = tokenOptions.Issuer,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
                };
            });
            #endregion

            #region VALİDATOR
            services.AddScoped<IValidator<Tag>, TagValidator>();
            services.AddScoped<IValidator<Subscribe>, SubscribeValidator>();
            services.AddScoped<IValidator<SocialMedia>, SocialMediaValidator>();
            services.AddScoped<IValidator<Category>, CategoryValidator>();
            services.AddScoped<IValidator<Article>, ArticleValidator>();
            services.AddScoped<IValidator<Comment>, CommentValidator>();
            services.AddScoped<IValidator<User>, UserValidator>();
            #endregion

            #region IOC
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<JwtHelper, JwtHelper>();
            #endregion


            services.AddAutoMapper(typeof(TagProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();// uygulama wwwroot'daki static dosyaları kullanması için kod.

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder.WithOrigins(new string[] { "http://localhost:3000" })
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
