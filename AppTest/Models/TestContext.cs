using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppTest.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1FD9KVA;Initial Catalog=Test;Persist Security Info=False;User ID=User;Password=a123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lop>(entity =>
        {
            entity.ToTable("Lop");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.SoBd).HasColumnName("SoBD");
            entity.Property(e => e.TenChucVu).HasMaxLength(200);
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.ToTable("SinhVien");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.HoVaTen).HasMaxLength(200);

            entity.HasOne(d => d.IdChucVuNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.IdChucVu)
                .HasConstraintName("FK_SinhVien_Lop");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
