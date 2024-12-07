using probiotics.Data;
using probiotics.Interfaces;
using probiotics.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IAlgorithmRepository, AlgorithmRepository>();
builder.Services.AddScoped<IAlgoLabelRepository, AlgoLabelRepository>();
builder.Services.AddScoped<ISwallowRepository, SwallowRepository>();
builder.Services.AddScoped<ISwallowLinksRepository, SwallowLinksRepository>();
builder.Services.AddScoped<ISpendRepository, SpendRepository>();
builder.Services.AddScoped<ISpendChartRepository, SpendChartRepository>();
builder.Services.AddScoped<ISpendTagRepository, SpendTagRepository>();

builder.Services.AddScoped<IS3ServiceRepository, S3ServiceRepository>();




// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowReactApp",
//         builder =>
//         {
//             builder.WithOrigins("http://localhost:8080") // 这里的端口是 React 开发服务器的端口
//                 .AllowAnyHeader()
//                 .AllowAnyMethod().AllowCredentials();
//         });
// });
builder.Services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x=> x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin=>true));

app.MapControllers();

// app.UseCors("AllowReactApp");
app.Run();

