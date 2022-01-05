using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
const string _apiVersion = "v1";
// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
#region Swagger:
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(_apiVersion, new OpenApiInfo
    {
        Version = "v1",
        Title = "Blazor Employee",
        Description = "Web API Blazor Employee",
        TermsOfService = new Uri("http://dbencoplanet.com"),
        Contact = new OpenApiContact
        {
            Name = "Bernard Amaeme",
            Email = "bernardamaeme@gmail.com",
            Url = new Uri("http://dbencoplanet.com"),
        },
        License = new OpenApiLicense
        {
            Name = "A Product of Employee List ",
            Url = new Uri("https://client.com"),
        }
    });
    options.DocInclusionPredicate((docName, description) => true);



    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

});
#endregion

// Rest of the code
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"{_apiVersion}/swagger.json", "Employee Management");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();

#region Global Cors Polic

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

#endregion

app.Run();
