var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register calculator services
builder.Services.AddScoped<Calculator.Services.AdditionService>();
builder.Services.AddScoped<Calculator.Services.SubtractionService>();
builder.Services.AddScoped<Calculator.Services.MultiplicationService>();
builder.Services.AddScoped<Calculator.Services.DivisionService>();
builder.Services.AddScoped<Calculator.Services.ModuloService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calculator}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
