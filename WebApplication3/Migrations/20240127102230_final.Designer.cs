﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Top_Hat_App.Models;

#nullable disable

namespace TopHatApp.Migrations
{
    [DbContext(typeof(TopHatContext))]
    [Migration("20240127102230_final")]
    partial class final
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Top_Hat_App.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("PK__Admins__3213E83F38995064");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Top_Hat_App.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Itemid")
                        .HasColumnType("int")
                        .HasColumnName("itemid");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<int?>("Userid")
                        .HasColumnType("int")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("PK__Cart__3213E83F0C07C7B5");

                    b.HasIndex("Itemid");

                    b.HasIndex("Userid");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("Top_Hat_App.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__Categori__3213E83F03D171A1");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Top_Hat_App.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Feedbacktext")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("feedbacktext");

                    b.Property<DateTime?>("Submissiondate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("submissiondate")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("Userid")
                        .HasColumnType("int")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("PK__Feedback__3213E83F14764ACD");

                    b.HasIndex("Userid");

                    b.ToTable("Feedback", (string)null);
                });

            modelBuilder.Entity("Top_Hat_App.Models.LoyaltyPoint", b =>
                {
                    b.Property<int>("Userid")
                        .HasColumnType("int")
                        .HasColumnName("userid");

                    b.Property<int?>("Points")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("points");

                    b.HasKey("Userid")
                        .HasName("PK__LoyaltyP__CBA1B25727FC03E8");

                    b.ToTable("LoyaltyPoints");
                });

            modelBuilder.Entity("Top_Hat_App.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Categoryid")
                        .HasColumnType("int")
                        .HasColumnName("categoryid");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("image");

                    b.Property<string>("Image1")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("image1");

                    b.Property<string>("Image2")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("image2");

                    b.Property<string>("Image3")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("image3");

                    b.Property<string>("Image4")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("image4");

                    b.Property<string>("Image5")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("image5");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("price");

                    b.Property<int?>("Qty")
                        .HasColumnType("int")
                        .HasColumnName("qty");

                    b.HasKey("Id")
                        .HasName("PK__MenuItem__3213E83FE1FDBF0A");

                    b.HasIndex("Categoryid");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Top_Hat_App.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Orderdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("orderdate")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Orderstatus")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasDefaultValue("Pending")
                        .HasColumnName("orderstatus");

                    b.Property<int?>("Paymentid")
                        .HasColumnType("int")
                        .HasColumnName("paymentid");

                    b.Property<string>("Paymentstatus")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasDefaultValue("Unpaid")
                        .HasColumnName("paymentstatus");

                    b.Property<decimal>("Totalamount")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("totalamount");

                    b.Property<int?>("Userid")
                        .HasColumnType("int")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("PK__Orders__3213E83F65AB6422");

                    b.HasIndex("Paymentid");

                    b.HasIndex("Userid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Top_Hat_App.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Itemid")
                        .HasColumnType("int")
                        .HasColumnName("itemid");

                    b.Property<int?>("Orderid")
                        .HasColumnType("int")
                        .HasColumnName("orderid");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("subtotal");

                    b.HasKey("Id")
                        .HasName("PK__OrderIte__3213E83F96951BE7");

                    b.HasIndex("Itemid");

                    b.HasIndex("Orderid");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Top_Hat_App.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Cardholdername")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("cardholdername");

                    b.Property<string>("Cardnumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("cardnumber");

                    b.Property<DateTime>("Expirydate")
                        .HasColumnType("datetime2")
                        .HasColumnName("expirydate");

                    b.Property<int?>("Userid")
                        .HasColumnType("int")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("PK__Payments__3213E83F85495BDD");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Top_Hat_App.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("city");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Firstname")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("firstname");

                    b.Property<string>("Lastname")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("lastname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("phone");

                    b.Property<string>("Postcode")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("postcode");

                    b.Property<string>("State")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("state");

                    b.HasKey("Id")
                        .HasName("PK__Users__3213E83F97EA8021");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Top_Hat_App.Models.Cart", b =>
                {
                    b.HasOne("Top_Hat_App.Models.MenuItem", "Item")
                        .WithMany("Carts")
                        .HasForeignKey("Itemid")
                        .HasConstraintName("fk_cart_item");

                    b.HasOne("Top_Hat_App.Models.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("Userid")
                        .HasConstraintName("fk_cart_user");

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Top_Hat_App.Models.Feedback", b =>
                {
                    b.HasOne("Top_Hat_App.Models.User", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("Userid")
                        .HasConstraintName("fk_feedback_user");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Top_Hat_App.Models.LoyaltyPoint", b =>
                {
                    b.HasOne("Top_Hat_App.Models.User", "User")
                        .WithOne("LoyaltyPoint")
                        .HasForeignKey("Top_Hat_App.Models.LoyaltyPoint", "Userid")
                        .IsRequired()
                        .HasConstraintName("fk_loyalty_user");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Top_Hat_App.Models.MenuItem", b =>
                {
                    b.HasOne("Top_Hat_App.Models.Category", "Category")
                        .WithMany("MenuItems")
                        .HasForeignKey("Categoryid")
                        .HasConstraintName("fk_category");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Top_Hat_App.Models.Order", b =>
                {
                    b.HasOne("Top_Hat_App.Models.Payment", "Payment")
                        .WithMany("Orders")
                        .HasForeignKey("Paymentid")
                        .HasConstraintName("fk_order_payment");

                    b.HasOne("Top_Hat_App.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("Userid")
                        .HasConstraintName("fk_user");

                    b.Navigation("Payment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Top_Hat_App.Models.OrderItem", b =>
                {
                    b.HasOne("Top_Hat_App.Models.MenuItem", "Item")
                        .WithMany("OrderItems")
                        .HasForeignKey("Itemid")
                        .HasConstraintName("fk_item");

                    b.HasOne("Top_Hat_App.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("Orderid")
                        .HasConstraintName("fk_order");

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Top_Hat_App.Models.Payment", b =>
                {
                    b.HasOne("Top_Hat_App.Models.User", "IdNavigation")
                        .WithOne("Payment")
                        .HasForeignKey("Top_Hat_App.Models.Payment", "Id")
                        .IsRequired()
                        .HasConstraintName("fk_payment_user");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("Top_Hat_App.Models.Category", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("Top_Hat_App.Models.MenuItem", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Top_Hat_App.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Top_Hat_App.Models.Payment", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Top_Hat_App.Models.User", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Feedbacks");

                    b.Navigation("LoyaltyPoint");

                    b.Navigation("Orders");

                    b.Navigation("Payment");
                });
#pragma warning restore 612, 618
        }
    }
}
