using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Service.Models
{
    public partial class QLShopContext : DbContext
    {
        public QLShopContext()
        {
        }

        public QLShopContext(DbContextOptions<QLShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }
        public virtual DbSet<Chucnang> Chucnangs { get; set; }
        public virtual DbSet<Donhang> Donhangs { get; set; }
        public virtual DbSet<Hinh> Hinhs { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Khuyenmai> Khuyenmais { get; set; }
        public virtual DbSet<Loaihang> Loaihangs { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<Thuonghieu> Thuonghieus { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=SqlServerConnect");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Chitietdonhang>(entity =>
            {
                entity.ToTable("Chitietdonhang");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Diachi).HasMaxLength(500);

                entity.Property(e => e.DonHangId).HasColumnName("DonHangID");

                entity.Property(e => e.PhiShip).HasDefaultValueSql("((0))");

                entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.DonHang)
                    .WithMany(p => p.Chitietdonhangs)
                    .HasForeignKey(d => d.DonHangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chitietdonhang_donhang");

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.Chitietdonhangs)
                    .HasForeignKey(d => d.SanPhamId)
                    .HasConstraintName("FK_Chitietdonhang_thuonghieu");
            });

            modelBuilder.Entity<Chucnang>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Chucnang");

                entity.Property(e => e.BaoHanhId).HasColumnName("BaoHanhID");

                entity.Property(e => e.LoaiHangId).HasColumnName("LoaiHangID");

                entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");

                entity.HasOne(d => d.LoaiHang)
                    .WithMany()
                    .HasForeignKey(d => d.LoaiHangId)
                    .HasConstraintName("FK_Chucnang_Loaihang");

                entity.HasOne(d => d.SanPham)
                    .WithMany()
                    .HasForeignKey(d => d.SanPhamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chucnang_Sanpham");
            });

            modelBuilder.Entity<Donhang>(entity =>
            {
                entity.ToTable("Donhang");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DiaChi).HasMaxLength(500);

                entity.Property(e => e.DsSanPhamId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.MaGiamGia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgayCapNhat).HasColumnType("date");

                entity.Property(e => e.NgayTao).HasColumnType("date");

                entity.Property(e => e.PhiShip).HasDefaultValueSql("((0))");

                entity.Property(e => e.SoDienThoai)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.KhachHang)
                    .WithMany(p => p.Donhangs)
                    .HasForeignKey(d => d.KhachHangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donhang_users");
            });

            modelBuilder.Entity<Hinh>(entity =>
            {
                entity.ToTable("Hinh");

                entity.Property(e => e.HinhId)
                    .ValueGeneratedNever()
                    .HasColumnName("HinhID");

                entity.Property(e => e.Carousel).IsUnicode(false);

                entity.Property(e => e.NgayHetHan).HasColumnType("datetime");

                entity.Property(e => e.Thumbnails)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.HasOne(d => d.HinhNavigation)
                    .WithOne(p => p.Hinh)
                    .HasForeignKey<Hinh>(d => d.HinhId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hinh_SP");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Khachhang");

                entity.Property(e => e.DiaChi).HasMaxLength(150);

                entity.Property(e => e.DsIddonhang)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HoTenKh)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("HoTenKH");

                entity.Property(e => e.Ngaysinh).HasColumnType("date");

                entity.Property(e => e.Ngaytao).HasColumnType("date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ThanhPho).HasMaxLength(50);

                entity.Property(e => e.ThongTin).HasMaxLength(200);
            });

            modelBuilder.Entity<Khuyenmai>(entity =>
            {
                entity.ToTable("khuyenmai");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.LoaiHangId).HasColumnName("LoaiHangID");

                entity.Property(e => e.NgayBatDau).HasColumnType("date");

                entity.Property(e => e.NgayKetThuc).HasColumnType("date");

                entity.Property(e => e.QuaTangKem).HasMaxLength(50);

                entity.Property(e => e.VoucherTangKem).HasMaxLength(50);
            });

            modelBuilder.Entity<Loaihang>(entity =>
            {
                entity.ToTable("Loaihang");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.NoiDung).IsRequired();

                entity.Property(e => e.TenLoaiHang)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.ToTable("Sanpham");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.HinhSanPham).IsUnicode(false);

                entity.Property(e => e.KhuyenMaiId).HasColumnName("KhuyenMaiID");

                entity.Property(e => e.LoaiHangId).HasColumnName("LoaiHangID");

                entity.Property(e => e.MaSanPham)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgayCapNhat).HasColumnType("date");

                entity.Property(e => e.NgayTao)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TenSanPham)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.KhuyenMai)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.KhuyenMaiId)
                    .HasConstraintName("FK_Sanpham_khuyenmai");

                entity.HasOne(d => d.ThuongHieu)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.ThuongHieuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sanpham_thuonghieu");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Sanpham_User");
            });

            modelBuilder.Entity<Thuonghieu>(entity =>
            {
                entity.ToTable("Thuonghieu");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Nuoc)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TenThuongHieu)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Diachi).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("date");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QuyenHan)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TenLot).HasMaxLength(10);

                entity.Property(e => e.ThanhPho).HasMaxLength(50);

                entity.Property(e => e.ThongTin).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
