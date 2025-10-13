using CapitecDashboard.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapitecDashboard.Infrastructure.DbContexts
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options)
            : base(options) { }

        //public DbSet<AccessLevel> AccessLevels { get; set; }
        //public DbSet<ApplicationProperty> ApplicationProperties { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoicesItem { get; set; }
        public DbSet<Payment> Payment { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<UserDetail> UsersDetail { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }


    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        base.OnModelCreating(builder);

    //        builder.Entity<User>(b =>
    //        {
    //            b.ToTable("AspNetUsers");
    //            b.HasMany(u => u.UserRoles)
    //             .WithOne(ur => ur.User)
    //             .HasForeignKey(ur => ur.UserId)
    //             .IsRequired();
    //        });

    //        builder.Entity<Role>(role =>
    //        {
    //            role.ToTable("AspNetRoles");
    //            role.HasKey(r => r.Id);
    //            //role.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex");
    //            role.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();
    //            role.Property(u => u.Name).HasMaxLength(256);
    //            role.Property(u => u.ProgramDataId);
    //            role.Property(u => u.AccessLevelId);
    //            role.Property(u => u.NormalizedName).HasMaxLength(256);
    //            role.HasOne(x => x.AccessLevel)
    //            .WithMany()
    //            .HasForeignKey(x => x.AccessLevelId)
    //            .OnDelete(DeleteBehavior.Cascade);


    //            role.HasMany<UserRole>()
    //          .WithOne(ur => ur.Role)
    //          .HasForeignKey(ur => ur.RoleId)
    //          .IsRequired();
    //            role.HasMany<IdentityRoleClaim<string>>()
    //                .WithOne()
    //                .HasForeignKey(rc => rc.RoleId)
    //                .IsRequired();
    //        });

    //        builder.Entity<IdentityRoleClaim<string>>(roleClaim =>
    //        {
    //            roleClaim.HasKey(rc => rc.Id);
    //            roleClaim.ToTable("AspNetRoleClaims");
    //        });

    //        builder.Entity<UserRole>(userRole =>
    //        {
    //            userRole.ToTable("AspNetUserRoles");
    //            userRole.HasKey(r => new { r.UserId, r.RoleId });
    //        });

    //    }
    }
}
