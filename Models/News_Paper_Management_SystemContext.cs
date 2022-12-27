using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NPMS.Models
{
    public partial class News_Paper_Management_SystemContext : DbContext
    {
        public News_Paper_Management_SystemContext()
        {
        }

        public News_Paper_Management_SystemContext(DbContextOptions<News_Paper_Management_SystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddLists> AddLists { get; set; }
        public virtual DbSet<Adds> Adds { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Userdet> Userdet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0F353PS\\SQLEXPRESS;Initial Catalog=News_Paper_Management_System;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddLists>(entity =>
            {
                entity.HasKey(e => e.AddListId)
                    .HasName("PK__Add_List__2D8835BDF7F52390");

                entity.ToTable("Add_Lists");

                entity.Property(e => e.AddListId).HasColumnName("Add_List_Id");

                entity.Property(e => e.AddTitle)
                    .HasColumnName("Add_Title")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.AddTitleNavigation)
                    .WithMany(p => p.AddLists)
                    .HasPrincipalKey(p => p.AddTitle)
                    .HasForeignKey(d => d.AddTitle)
                    .HasConstraintName("FK__Add_Lists__Add_T__13F1F5EB");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.AddLists)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Add_Lists__Categ__14E61A24");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AddLists)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Add_Lists__User___12FDD1B2");
            });

            modelBuilder.Entity<Adds>(entity =>
            {
                entity.HasKey(e => e.AddId)
                    .HasName("PK__Adds__819EBA9BC5238BE1");

                entity.HasIndex(e => e.AddTitle)
                    .HasName("UQ__Adds__5E8ECE1E607A4A1B")
                    .IsUnique();

                entity.Property(e => e.AddId).HasColumnName("Add_Id");

                entity.Property(e => e.AddContent)
                    .HasColumnName("Add_Content")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AddDate)
                    .HasColumnName("Add_Date")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddDesc)
                    .HasColumnName("Add_Desc")
                    .IsUnicode(false);

                entity.Property(e => e.AddTitle)
                    .IsRequired()
                    .HasColumnName("Add_Title")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryTitle)
                    .HasColumnName("Category_Title")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryTitleNavigation)
                    .WithMany(p => p.Adds)
                    .HasPrincipalKey(p => p.CategoryTitle)
                    .HasForeignKey(d => d.CategoryTitle)
                    .HasConstraintName("FK__Adds__Category_T__10216507");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId).HasColumnName("Admin_Id");

                entity.Property(e => e.AdminEmail)
                    .HasColumnName("Admin_Email")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.AdminPassword)
                    .HasColumnName("Admin_Password")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BkId)
                    .HasName("PK__Booking__A91036A03092A700");

                entity.Property(e => e.BkId).HasColumnName("Bk_Id");

                entity.Property(e => e.AddImg)
                    .HasColumnName("Add_Img")
                    .IsUnicode(false);

                entity.Property(e => e.AddPrice)
                    .HasColumnName("Add_Price")
                    .HasColumnType("money");

                entity.Property(e => e.AddTitle)
                    .HasColumnName("Add_Title")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryTitle)
                    .HasColumnName("Category_Title")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CityName)
                    .HasColumnName("City_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PublicationName)
                    .HasColumnName("Publication_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RowColumn)
                    .HasColumnName("Row_Column")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.AddTitleNavigation)
                    .WithMany(p => p.Booking)
                    .HasPrincipalKey(p => p.AddTitle)
                    .HasForeignKey(d => d.AddTitle)
                    .HasConstraintName("FK__Booking__Add_Tit__2057CCD0");

                entity.HasOne(d => d.CategoryTitleNavigation)
                    .WithMany(p => p.Booking)
                    .HasPrincipalKey(p => p.CategoryTitle)
                    .HasForeignKey(d => d.CategoryTitle)
                    .HasConstraintName("FK__Booking__Categor__1F63A897");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Booking__User_Id__214BF109");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoryTitle)
                    .HasName("UQ__Category__42DD5240048C612F")
                    .IsUnique();

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CategoryTitle)
                    .IsRequired()
                    .HasColumnName("Category_Title")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");

                entity.Property(e => e.BkId).HasColumnName("Bk_Id");

                entity.Property(e => e.CardHolderName)
                    .HasColumnName("Card_Holder_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CardNumber)
                    .HasColumnName("Card_Number")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CardType)
                    .HasColumnName("Card_Type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cvv)
                    .HasColumnName("CVV")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("Expiry_Date")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bk)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.BkId)
                    .HasConstraintName("FK__Payment__Bk_Id__24285DB4");
            });

            modelBuilder.Entity<Userdet>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Userdet__206D917055E8363C");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.ContactNum)
                    .HasColumnName("Contact_Num")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .HasColumnName("User_Email")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("User_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasColumnName("User_Password")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
