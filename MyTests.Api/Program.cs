using Microsoft.EntityFrameworkCore;
using MyTests.DAL;
using MyTests.DAL.Extentions;
using MyTests.DAL.Repositories;
using MyTests.Domain.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyTestsContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//i dont want to add it manually
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyTestsContext>();
    db.EnsureSeedData();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();