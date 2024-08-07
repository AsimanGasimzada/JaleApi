using Jale_Xanm.Contexts;
using Jale_Xanm.Extensions;
using Jale_Xanm.Repositories.Implmentations;
using Jale_Xanm.Repositories.Implmentations.Generic;
using Jale_Xanm.Repositories.Interfaces;
using Jale_Xanm.Repositories.Interfaces.Generic;
using Jale_Xanm.Services.Implmentations;
using Jale_Xanm.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Jale_Xanm;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IStudentRepository, StudentRepository>();


        builder.Services.AddScoped<IStudentService, StudentService>();

        builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseHttpsRedirection();

        app.UseAuthorization();
        //app.AddExceptionHandlerService();

        app.MapControllers();

        app.Run();
    }
}
