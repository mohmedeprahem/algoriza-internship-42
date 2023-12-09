﻿// <auto-generated />
using System;
using Infrastructure.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpecializationId")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("SpecializationId");

                    b.ToTable("AspNetUsers", null, t =>
                        {
                            t.HasCheckConstraint("CK_AspNetUsers_Gender", "Gender IN ('Male', 'Female')");
                        });
                });

            modelBuilder.Entity("Core.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("DayId")
                        .HasColumnType("int");

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("Core.Models.AppointmentTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<int>("TimeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("TimeId");

                    b.ToTable("AppointmentTimes", (string)null);
                });

            modelBuilder.Entity("Core.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentTimeId")
                        .HasColumnType("int");

                    b.Property<int>("BookingStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasComputedColumnSql("getutcdate()");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("DiscountId")
                        .HasColumnType("int");

                    b.Property<int>("FinalPrice")
                        .HasColumnType("int");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentTimeId")
                        .IsUnique();

                    b.HasIndex("BookingStatusId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("PatientId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Bookings", (string)null);
                });

            modelBuilder.Entity("Core.Models.BookingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("BookingStatuses", null, t =>
                        {
                            t.HasCheckConstraint("CK_BookingStatuses_Name", "Name IN ('Binding', 'Completed', 'Cancelled')");
                        });
                });

            modelBuilder.Entity("Core.Models.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Days", null, t =>
                        {
                            t.HasCheckConstraint("CK_Days_Name", "Name IN ('Saturday', 'Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday')");
                        });
                });

            modelBuilder.Entity("Core.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiscountCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountTypeId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountValue")
                        .HasColumnType("int");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DiscountTypeId");

                    b.ToTable("Discounts", (string)null);
                });

            modelBuilder.Entity("Core.Models.DiscountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("DiscountTypes", null, t =>
                        {
                            t.HasCheckConstraint("CK_DiscountTypes_Name", "Name IN ('Percentage', 'Value')");
                        });
                });

            modelBuilder.Entity("Core.Models.ExaminationPrice", b =>
                {
                    b.Property<string>("DoctorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("DoctorId");

                    b.ToTable("ExaminationPrices", (string)null);
                });

            modelBuilder.Entity("Core.Models.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Specializations", (string)null);
                });

            modelBuilder.Entity("Core.Models.Time", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeOnly>("TimeValue")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Times", (string)null);
                });

            modelBuilder.Entity("Core.Models.UserBookingTracking", b =>
                {
                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AprovedBookingCount")
                        .HasColumnType("int");

                    b.HasKey("PatientId");

                    b.ToTable("UserBookingTracking", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Core.Models.ApplicationUser", b =>
                {
                    b.HasOne("Core.Models.Specialization", "Specialization")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializationId");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("Core.Models.Appointment", b =>
                {
                    b.HasOne("Core.Models.Day", "Day")
                        .WithMany("Appointments")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.ApplicationUser", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Core.Models.AppointmentTime", b =>
                {
                    b.HasOne("Core.Models.Appointment", "Appointment")
                        .WithMany("Times")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.Time", "Time")
                        .WithMany("Appointments")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("Core.Models.Booking", b =>
                {
                    b.HasOne("Core.Models.AppointmentTime", "AppointmentTime")
                        .WithOne("Booking")
                        .HasForeignKey("Core.Models.Booking", "AppointmentTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.BookingStatus", "BookingStatus")
                        .WithMany("Bookings")
                        .HasForeignKey("BookingStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.Discount", "Discount")
                        .WithMany("Bookings")
                        .HasForeignKey("DiscountId");

                    b.HasOne("Core.Models.ApplicationUser", "Patient")
                        .WithMany("PatientBookings")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Core.Models.Specialization", "Specialization")
                        .WithMany("Bookings")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentTime");

                    b.Navigation("BookingStatus");

                    b.Navigation("Discount");

                    b.Navigation("Patient");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("Core.Models.Discount", b =>
                {
                    b.HasOne("Core.Models.DiscountType", "DiscountType")
                        .WithMany("Discounts")
                        .HasForeignKey("DiscountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiscountType");
                });

            modelBuilder.Entity("Core.Models.ExaminationPrice", b =>
                {
                    b.HasOne("Core.Models.ApplicationUser", "Doctor")
                        .WithOne("Price")
                        .HasForeignKey("Core.Models.ExaminationPrice", "DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Core.Models.UserBookingTracking", b =>
                {
                    b.HasOne("Core.Models.ApplicationUser", "Patient")
                        .WithOne("AprovedBookingCount")
                        .HasForeignKey("Core.Models.UserBookingTracking", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Core.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Core.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Core.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Models.ApplicationUser", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("AprovedBookingCount")
                        .IsRequired();

                    b.Navigation("PatientBookings");

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Models.Appointment", b =>
                {
                    b.Navigation("Times");
                });

            modelBuilder.Entity("Core.Models.AppointmentTime", b =>
                {
                    b.Navigation("Booking")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Models.BookingStatus", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Core.Models.Day", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Core.Models.Discount", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Core.Models.DiscountType", b =>
                {
                    b.Navigation("Discounts");
                });

            modelBuilder.Entity("Core.Models.Specialization", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("Core.Models.Time", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
