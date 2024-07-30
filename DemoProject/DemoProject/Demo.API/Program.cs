using Demo.API.Interfaces;
using Demo.API;
using Demo.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Access configuration from the builder
var configuration = builder.Configuration;

// Configure database connection using Entity Framework Core
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
builder.Services.AddScoped<IDapperDbConnection, DapperDbConnection>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
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
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
