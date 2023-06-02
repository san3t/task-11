using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Models;

namespace DataAccess
{
    public partial class eshop_dbContext : DbContext
    {
        public eshop_dbContext()
        {
        }

        public eshop_dbContext(DbContextOptions<eshop_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CustomUser> CustomUsers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.BookingAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("booking_address");

                entity.Property(e => e.BookingDelivery)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("booking_delivery");

                entity.Property(e => e.BookingPrice).HasColumnName("booking_price");

                entity.Property(e => e.BookingStatus)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("booking_status");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__cart_id__49C3F6B7");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__customer_i__4316F928");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CartId })
                    .HasName("PK__CartItem__25ED2F57F8A42DA3");

                entity.ToTable("CartItem");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__cart_i__46E78A0C");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__produc__45F365D3");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<CustomUser>(entity =>
            {
                entity.ToTable("CustomUser");

                entity.HasIndex(e => e.UserEmail, "UQ__CustomUs__B0FBA212BAD71982")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(127)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("user_role");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(127)
                    .IsUnicode(false)
                    .HasColumnName("product_description");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductPrice).HasColumnName("product_price");

                entity.Property(e => e.ProductStock).HasColumnName("product_stock");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__categor__3C69FB99");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CustomerId })
                    .HasName("PK__Review__0BD4214D1213C3E1");

                entity.ToTable("Review");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ReviewRating).HasColumnName("review_rating");

                entity.Property(e => e.ReviewText)
                    .HasMaxLength(527)
                    .IsUnicode(false)
                    .HasColumnName("review_text");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__customer__403A8C7D");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__product___3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
