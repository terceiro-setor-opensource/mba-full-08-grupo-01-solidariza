using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Solidariza.Application.Interfaces;
using Solidariza.Application.Services;
using Solidariza.Domain.Interfaces;
using Solidariza.Repository.Context;
using Solidariza.Repository.Interfaces;
using Solidariza.Repository.Repositories;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<SolidarizadbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<ISolicitacaoService, SolicitacaoService>();
        services.AddScoped<ISolicitacaoRepository, SolitacaoRepository>();
        services.AddScoped<IAbrigoRepository, AbrigoRepository>();
        services.AddScoped<IDoadorService, DoadorService>();
        services.AddScoped<IDoadorRepository, DoadorRepository>();
        
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseAuthentication();
        //app.MapControllers();
    }
}
