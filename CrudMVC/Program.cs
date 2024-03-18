using CrudMVC.Data;
using CrudMVC.Helper;
using CrudMVC.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Permite a inje��o de depend�ncia do contexto http
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Permite a inje��o de depend�ncias
builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ISessao, Sessao>();

//Adicionamos uma sess�o
builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

//Aqui � configurado a conex�o do banco de dados ao iniciar a aplica��o
builder.Services.AddEntityFrameworkSqlServer().
    AddDbContext<BancoContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Ao implementarmos o uso de sess�es, configuramos a sess�o para ser usada
app.UseSession();
//A rota padr�o ao inicializar a aplica��o � a rota de Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

