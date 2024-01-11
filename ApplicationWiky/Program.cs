using Azure.Messaging;
using Business;
using Business.Contracts;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WikyContext>(ob
    => ob.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=WikyApp;Integrated Security=True"));

builder.Services.AddTransient<IArticleBusiness, ArticleBusiness>();
builder.Services.AddTransient<IArticleRepository, ArticleRepository>();
builder.Services.AddTransient<ICommentBusiness, CommentBusiness>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
