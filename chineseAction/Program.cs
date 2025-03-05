
using chineseAction.Dal;
using chineseAction.Models;
using chineseAction.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Cors.Infrastructure;
using chineseAction.Services.Logger;
using chineseAction.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"))
);

builder.Services.AddScoped<IPresentDal, PresentDal>();
builder.Services.AddScoped<IPresentService, PresentService>();
builder.Services.AddScoped<IDonaterDal, DonaterDal>();
builder.Services.AddScoped<IDonaterService, DonaterService>();
builder.Services.AddScoped<JwtTokenService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerDal, CustomerDal>();
builder.Services.AddScoped<ICustomerPresentService, CustomerPresentService>();
builder.Services.AddScoped<ICustomerPresentDal, CustomerPresentDal>();
builder.Services.AddScoped<IWinnerService, WinnerService>();
builder.Services.AddScoped<IWinnerDal, WinnerDal>();

//builder.Services.AddScoped(typeof(GenericRepository<>));

builder.Services.AddScoped<ILoggerService, FileLoggerService>(provider =>
    new FileLoggerService("logs.txt")
);


//builder.Services.AddScoped<TasksApi.Services.Logger.LoggerFactory>();

builder.Services.AddControllers();

// Add Swagger services to the container.
builder.Services.AddEndpointsApiExplorer(); // For exposing endpoints
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "project API",
        Description = "A simple example ASP.NET Core API to manage books",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com",
            Url = new Uri("https://yourwebsite.com"),
        }
    });

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter 'Bearer {your_token}'"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:4200",
                                                   "development web site")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure request pipeline
if (app.Environment.IsDevelopment())
{

    app.UseDeveloperExceptionPage(); // Detailed error page in Development
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Error handling for Production
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Enable middleware to serve generated Swagger as a JSON    endpoint.
    app.UseSwagger();

    // Enable middleware to serve Swagger UI (HTML, JS, CSS, etc.)
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "project API V1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    });
}
app.UseMiddleware<Middleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication(); // Enables authentication
app.UseAuthorization();  // Enables authorization
app.MapControllers(); // Maps attribute-routed controllers

// Start the app
app.Run();
