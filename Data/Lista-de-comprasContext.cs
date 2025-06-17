using System;
using lista_de_comprasAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace lista_de_comprasAPI.Data;

public class Lista_de_comprasContext(DbContextOptions<Lista_de_comprasContext> options) : DbContext(options)
{
    public DbSet<Item> Items => Set<Item>();

    public DbSet<Category> Categories => Set<Category>();
}
