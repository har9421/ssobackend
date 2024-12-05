using SSO.Application.Extensions;
using SSO.Infrastructure.Data.Extensions;


using SSO.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(corsBuilder =>
    {
        corsBuilder.WithOrigins("http://localhost:3000", "https://localhost:5048")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddSwagger();

//builder.RegisterAuthentication();
builder.Services.AddApplicationServices();
builder.Services.AddDataServices(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
//app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();

