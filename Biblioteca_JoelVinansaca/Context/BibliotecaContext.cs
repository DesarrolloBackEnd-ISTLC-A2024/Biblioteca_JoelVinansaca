using System;
using System.Collections.Generic;
using Biblioteca_JoelVinansaca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_JoelVinansaca.Context;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Editorial> Editorials { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Multa> Multas { get; set; }

    public virtual DbSet<Novedade> Novedades { get; set; }

    public virtual DbSet<PrestamosCabecera> PrestamosCabeceras { get; set; }

    public virtual DbSet<PrestamosDetalle> PrestamosDetalles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=JKV\\SQLEXPRESS;Initial Catalog=Biblioteca;User Id=sa;Password=0417;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PK__AUTOR__DA37C13780CC7CAA");

            entity.ToTable("AUTOR");

            entity.Property(e => e.IdAutor)
                .ValueGeneratedNever()
                .HasColumnName("ID_AUTOR");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.NombreAutor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_AUTOR");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__CATEGORI__4BD51FA50EDFF47B");

            entity.ToTable("CATEGORIAS");

            entity.Property(e => e.IdCategoria)
                .ValueGeneratedNever()
                .HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.DescripcionCategoria)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION_CATEGORIA");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.IdEditorial).HasName("PK__EDITORIA__EA05B1D708023B25");

            entity.ToTable("EDITORIAL");

            entity.Property(e => e.IdEditorial)
                .ValueGeneratedNever()
                .HasColumnName("ID_EDITORIAL");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.NombreEditorial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_EDITORIAL");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdLibros).HasName("PK__INVENTAR__0ECE31B2B84B9CB4");

            entity.ToTable("INVENTARIO");

            entity.Property(e => e.IdLibros)
                .ValueGeneratedNever()
                .HasColumnName("ID_LIBROS");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.StockMaximo).HasColumnName("STOCK_MAXIMO");
            entity.Property(e => e.StockMinimo).HasColumnName("STOCK_MINIMO");
            entity.Property(e => e.TotalStock).HasColumnName("TOTAL_STOCK");

            entity.HasOne(d => d.IdLibrosNavigation).WithOne(p => p.Inventario)
                .HasForeignKey<Inventario>(d => d.IdLibros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INVENTARI__ID_LI__4D94879B");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibros).HasName("PK__LIBROS__0ECE31B2F6EE3AB2");

            entity.ToTable("LIBROS");

            entity.Property(e => e.IdLibros)
                .ValueGeneratedNever()
                .HasColumnName("ID_LIBROS");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdAutor).HasColumnName("ID_AUTOR");
            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.IdEditorial).HasColumnName("ID_EDITORIAL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdAutor)
                .HasConstraintName("FK__LIBROS__ID_AUTOR__3E52440B");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__LIBROS__ID_CATEG__3D5E1FD2");

            entity.HasOne(d => d.IdEditorialNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdEditorial)
                .HasConstraintName("FK__LIBROS__ID_EDITO__3F466844");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento).HasName("PK__MOVIMIEN__44BC2ADAA2D95015");

            entity.ToTable("MOVIMIENTOS");

            entity.Property(e => e.IdMovimiento)
                .ValueGeneratedNever()
                .HasColumnName("ID_MOVIMIENTO");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdLibros).HasColumnName("ID_LIBROS");
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("TIPO_MOVIMIENTO");

            entity.HasOne(d => d.IdLibrosNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdLibros)
                .HasConstraintName("FK__MOVIMIENT__ID_LI__5070F446");
        });

        modelBuilder.Entity<Multa>(entity =>
        {
            entity.HasKey(e => e.IdMulta).HasName("PK__MULTAS__1C1448B28B82B228");

            entity.ToTable("MULTAS");

            entity.Property(e => e.IdMulta)
                .ValueGeneratedNever()
                .HasColumnName("ID_MULTA");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdPrestamo).HasColumnName("ID_PRESTAMO");
            entity.Property(e => e.Motivo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MOTIVO");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.IdPrestamoNavigation).WithMany(p => p.Multa)
                .HasForeignKey(d => d.IdPrestamo)
                .HasConstraintName("FK__MULTAS__ID_PREST__4AB81AF0");
        });

        modelBuilder.Entity<Novedade>(entity =>
        {
            entity.HasKey(e => e.IdNovedad).HasName("PK__NOVEDADE__FE457EA183902B61");

            entity.ToTable("NOVEDADES");

            entity.Property(e => e.IdNovedad)
                .ValueGeneratedNever()
                .HasColumnName("ID_NOVEDAD");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdLibros).HasColumnName("ID_LIBROS");
            entity.Property(e => e.Motivo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MOTIVO");

            entity.HasOne(d => d.IdLibrosNavigation).WithMany(p => p.Novedades)
                .HasForeignKey(d => d.IdLibros)
                .HasConstraintName("FK__NOVEDADES__ID_LI__534D60F1");
        });

        modelBuilder.Entity<PrestamosCabecera>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__PRESTAMO__3D5A1E6C84DD8AC4");

            entity.ToTable("PRESTAMOS_CABECERA");

            entity.Property(e => e.IdPrestamo)
                .ValueGeneratedNever()
                .HasColumnName("ID_PRESTAMO");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaEstimadaDevolucion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ESTIMADA_DEVOLUCION");
            entity.Property(e => e.FechaPrestamo)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_PRESTAMO");
            entity.Property(e => e.FechaRealDevolucion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REAL_DEVOLUCION");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Observacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OBSERVACION");
            entity.Property(e => e.TotalLibrosPrestados).HasColumnName("TOTAL_LIBROS_PRESTADOS");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.PrestamosCabeceras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__PRESTAMOS__ID_US__440B1D61");
        });

        modelBuilder.Entity<PrestamosDetalle>(entity =>
        {
            entity.HasKey(e => new { e.IdPrestamo, e.IdDetalle }).HasName("PK__PRESTAMO__561558C99D370171");

            entity.ToTable("PRESTAMOS_DETALLE");

            entity.Property(e => e.IdPrestamo).HasColumnName("ID_PRESTAMO");
            entity.Property(e => e.IdDetalle).HasColumnName("ID_DETALLE");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdLibros).HasColumnName("ID_LIBROS");

            entity.HasOne(d => d.IdLibrosNavigation).WithMany(p => p.PrestamosDetalles)
                .HasForeignKey(d => d.IdLibros)
                .HasConstraintName("FK__PRESTAMOS__ID_LI__47DBAE45");

            entity.HasOne(d => d.IdPrestamoNavigation).WithMany(p => p.PrestamosDetalles)
                .HasForeignKey(d => d.IdPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRESTAMOS__ID_PR__46E78A0C");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIOS__91136B904AC76288");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("ID_USUARIO");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
