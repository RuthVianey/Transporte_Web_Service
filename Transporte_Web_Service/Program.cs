using Microsoft.EntityFrameworkCore;
using Transporte_Web_Service.Bussines;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<MiDbContext>(options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();



//builder.Services.AddScoped<CatalogosBS>();
//builder.Services.AddScoped<CatalogosDAC>();

builder.Services.AddScoped<UsuariosBS>();
builder.Services.AddScoped<UsuariosDAC>();

builder.Services.AddScoped<GeneralesBS>();
builder.Services.AddScoped<GeneralesDAC>();

builder.Services.AddScoped<AuthBussines>();
builder.Services.AddScoped<AuthDAL>();

builder.Services.AddScoped<DashboardBussines>();
builder.Services.AddScoped<DashboardDAL>();

builder.Services.AddScoped<ClientesBussines>();
builder.Services.AddScoped<ClientesDAL>();

builder.Services.AddScoped<UnidadesBussines>();
builder.Services.AddScoped<UnidadesDAL>();

builder.Services.AddScoped<OperadoresBussines>();
builder.Services.AddScoped<OperadoresDAL>();

builder.Services.AddScoped<RutasBussines>();
builder.Services.AddScoped<RutasDAL>();

builder.Services.AddScoped<ViajesBussines>();
builder.Services.AddScoped<ViajesDAL>();

builder.Services.AddScoped<GastosBussines>();
builder.Services.AddScoped<GastosDAL>();

builder.Services.AddScoped<CombustibleBussines>();
builder.Services.AddScoped<CombustibleDAL>();

builder.Services.AddScoped<MantenimientoBussines>();
builder.Services.AddScoped<MantenimientoDAL>();

builder.Services.AddScoped<RentabilidadBussines>();
builder.Services.AddScoped<RentabilidadDAL>();

builder.Services.AddScoped<SeguridadBussines>();
builder.Services.AddScoped<SeguridadDAL>();

builder.Services.AddScoped<EmpresaBussines>();
builder.Services.AddScoped<EmpresaDAL>();

builder.Services.AddScoped<RolesBussines>();
builder.Services.AddScoped<RolesDAL>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.MapGet("/prueba", () => "Swagger cargado");

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();