using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebsiteBanQuanAo16.DAL.Models
{
    public partial class QLQuanAoContext : DbContext
    {
        public QLQuanAoContext()
        {
        }

        public QLQuanAoContext(DbContextOptions<QLQuanAoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DanhGia> DanhGia { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSp> LoaiSps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MSI\\ANNABELL;Initial Catalog=QLQuanAo;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => new { e.MaDh, e.MaSp });

                entity.ToTable("ChiTietDonHang");

                entity.Property(e => e.MaDh)
                    .HasMaxLength(10)
                    .HasColumnName("MaDH")
                    .IsFixedLength(true);

                entity.Property(e => e.MaSp)
                    .HasMaxLength(10)
                    .HasColumnName("MaSP")
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaDhNavigation)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaDh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_DonHang");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_SanPham");
            });

            modelBuilder.Entity<DanhGia>(entity =>
            {
                entity.HasKey(e => e.MaDg)
                    .HasName("PK_Blog");

                entity.Property(e => e.MaDg)
                    .HasMaxLength(10)
                    .HasColumnName("MaDG")
                    .IsFixedLength(true);

                entity.Property(e => e.MaDh)
                    .HasMaxLength(10)
                    .HasColumnName("MaDH")
                    .IsFixedLength(true);

                entity.Property(e => e.MaSp)
                    .HasMaxLength(10)
                    .HasColumnName("MaSP")
                    .IsFixedLength(true);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaDhNavigation)
                    .WithMany(p => p.DanhGia)
                    .HasForeignKey(d => d.MaDh)
                    .HasConstraintName("FK_DanhGia_DonHang");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.DanhGia)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_DanhGia_SanPham");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DanhGia)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_DanhGia_User");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDh);

                entity.ToTable("DonHang");

                entity.Property(e => e.MaDh)
                    .HasMaxLength(10)
                    .HasColumnName("MaDH")
                    .IsFixedLength(true);

                entity.Property(e => e.MaKh)
                    .HasMaxLength(10)
                    .HasColumnName("MaKH")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayDatHang).HasColumnType("datetime");

                entity.Property(e => e.TongGia).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_DonHang_KhachHang");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(10)
                    .HasColumnName("MaKH")
                    .IsFixedLength(true);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(20)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);

                entity.Property(e => e.TenKh)
                    .HasMaxLength(20)
                    .HasColumnName("TenKH")
                    .IsFixedLength(true);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KhachHangs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_KhachHang_User");
            });

            modelBuilder.Entity<LoaiSp>(entity =>
            {
                entity.HasKey(e => e.MaLoai)
                    .HasName("PK_PhanLoaiHang");

                entity.ToTable("LoaiSP");

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TenLoai).HasMaxLength(50);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .HasColumnName("MaNV")
                    .IsFixedLength(true);

                entity.Property(e => e.ChucVu).HasMaxLength(50);

                entity.Property(e => e.Idcard)
                    .HasMaxLength(50)
                    .HasColumnName("IDCard");

                entity.Property(e => e.NamSinh).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(20)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);

                entity.Property(e => e.TenNv)
                    .HasMaxLength(50)
                    .HasColumnName("TenNV");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_NhanVien_User");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(10)
                    .HasColumnName("MaSP")
                    .IsFixedLength(true);

                entity.Property(e => e.KichThuoc)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TenSp)
                    .HasMaxLength(50)
                    .HasColumnName("TenSP");

                entity.Property(e => e.ThongTinSp)
                    .HasColumnType("ntext")
                    .HasColumnName("ThongTinSP");

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK_SanPham_LoaiSP");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID")
                    .IsFixedLength(true);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.MatKhau).HasMaxLength(20);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(20)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
