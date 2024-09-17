using ProgramMaisClean.Config;

var builder = WebApplication.CreateBuilder(args);
var _config = builder.Configuration;

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//conexão mysql
builder.Services.AddDbConfiguration(_config);

//swagger
builder.Services.AddSwaggerConfiguration();

//versionamento
builder.Services.ApiVersioning();

//injeções
builder.Services.ResolveDependencias();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
