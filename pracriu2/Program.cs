var builder = WebApplication.CreateBuilder(args);
//Debe ir en segundo lugar 
builder.Services.AddMvc();
var app = builder.Build();

//agg 3 configuraciones: 
//se borra hello world
//ahora agregar home
//contorllador de mvc en blanco

app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();
