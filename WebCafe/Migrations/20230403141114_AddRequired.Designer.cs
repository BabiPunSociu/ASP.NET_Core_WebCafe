﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebCafe.Models;

#nullable disable

namespace WebCafe.Migrations
{
    [DbContext(typeof(CuaHangBanCafeContext))]
    [Migration("20230403141114_AddRequired")]
    partial class AddRequired
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebCafe.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("TaiKhoan")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("AccountId")
                        .HasName("PK__Account__349DA586DBEEEBCF");

                    b.HasIndex("RoleId");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("WebCafe.Models.ChiTietDonHang", b =>
                {
                    b.Property<int>("MaCtdh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaCTDH");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaCtdh"));

                    b.Property<int>("MaDh")
                        .HasColumnType("int")
                        .HasColumnName("MaDH");

                    b.Property<int>("MaSp")
                        .HasColumnType("int")
                        .HasColumnName("MaSP");

                    b.Property<int>("Ngaygiao")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int>("TongTien")
                        .HasColumnType("int");

                    b.HasKey("MaCtdh")
                        .HasName("PK__ChiTietD__1E4E40F03AFB7E71");

                    b.HasIndex("MaDh");

                    b.HasIndex("MaSp");

                    b.ToTable("ChiTietDonHang", (string)null);
                });

            modelBuilder.Entity("WebCafe.Models.DanhMucSp", b =>
                {
                    b.Property<int>("MaDm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaDM");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDm"));

                    b.Property<string>("AnhDm")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AnhDM");

                    b.Property<string>("MoTaDm")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("MoTaDM");

                    b.Property<string>("TenDm")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("TenDM");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaDm")
                        .HasName("PK__DanhMucS__2725866EE256EC61");

                    b.ToTable("DanhMucSP", (string)null);
                });

            modelBuilder.Entity("WebCafe.Models.DonHang", b =>
                {
                    b.Property<int>("MaDh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaDH");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDh"));

                    b.Property<int>("MaKh")
                        .HasColumnType("int")
                        .HasColumnName("MaKH");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("date");

                    b.Property<DateTime>("NgayThanhToan")
                        .HasColumnType("date");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ThanhToan")
                        .HasColumnType("bit");

                    b.Property<int>("TongTien")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThaiHuyDon")
                        .HasColumnType("bit");

                    b.HasKey("MaDh")
                        .HasName("PK__DonHang__27258661039BADEE");

                    b.HasIndex("MaKh");

                    b.ToTable("DonHang", (string)null);
                });

            modelBuilder.Entity("WebCafe.Models.KhachHang", b =>
                {
                    b.Property<int>("MaKh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaKH");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKh"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    b.Property<string>("AvatarKh")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AvatarKH");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<string>("Diachi")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("GioiTinh")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("Ngaysinh")
                        .HasColumnType("date");

                    b.Property<string>("Password")
                        .HasMaxLength(26)
                        .IsUnicode(false)
                        .HasColumnType("varchar(26)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("TenKh")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("TenKH");

                    b.HasKey("MaKh")
                        .HasName("PK__KhachHan__2725CF1E6183654A");

                    b.HasIndex("AccountId");

                    b.ToTable("KhachHang", (string)null);
                });

