using System.Data;
using Finazzy.Users.Application;
using Finazzy.Users.Application.Behaviors;
using Finazzy.Users.Domain.Abstractions;
using Finazzy.Users.Infrastructure;
using Finazzy.Users.Infrastructure.Repositories;
using Finazzy.Users.Presentation;
using Finazzy.WebApi.Middleware;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Finazzy.WebApi;

public class Startup
{
    public Startup(IConfiguration configuration) => Configuration = configuration;

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddProblemDetails();

        // Add services to the container.
        services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddControllers();

        services
            .AddUserApplication()
            .AddUserInfrastructure()
            .AddUserPresentation();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UserValidationBehavior<,>));

        services.AddDbContext<UserApplicationDbContext>(builder =>
            builder.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUnitOfWork>(
            factory => factory.GetRequiredService<UserApplicationDbContext>());

        services.AddScoped<IDbConnection>(
            factory => factory.GetRequiredService<UserApplicationDbContext>().Database.GetDbConnection());

        services.AddTransient<ExceptionHandlingMiddleware>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));
        }

        app.UseSerilogRequestLogging();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}