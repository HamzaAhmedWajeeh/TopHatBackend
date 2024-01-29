using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopHatApp.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admins__3213E83F38995064", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__3213E83F03D171A1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    lastname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    state = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    postcode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3213E83F97EA8021", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: true),
                    qty = table.Column<int>(type: "int", nullable: true),
                    image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    image1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    image2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    image3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    image4 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    image5 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MenuItem__3213E83FE1FDBF0A", x => x.id);
                    table.ForeignKey(
                        name: "fk_category",
                        column: x => x.categoryid,
                        principalTable: "Categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: true),
                    feedbacktext = table.Column<string>(type: "text", nullable: false),
                    submissiondate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feedback__3213E83F14764ACD", x => x.id);
                    table.ForeignKey(
                        name: "fk_feedback_user",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "LoyaltyPoints",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LoyaltyP__CBA1B25727FC03E8", x => x.userid);
                    table.ForeignKey(
                        name: "fk_loyalty_user",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: true),
                    cardnumber = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    expirydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cardholdername = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payments__3213E83F85495BDD", x => x.id);
                    table.ForeignKey(
                        name: "fk_payment_user",
                        column: x => x.id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: true),
                    itemid = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart__3213E83F0C07C7B5", x => x.id);
                    table.ForeignKey(
                        name: "fk_cart_item",
                        column: x => x.itemid,
                        principalTable: "MenuItems",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_cart_user",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: true),
                    paymentid = table.Column<int>(type: "int", nullable: true),
                    orderdate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    totalamount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    orderstatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "Pending"),
                    paymentstatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "Unpaid")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__3213E83F65AB6422", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_payment",
                        column: x => x.paymentid,
                        principalTable: "Payments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_user",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderid = table.Column<int>(type: "int", nullable: true),
                    itemid = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderIte__3213E83F96951BE7", x => x.id);
                    table.ForeignKey(
                        name: "fk_item",
                        column: x => x.itemid,
                        principalTable: "MenuItems",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_order",
                        column: x => x.orderid,
                        principalTable: "Orders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_itemid",
                table: "Cart",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_userid",
                table: "Cart",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_userid",
                table: "Feedback",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_categoryid",
                table: "MenuItems",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_itemid",
                table: "OrderItems",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_orderid",
                table: "OrderItems",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_paymentid",
                table: "Orders",
                column: "paymentid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userid",
                table: "Orders",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "LoyaltyPoints");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