            modelBuilder.Entity("WebCafe.Models.QuanLyShipper", b =>
                {
                    b.Property<int>("MaShipper")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaShipper"));

                    b.Property<int>("MaDh")
                        .HasColumnType("int")
                        .HasColumnName("MaDH");

                    b.Property<DateTime>("NgayLayHang")
                        .HasColumnType("date");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("TenCongty")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenShipper")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaShipper")
                        .HasName("PK__QuanLySh__5C944AF68EF3404B");

                    b.HasIndex("MaDh");

                    b.ToTable("QuanLyShipper", (string)null);
                });

            modelBuilder.Entity("WebCafe.Models.RoleAccount", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Mota")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RoleName")
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)");

                    b.HasKey("RoleId")
                        .HasName("PK__RoleAcco__8AFACE3AAD449DBE");

                    b.ToTable("RoleAccount", (string)null);
                });

            modelBuilder.Entity("WebCafe.Models.SanPham", b =>
                {
                    b.Property<int>("MaSp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaSP");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSp"));

                    b.Property<string>("AnhSp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AnhSP");

                    b.Property<bool>("BestSeller")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<int>("GiaSp")
                        .HasColumnType("int")
                        .HasColumnName("GiaSP");

                    b.Property<int>("MaDm")
                        .HasColumnType("int")
                        .HasColumnName("MaDM");

                    b.Property<string>("MotaSp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MotaSP");

                    b.Property<DateTime>("NgaySua")
                        .HasColumnType("date");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenSp")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("TenSP");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<string>("VideoSp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("VideoSP");

                    b.HasKey("MaSp")
                        .HasName("PK__SanPham__2725081CBC3461AC");

                    b.HasIndex("MaDm");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("WebCafe.Models.TinTuc", b =>
                {
                    b.Property<int>("MaTt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaTT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTt"));

                    b.Property<string>("AnhTt")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AnhTT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<bool?>("LoaiTin")
                        .HasColumnType("bit");

                    b.Property<string>("Motadai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Motangan")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Tacgia")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenTt")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("TenTT");

                    b.HasKey("MaTt")
                        .HasName("PK__TinTuc__27250079137A8879");

                    b.ToTable("TinTuc", (string)null);
                });

            modelBuilder.Entity("WebCafe.Models.TrangThaiDh", b =>
                {
                    b.Property<int>("MaTtdh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaTTDH");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTtdh"));

                    b.Property<int>("MaDh")
                        .HasColumnType("int")
                        .HasColumnName("MaDH");

                    b.Property<string>("Mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThai")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MaTtdh")
                        .HasName("PK__TrangTha__4484B8558FE01F3D");

                    b.HasIndex("MaDh");

                    b.ToTable("TrangThaiDH", (string)null);
                });

            modelBuilder.Entity("WebCafe.Models.Account", b =>
                {
                    b.HasOne("WebCafe.Models.RoleAccount", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK__Account__RoleID__5AEE82B9");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebCafe.Models.ChiTietDonHang", b =>
                {
                    b.HasOne("WebCafe.Models.DonHang", "MaDhNavigation")
                        .WithMany("ChiTietDonHangs")
                        .HasForeignKey("MaDh")
                        .IsRequired()
                        .HasConstraintName("FK__ChiTietDon__MaDH__5BE2A6F2");

                    b.HasOne("WebCafe.Models.SanPham", "MaSpNavigation")
                        .WithMany("ChiTietDonHangs")
                        .HasForeignKey("MaSp")
                        .IsRequired()
                        .HasConstraintName("FK__ChiTietDon__MaSP__5CD6CB2B");

                    b.Navigation("MaDhNavigation");

                    b.Navigation("MaSpNavigation");
                });

            modelBuilder.Entity("WebCafe.Models.DonHang", b =>
                {
                    b.HasOne("WebCafe.Models.KhachHang", "MaKhNavigation")
                        .WithMany("DonHangs")
                        .HasForeignKey("MaKh")
                        .IsRequired()
                        .HasConstraintName("FK__DonHang__MaKH__5DCAEF64");

                    b.Navigation("MaKhNavigation");
                });

            modelBuilder.Entity("WebCafe.Models.KhachHang", b =>
                {
                    b.HasOne("WebCafe.Models.Account", "Account")
                        .WithMany("KhachHangs")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_Account_KhachHang");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("WebCafe.Models.QuanLyShipper", b =>
                {
                    b.HasOne("WebCafe.Models.DonHang", "MaDhNavigation")
                        .WithMany("QuanLyShippers")
                        .HasForeignKey("MaDh")
                        .IsRequired()
                        .HasConstraintName("FK__QuanLyShip__MaDH__5FB337D6");

                    b.Navigation("MaDhNavigation");
                });

            modelBuilder.Entity("WebCafe.Models.SanPham", b =>
                {
                    b.HasOne("WebCafe.Models.DanhMucSp", "MaDmNavigation")
                        .WithMany("SanPhams")
                        .HasForeignKey("MaDm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__SanPham__MaDM__60A75C0F");

                    b.Navigation("MaDmNavigation");
                });

            modelBuilder.Entity("WebCafe.Models.TrangThaiDh", b =>
                {
                    b.HasOne("WebCafe.Models.DonHang", "MaDhNavigation")
                        .WithMany("TrangThaiDhs")
                        .HasForeignKey("MaDh")
                        .IsRequired()
                        .HasConstraintName("FK__TrangThaiD__MaDH__619B8048");

                    b.Navigation("MaDhNavigation");
                });

            modelBuilder.Entity("WebCafe.Models.Account", b =>
                {
                    b.Navigation("KhachHangs");
                });

            modelBuilder.Entity("WebCafe.Models.DanhMucSp", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("WebCafe.Models.DonHang", b =>
                {
                    b.Navigation("ChiTietDonHangs");

                    b.Navigation("QuanLyShippers");

                    b.Navigation("TrangThaiDhs");
                });

            modelBuilder.Entity("WebCafe.Models.KhachHang", b =>
                {
                    b.Navigation("DonHangs");
                });

            modelBuilder.Entity("WebCafe.Models.RoleAccount", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("WebCafe.Models.SanPham", b =>
                {
                    b.Navigation("ChiTietDonHangs");
                });
#pragma warning restore 612, 618
        }
    }
}
