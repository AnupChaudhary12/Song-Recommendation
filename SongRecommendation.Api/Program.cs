using SongRecommendation.Persistence;
using SongRecommendation.Application;
using SongRecommendation.Api.ApiCode.Implementations;
using SongRecommendation.Api.Extensions.MapApis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddCors(options =>
{
	options.AddPolicy("all", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("all");

var SongApiCode = new SongApiCode();
app.MapSongApis(SongApiCode);

var UserApiCode = new UserApiCode();
app.MapUserApis(UserApiCode);

app.Run();

