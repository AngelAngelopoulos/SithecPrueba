using Sithec;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();
//app.UseSwaggerUI(c =>
//{
//    //c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sithec API");
//    //c.InjectStylesheet("/swagger/custom.css");
//    //c.RoutePrefix = "";
//});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.UsePathBase(new PathString("/api/"));

app.UseRouting();

app.MapControllers();

app.Run();
