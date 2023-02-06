using Application.Consumers;
using Cyrus.Mongodb;
using Domain;
using MassTransit;

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



//services.AddTransient<IMongoRepository<Post>>(opt =>
//{
//	var database = opt.GetRequiredService<IMongoDatabase>();
//	return new PostRepository(database, "posts");
//});

services.AddMassTransit(x =>
{
	x.SetKebabCaseEndpointNameFormatter();	
	x.AddConsumer<HistoryMessageConsumer>();
	x.UsingRabbitMq((context, cfg) =>
	{

		cfg.Host("localhost", "/", h =>
		{
			h.Username("guest");
			h.Password("guest");
		});

		cfg.Durable = false;

		//cfg.ReceiveEndpoint("HistoryMicroservice",c =>
		//{
		//	c.ConfigureConsumer<HistoryMessageConsumer>(context);
		//});
		
		cfg.ConfigureEndpoints(context);
	});
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
