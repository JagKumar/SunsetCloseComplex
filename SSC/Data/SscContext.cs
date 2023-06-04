using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SSC.Models;

namespace SSC.Data;

public partial class SscContext : DbContext
{
    public SscContext()
    {
    }

    public SscContext(DbContextOptions<SscContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UnitOwner> UnitOwners { get; set; }
    public  DbSet<SSC.Models.UnitTenant> UnitTenants { get; set; }
    public DbSet<SSC.Models.UserLogin> UserLogin { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UnitOwner>(entity =>
        {
            entity.Property(e => e.UnitNo).ValueGeneratedNever();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    
}
