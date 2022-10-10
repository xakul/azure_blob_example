using Azure.Storage.Blobs;
using AzureBlobExample.Interfaces;
using AzureBlobExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(a =>
    new BlobServiceClient(
        "DefaultEndpointsProtocol=https;AccountName=atistorage33;AccountKey=1emQ7tw3D05rhUg+qzMHgveirxrqXoKBH/3fLN/LcM9K3tlMeRgzrvgvVFIlOSoK+YDJ3vWKifhk+ASth7sxjA==;EndpointSuffix=core.windows.net"));

builder.Services.AddScoped<IBlobService, BlobService>();

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