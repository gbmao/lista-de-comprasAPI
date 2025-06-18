using System;
using lista_de_comprasAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace lista_de_comprasAPI.Data;

public class Lista_de_comprasContext(DbContextOptions<Lista_de_comprasContext> options) : DbContext(options)
{
    public DbSet<Item> Items => Set<Item>();

    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new { Id = 1, Name = "Cotidiano" },
            new { Id = 2, Name = "Sacolão" },
            new { Id = 3, Name = "Lanche" },
            new { Id = 4, Name = "Higiene pessoal" },
            new { Id = 5, Name = "Limpeza" },
            new { Id = 6, Name = "Proteina" }
            
        );
    }
}
