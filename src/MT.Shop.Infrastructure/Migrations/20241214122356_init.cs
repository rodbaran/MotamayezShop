using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MT.Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvailableStock = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    VersionCtrl = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    VersionCtrl = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    VersionCtrl = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    VersionCtrl = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "AvailableStock", "Code", "CreatedBy", "CreatedOn", "IsActive", "IsDelete", "ModifiedBy", "ModifiedOn", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 59, "10000001", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(2710), true, false, null, null, "کالای 1", 45950000m },
                    { 2, 2, "10000002", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3914), true, false, null, null, "کالای 2", 32620000m },
                    { 3, 106, "10000003", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3918), true, false, null, null, "کالای 3", 92000000m },
                    { 4, 10, "10000004", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3920), true, false, null, null, "کالای 4", 70060000m },
                    { 5, 58, "10000005", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3922), true, false, null, null, "کالای 5", 70360000m },
                    { 6, 36, "10000006", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3928), true, false, null, null, "کالای 6", 21230000m },
                    { 7, 47, "10000007", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3929), true, false, null, null, "کالای 7", 65520000m },
                    { 8, 84, "10000008", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3931), true, false, null, null, "کالای 8", 37000000m },
                    { 9, 65, "10000009", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3933), true, false, null, null, "کالای 9", 23290000m },
                    { 10, 55, "10000010", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3938), true, false, null, null, "کالای 10", 97600000m },
                    { 11, 14, "10000011", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3940), true, false, null, null, "کالای 11", 43080000m },
                    { 12, 35, "10000012", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3941), true, false, null, null, "کالای 12", 7900000m },
                    { 13, 119, "10000013", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3943), true, false, null, null, "کالای 13", 5320000m },
                    { 14, 96, "10000014", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3945), true, false, null, null, "کالای 14", 36830000m },
                    { 15, 95, "10000015", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3947), true, false, null, null, "کالای 15", 39940000m },
                    { 16, 40, "10000016", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3948), true, false, null, null, "کالای 16", 28270000m },
                    { 17, 24, "10000017", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3950), true, false, null, null, "کالای 17", 550000m },
                    { 18, 89, "10000018", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3953), true, false, null, null, "کالای 18", 89230000m },
                    { 19, 14, "10000019", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3955), true, false, null, null, "کالای 19", 84400000m },
                    { 20, 17, "10000020", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3957), true, false, null, null, "کالای 20", 88260000m },
                    { 21, 33, "10000021", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3958), true, false, null, null, "کالای 21", 74660000m },
                    { 22, 47, "10000022", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3960), true, false, null, null, "کالای 22", 2840000m },
                    { 23, 67, "10000023", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3962), true, false, null, null, "کالای 23", 33970000m },
                    { 24, 64, "10000024", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3964), true, false, null, null, "کالای 24", 28820000m },
                    { 25, 12, "10000025", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3965), true, false, null, null, "کالای 25", 51810000m },
                    { 26, 61, "10000026", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3967), true, false, null, null, "کالای 26", 56250000m },
                    { 27, 10, "10000027", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3969), true, false, null, null, "کالای 27", 53560000m },
                    { 28, 19, "10000028", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3971), true, false, null, null, "کالای 28", 12990000m },
                    { 29, 102, "10000029", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3972), true, false, null, null, "کالای 29", 2560000m },
                    { 30, 25, "10000030", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3974), true, false, null, null, "کالای 30", 39730000m },
                    { 31, 88, "10000031", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3976), true, false, null, null, "کالای 31", 16030000m },
                    { 32, 87, "10000032", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3978), true, false, null, null, "کالای 32", 71500000m },
                    { 33, 123, "10000033", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3980), true, false, null, null, "کالای 33", 3150000m },
                    { 34, 28, "10000034", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3983), true, false, null, null, "کالای 34", 4490000m },
                    { 35, 12, "10000035", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3995), true, false, null, null, "کالای 35", 6320000m },
                    { 36, 42, "10000036", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3997), true, false, null, null, "کالای 36", 56020000m },
                    { 37, 9, "10000037", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(3998), true, false, null, null, "کالای 37", 26420000m },
                    { 38, 25, "10000038", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4000), true, false, null, null, "کالای 38", 40640000m },
                    { 39, 119, "10000039", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4002), true, false, null, null, "کالای 39", 77090000m },
                    { 40, 40, "10000040", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4004), true, false, null, null, "کالای 40", 58910000m },
                    { 41, 104, "10000041", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4005), true, false, null, null, "کالای 41", 27260000m },
                    { 42, 67, "10000042", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4007), true, false, null, null, "کالای 42", 85930000m },
                    { 43, 127, "10000043", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4009), true, false, null, null, "کالای 43", 45820000m },
                    { 44, 115, "10000044", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4011), true, false, null, null, "کالای 44", 43020000m },
                    { 45, 102, "10000045", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4013), true, false, null, null, "کالای 45", 86040000m },
                    { 46, 29, "10000046", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4015), true, false, null, null, "کالای 46", 23570000m },
                    { 47, 57, "10000047", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4016), true, false, null, null, "کالای 47", 6640000m },
                    { 48, 67, "10000048", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4018), true, false, null, null, "کالای 48", 23370000m },
                    { 49, 109, "10000049", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4020), true, false, null, null, "کالای 49", 37640000m },
                    { 50, 70, "10000050", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4022), true, false, null, null, "کالای 50", 87090000m },
                    { 51, 95, "10000051", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4024), true, false, null, null, "کالای 51", 29120000m },
                    { 52, 105, "10000052", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4025), true, false, null, null, "کالای 52", 12950000m },
                    { 53, 8, "10000053", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4027), true, false, null, null, "کالای 53", 13630000m },
                    { 54, 80, "10000054", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4029), true, false, null, null, "کالای 54", 39910000m },
                    { 55, 4, "10000055", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4031), true, false, null, null, "کالای 55", 13310000m },
                    { 56, 76, "10000056", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4032), true, false, null, null, "کالای 56", 85280000m },
                    { 57, 95, "10000057", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4034), true, false, null, null, "کالای 57", 76730000m },
                    { 58, 19, "10000058", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4036), true, false, null, null, "کالای 58", 18480000m },
                    { 59, 114, "10000059", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4038), true, false, null, null, "کالای 59", 66690000m },
                    { 60, 89, "10000060", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4040), true, false, null, null, "کالای 60", 78040000m },
                    { 61, 47, "10000061", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4041), true, false, null, null, "کالای 61", 3840000m },
                    { 62, 57, "10000062", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4043), true, false, null, null, "کالای 62", 90740000m },
                    { 63, 115, "10000063", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4045), true, false, null, null, "کالای 63", 15440000m },
                    { 64, 71, "10000064", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4047), true, false, null, null, "کالای 64", 73150000m },
                    { 65, 97, "10000065", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4049), true, false, null, null, "کالای 65", 69170000m },
                    { 66, 39, "10000066", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4051), true, false, null, null, "کالای 66", 27290000m },
                    { 67, 3, "10000067", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4053), true, false, null, null, "کالای 67", 51030000m },
                    { 68, 111, "10000068", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4055), true, false, null, null, "کالای 68", 42620000m },
                    { 69, 62, "10000069", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4056), true, false, null, null, "کالای 69", 43720000m },
                    { 70, 92, "10000070", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4058), true, false, null, null, "کالای 70", 30360000m },
                    { 71, 49, "10000071", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4060), true, false, null, null, "کالای 71", 74410000m },
                    { 72, 27, "10000072", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4062), true, false, null, null, "کالای 72", 27210000m },
                    { 73, 115, "10000073", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4070), true, false, null, null, "کالای 73", 20050000m },
                    { 74, 56, "10000074", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4072), true, false, null, null, "کالای 74", 540000m },
                    { 75, 9, "10000075", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4074), true, false, null, null, "کالای 75", 64970000m },
                    { 76, 23, "10000076", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4076), true, false, null, null, "کالای 76", 81800000m },
                    { 77, 128, "10000077", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4077), true, false, null, null, "کالای 77", 24550000m },
                    { 78, 71, "10000078", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4079), true, false, null, null, "کالای 78", 27160000m },
                    { 79, 109, "10000079", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4081), true, false, null, null, "کالای 79", 38160000m },
                    { 80, 44, "10000080", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4083), true, false, null, null, "کالای 80", 15780000m },
                    { 81, 95, "10000081", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4084), true, false, null, null, "کالای 81", 40170000m },
                    { 82, 75, "10000082", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4086), true, false, null, null, "کالای 82", 5770000m },
                    { 83, 125, "10000083", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4088), true, false, null, null, "کالای 83", 41260000m },
                    { 84, 43, "10000084", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4090), true, false, null, null, "کالای 84", 75240000m },
                    { 85, 61, "10000085", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4174), true, false, null, null, "کالای 85", 67080000m },
                    { 86, 72, "10000086", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4177), true, false, null, null, "کالای 86", 39110000m },
                    { 87, 98, "10000087", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4178), true, false, null, null, "کالای 87", 35100000m },
                    { 88, 54, "10000088", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4180), true, false, null, null, "کالای 88", 49130000m },
                    { 89, 77, "10000089", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4182), true, false, null, null, "کالای 89", 25530000m },
                    { 90, 63, "10000090", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4183), true, false, null, null, "کالای 90", 54680000m },
                    { 91, 38, "10000091", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4185), true, false, null, null, "کالای 91", 67280000m },
                    { 92, 69, "10000092", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4187), true, false, null, null, "کالای 92", 65590000m },
                    { 93, 97, "10000093", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4189), true, false, null, null, "کالای 93", 83820000m },
                    { 94, 71, "10000094", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4190), true, false, null, null, "کالای 94", 88560000m },
                    { 95, 67, "10000095", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4192), true, false, null, null, "کالای 95", 14800000m },
                    { 96, 118, "10000096", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4194), true, false, null, null, "کالای 96", 52790000m },
                    { 97, 89, "10000097", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4197), true, false, null, null, "کالای 97", 69820000m },
                    { 98, 12, "10000098", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4199), true, false, null, null, "کالای 98", 85330000m },
                    { 99, 126, "10000099", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4201), true, false, null, null, "کالای 99", 53470000m },
                    { 100, 81, "10000100", 0, new DateTime(2024, 12, 14, 12, 23, 55, 762, DateTimeKind.Utc).AddTicks(4203), true, false, null, null, "کالای 100", 73820000m }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedOn", "Email", "FirstName", "IsDelete", "LastName", "ModifiedBy", "ModifiedOn", "PhoneNumber" },
                values: new object[] { 1, "Tehran", 0, new DateTime(2024, 12, 14, 12, 23, 55, 760, DateTimeKind.Utc).AddTicks(6545), "rodbaran@Gmail.com", "حسین", false, "رودباران", null, null, "09120753301" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
