using Backend.Model;
using Core.Repository;
using Core.Repository.Implementation;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Web.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetSection("ConnectionStrings:SqlServerDev").Value;

builder.Services.AddHealthChecks().AddSqlServer(connectionString); // Implementar healcheck com UI depois, pesquisar sobre
builder.Services.AddHealthChecksUI(options =>
{
    options.SetEvaluationTimeInSeconds(5);
    options.MaximumHistoryEntriesPerEndpoint(10);
    options.AddHealthCheckEndpoint("API com Health Checks", "/health");
}).AddSqlServerStorage("name=ConnectionStrings:SqlServerHealthCheck");

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer("name=ConnectionStrings:SqlServerDev"));
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IBookAutorRepository, BookAuthorRepository>();
builder.Services.AddScoped<IBookSubjectRepository, BookSubjectRepository>();
builder.Services.AddScoped<IBookValueRepository, BookValueRepository>();
builder.Services.AddScoped<IOriginPurchaseRepository, OriginPurchaseRepository>();

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);

builder.Services.AddCors();

//builder.Services.AddProblemDetails();

var app = builder.Build();

//app.UseExceptionHandler();
//app.UseStatusCodePages();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //app.UseExceptionHandler("/error-development");
    //app.UseDeveloperExceptionPage();
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
}
//else
//{
//    app.UseExceptionHandler("/error");
//}

app.UseHealthChecks("/health", new HealthCheckOptions
{
    Predicate = p => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHealthChecksUI(options => options.UIPath = "/dashboard");

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseHsts();

app.UseAuthorization();

//app.UseCors(cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.Run();

// TODO Implementar Hangfire
// TODO Implementar Identity
