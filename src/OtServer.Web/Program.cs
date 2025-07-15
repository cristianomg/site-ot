using Microsoft.EntityFrameworkCore;
using OtServer.Domain.Repositories;
using OtServer.Infrasctruture;
using OtServer.Infrasctruture.Repositories;
using OtServer.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Configurar MySQL
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))
    )
);

// Injeção de dependência para o repositório de jogadores
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

// Serviço de status do servidor
builder.Services.AddScoped<ServerStatusService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
