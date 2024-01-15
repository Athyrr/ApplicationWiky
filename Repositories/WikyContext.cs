using Azure.Messaging;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class WikyContext : DbContext
    {
        public WikyContext(DbContextOptions<WikyContext> dbContextOptions) : base(dbContextOptions) { }


        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConnectionString in Program

            //optionsBuilder.LogTo(Console.WriteLine);


            base.OnConfiguring(optionsBuilder);
        }

        // Données par défaut
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    List<Article> articles = new()
        //    {
        //        new Article(){Id = 1,Author = "Author 1", Theme = "Theme",Content = "Content 1", CreatedAt = DateTime.Now, EditedAt = DateTime.Now, Comments={ } }
        //    };


        //    modelBuilder.Entity<Article>().HasData(articles);

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
