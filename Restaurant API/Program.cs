var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("Access-Control-Allow-Origin", builder =>
    {
        builder.AllowAnyOrigin()  //allows requests from any origin
          //    .WithOrigins("http://www.temple.edu")  //allows requests from only this domain (safer)
               .AllowAnyMethod()      //allows any HTTP method in the request
               .AllowAnyHeader()      //allows any headers in the request
               .AllowCredentials();

    });  //end AllowPolicy()
});   //end AddCors()

var app = builder.Build();

app.UseCors("Access-Control-Allow-Origin");

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
