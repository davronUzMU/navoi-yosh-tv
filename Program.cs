
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Minio;
using onlatn_tv_project.Data;
using onlatn_tv_project.Repositories;
using onlatn_tv_project.Services;
using System.Text;

namespace onlatn_tv_project
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Env.Load();
            var builder = WebApplication.CreateBuilder(args);


            string? connectionString = Env.GetString("CONNECTIONSTRINGS__WEBAPIDATABASE");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));


            var userName = Env.GetString("ADMIN__USERNAME");
            var password = Env.GetString("ADMIN__PASSWORD");
            var secretKey = Env.GetString("JWTSETTINGS__SECRETKEY");
            var issuer = Env.GetString("JWTSETTINGS__ISSUER");
            var audience = Env.GetString("JWTSETTINGS__AUDIENCE");
            var tokenLifetime = Env.GetInt("JWTSETTINGS__TOKENLIFETIME");


            var endpoint = Env.GetString("MINIO_ENDPOINT");
            var accessKey = Env.GetString("MINIO_ACCESS_KEY");
            var secretKeyMinio = Env.GetString("MINIO_SECRET_KEY");
            var secure = bool.Parse(Env.GetString("MINIO_SECURE") ?? "true");


            builder.Services.AddSingleton<MinioClient>(_ =>
                                  (MinioClient)new MinioClient()
                                   .WithEndpoint(endpoint)
                                   .WithCredentials(accessKey, secretKeyMinio)
                                   .WithSSL(secure)
                                   .Build());


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("navoiyKengash", policyBuilder =>
                {
                    policyBuilder.WithOrigins("http://localhost:3000",
                           "https://nyotv.uz",
                           "https://api.nyotv.uz")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });


            var key = Encoding.UTF8.GetBytes(secretKey);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = issuer,
                        ValidateAudience = true,
                        ValidAudience = audience,
                        ValidateLifetime = true
                    };
                });

            builder.Services.AddScoped<IBlockBackRepository, BlockBackTVRepository>();
            builder.Services.AddScoped<IBlockTVRepository, BlockTVRepository>();
            builder.Services.AddScoped<IShowsBackTVRepository, ShowsBackTVRepository>();
            builder.Services.AddScoped<IShowsRepository, ShowsRepository>();
            builder.Services.AddScoped<IImageRepository, ImageRepository>();
            builder.Services.AddScoped<INewsBackRepository, NewsBackRepository>();
            builder.Services.AddScoped<INewsRepository, NewsRepository>();
            builder.Services.AddScoped<ITVProgramRepository, TVProgramRepository>();

            builder.Services.AddScoped<IBlockBackService, BlockBackService>();
            builder.Services.AddScoped<IBlockService, BlockService>();
            builder.Services.AddScoped<IShowsBackService, ShowsBackService>();
            builder.Services.AddScoped<IShowsService, ShowsService>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<INewsBackService, NewsBackService>();
            builder.Services.AddScoped<INewsService, NewsService>();
            builder.Services.AddScoped<ITVProgramService, TVProgramService>();


            builder.Services.AddScoped<JwtService>(
               JwtService =>
               {
                   return new JwtService(userName, password, secretKey, issuer, audience, tokenLifetime);
               }
             );




            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseCors("navoiyKengash");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
