using ApiExpress;

var builder = WebApplication.CreateBuilder();

builder.Services.AddApiExpress();
builder.Services.AddAuthenticationJWTBearer(builder.Configuration["TokenKey"]);
builder.Services.AddAuthorization(o => o.AddPolicy("AdminOnly", b => b.RequireRole("Admin")));

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseApiExpress();
app.Run();

//todo: write tests
//todo: add xml documentation
//todo: benchmark against minimal api, mvc controller
