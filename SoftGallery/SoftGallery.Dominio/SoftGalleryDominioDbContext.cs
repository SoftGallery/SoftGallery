using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using SoftGallery.Dominio.Models;

namespace SoftGallery.Dominio;

public partial class SoftGalleryDominioDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Campanha> Campanhas { get; set; }
    public DbSet<Loja> Loja { get; set; }
    public SoftGalleryDominioDbContext()
    {
    }

    public SoftGalleryDominioDbContext(DbContextOptions<SoftGalleryDominioDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user id=root;password=mysql;database=db_softgallery", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
