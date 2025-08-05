using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using SecureAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddAuthentication("DummyAuthentication")
                .AddScheme<AuthenticationSchemeOptions, AuthenticationHandler>("DummyAuthentication", null);

builder.Services.AddAuthorization(options => {
    options.AddPolicy("Cake", policy => policy.RequireClaim("Role", "Cake"));
    options.AddPolicy("Admin", policy => policy.RequireClaim("Role", "Admin"));
});
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapPost("api/createuser/", (NewUser newUser) => 
    AuthenticationHandler.CreateUser(newUser));

app.MapGet("/api/cake", [Authorize(Policy = "Cake")]
() => {
    return "Hello Cake Lover!";
});

app.MapGet("/api/admin", [Authorize(Policy = "Admin")]
() => {
    return "Hello Admin!";
});

app.MapGet("/api/hello", [AllowAnonymous]
() => "Hello World!");

app.MapGet("/", [AllowAnonymous]
() => "Welcome to the front page");

app.UseHttpsRedirection();

AuthenticationHandler.CreateUser(new NewUser("admin", "admin", new string[] { "Admin" }));
AuthenticationHandler.CreateUser(new NewUser("frank", "f1", new string[] { "Cake" }));


app.Run();

public record NewUser(string user, string password, string[] roles);
