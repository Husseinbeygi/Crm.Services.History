using Cyrus.Mongodb;
using Cyrus.Mongodb.Contracts;
using Cyrus.Mongodb.Repository;
using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using MongoDB.Driver;
using Persistence;
using System.Collections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//	.AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

var services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddMongoDb(
x => {
	x.WithConnectionString("mongodb://localhost:27017");
	x.WithDatabase("History");
	return x;
})
.AddMongoRepository<Post>("posts");


services.AddTransient<IMongoRepository<Post>>(opt =>
{
	var database = opt.GetRequiredService<IMongoDatabase>();
	return new PostRepository(database, "posts");
});

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
