using Microsoft.EntityFrameworkCore;
using TaxCalculator.API.Data;
using PaySpace.Calculator.Services;

var builder = WebApplication.CreateBuilder(args);

// Register memory cache
builder.Services.AddMemoryCache();

// Register tax calculators
builder.Services.AddScoped<ProgressiveTaxCalculator>();
builder.Services.AddScoped<FlatRateTaxCalculator>();
builder.Services.AddScoped<FlatValueTaxCalculator>();

// Register services
builder.Services.AddScoped<ITaxCalculatorService, TaxCalculatorService>();

// Add services to the container.
builder.Services.AddControllers();

// Add Entity Framework Core and configure the connection string
// Configure DbContext to use SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CalculatorDatabase")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Ensure the database is created and migrations are applied
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.Run();
