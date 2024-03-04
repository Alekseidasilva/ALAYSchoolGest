using ALAYSchoolGest.Infra.CrossCutting.Helpers._03_Domain;
using ALAYSchoolGest.Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.IdentityModel.Tokens;
using System.IO.Compression;
using System.Text;
using System.Text.Json.Serialization;

namespace ALAYSchoolGest.Api.Extensions;

public static class BuilderExtension
{

    #region Builder


    public static void AddMemoryCache(this WebApplicationBuilder builder)
    {
        builder.Services.AddMemoryCache();
    }
    public static void AddCompression(this WebApplicationBuilder builder)
    {
        builder.Services.AddResponseCompression(options =>
        {
            //options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
            //options.Providers.Add<CustomCompressionProvider>();
        });

        builder.Services.Configure<GzipCompressionProviderOptions>(options =>
        {
            options.Level = CompressionLevel.Optimal;
        });
    }
    public static void AddControllers(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                //Configuracoes de Comportamento da API
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddJsonOptions(x =>//Resolvendo Problema de Serializacao de Objectos Json e Vice Versa; definimos quais opces de Json vamos utilizar
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });

    }

    public static void AddServices(this WebApplicationBuilder builder)
    {

        var connectionString = builder.Configuration.GetConnectionString("SQLServer");
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            //options.UseSqlServer(connectionString);
        });
        //builder.Services.AddTransient();//Sempre cria um novo
        //builder.Services.AddScoped();   //Transacao
        //builder.Services.AddSingleton(); //singleton-> 1 por App
        //builder.Services.AddTransient<TokenService>();
        //builder.Services.AddTransient<EmailService>();



        //Iniciando Modulo de Autenticacao e Autorizacao
        //Iniciando Modulo Configuracoes--Entendento o AppSettings
    }
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.Database.ConnectionStrings = builder.Configuration.GetConnectionString("DefaultConnection") ?? String.Empty;
        Configuration.Secrets.ApiKey = builder.Configuration.GetSection("Secrets").GetValue<string>("ApiKey") ?? String.Empty;
        Configuration.Secrets.JwtPrivateKey = builder.Configuration.GetSection("Secrets").GetValue<string>("JwtPrivateKey") ?? String.Empty;
        Configuration.Secrets.PasswordSaltKey = builder.Configuration.GetSection("Secrets").GetValue<string>("PasswordSaltkey") ?? String.Empty;

        Configuration.SendGrid.ApiKey = builder.Configuration.GetSection("SendGrid").GetValue<string>("ApiKey") ?? String.Empty;


        Configuration.Email.DefaultFromName = builder.Configuration.GetSection("Email").GetValue<string>("DefaultFromName") ?? String.Empty;
        Configuration.Email.DefaultFromEmail = builder.Configuration.GetSection("Email").GetValue<string>("DefaultFromEmail") ?? String.Empty;
    }
    public static void AddDatabase(this WebApplicationBuilder builder)
    {
        //builder.Services.AddDbContext<AppDbContext>(x =>
        //    //x.UseSqlServer(Configuration.Database.ConnectionStrings, b => b.MigrationsAssembly("JwtStore.api")));
    }

    public static void AddJwtAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.Secrets.ApiKey)),
                    ValidateIssuer = false,
                };
            });
        builder.Services.AddAuthorization();

    }

    public static void AddMediatR(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(x
            => x.RegisterServicesFromAssembly(typeof(Configuration).Assembly));
    }

    #endregion
    #region App



    #endregion



}