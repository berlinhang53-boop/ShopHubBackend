using Microsoft.EntityFrameworkCore;
using ShopHub.API.Data;

var builder = WebApplication.CreateBuilder(args);


// =========================
// DATABASE
// =========================

builder.Services.AddDbContext<ShopHubDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DefaultConnection"
        )
    )
);


// =========================
// CONTROLLERS
// =========================

builder.Services.AddControllers();


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("ReactPolicy", policy =>
//    {
//        policy
//            .WithOrigins("http://localhost:5175")
//            .AllowAnyHeader()
//            .AllowAnyMethod();
//    });
//});


builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:5173",
                "http://localhost:5175"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// =========================
// OPENAPI
// =========================

builder.Services.AddOpenApi();


var app = builder.Build();


// =========================
// HTTP PIPELINE
// =========================

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();
app.UseCors("ReactPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();