using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Access.Migrations
{
    public partial class l : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameInstractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameImageURL = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GameName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameInstractions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Creater = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "jackbotWinner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JackbotName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfWinning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnerName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    GotIt = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jackbotWinner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mainer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Creater = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mainer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Creater = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mini",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Creater = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mini", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    Creater = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LoginTimes = table.Column<int>(type: "int", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceOut = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PercantageOfLuck = table.Column<int>(type: "int", nullable: false),
                    DoubleBunosActive = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Level = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "ChargeHistories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Creater = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    BalanceIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceOut = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChargeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargeHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChargeHistories_users_Creater",
                        column: x => x.Creater,
                        principalTable: "users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameHistories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Creater = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    GameName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WLAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lines = table.Column<int>(type: "int", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeSpin = table.Column<bool>(type: "bit", nullable: false),
                    Wild = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GameHistories_users_Creater",
                        column: x => x.Creater,
                        principalTable: "users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginHistories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    LoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creater = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LoginHistories_users_Creater",
                        column: x => x.Creater,
                        principalTable: "users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Username", "Balance", "BalanceIn", "BalanceOut", "Creater", "DoubleBunosActive", "Ip", "LastLogin", "Level", "LoginTimes", "Password", "PercantageOfLuck", "Status", "UserType" },
                values: new object[,]
                {
                    { "Christina Strosin", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Frank Beier", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Antonio Kertzmann", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Eva Kreiger", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Devin Robel", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Hilda Monahan", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Alfonso Littel", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Karen Osinski", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Everett Huel", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Frederick Torphy", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Chester Osinski", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Nettie Hoeger", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Seth Emard", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Salvatore Harris", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Charlotte Lehner", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Jan Durgan", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Dallas Flatley", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Tonya Crist", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Tami Hilpert", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Marguerite Raynor", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Edmund Hackett", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Hope Collins", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Lois Halvorson", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Kim Sipes", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Darin Hickle", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Jackie Hansen", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Darrell Dickens", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Josephine Brekke", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Kelly Rosenbaum", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Ricardo Flatley", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Alex Rohan", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Garry Ferry", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Lorene Robel", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Timmy Wilkinson", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Jeanne Ritchie", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Erin Price", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Brittany Corwin", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Luz Stehr", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Joan Jacobs", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Blanca Effertz", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Jo Swaniawski", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Eva Cremin", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Username", "Balance", "BalanceIn", "BalanceOut", "Creater", "DoubleBunosActive", "Ip", "LastLogin", "Level", "LoginTimes", "Password", "PercantageOfLuck", "Status", "UserType" },
                values: new object[,]
                {
                    { "Stuart Bogan", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Ed Langosh", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Roderick Lakin", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Luke Considine", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Glenn Schmidt", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Shelia Stracke", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Joanne Mohr", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Emanuel Fay", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "John Heidenreich", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Lorene Koepp", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Kelli Weissnat", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Rhonda Bechtelar", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Israel Conroy", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Ana Lindgren", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Sabrina Mayer", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Christopher Walsh", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Paulette Windler", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Sergio Bailey", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Johnnie Leffler", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Tony Bogisich", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Opal Schmitt", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Beulah Cummings", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Ramiro Haag", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Kristy Koelpin", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Stuart Carter", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Nathaniel Rutherford", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Marta Hoppe", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Tabitha Boyle", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Terrance Wunsch", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Frederick Kautzer", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Mercedes Nolan", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Randy MacGyver", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Camille Ernser", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Hubert Kilback", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Rose Strosin", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Lynn Lesch", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Lola Boehm", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Bertha Mohr", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Hugo Kuhlman", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Jacquelyn Volkman", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Alberta Mueller", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Isabel Sauer", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Username", "Balance", "BalanceIn", "BalanceOut", "Creater", "DoubleBunosActive", "Ip", "LastLogin", "Level", "LoginTimes", "Password", "PercantageOfLuck", "Status", "UserType" },
                values: new object[,]
                {
                    { "Frances Marvin", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Kelley Cruickshank", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Stewart Thiel", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Robyn Spinka", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Rose Casper", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Greg Veum", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Sherri Hessel", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Jermaine Gerlach", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Gilberto Schowalter", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Bradley Schroeder", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Janis Shanahan", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Dixie Wyman", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Kari Dickens", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Lucas Swaniawski", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Gabriel Kub", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" },
                    { "Boyd Roob", 0m, 0m, 0m, "george", "Active", "l", new DateTime(2020, 12, 20, 19, 14, 57, 0, DateTimeKind.Unspecified), 0.0, 0, "159753Abo", 70, "off", "Player" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChargeHistories_Creater",
                table: "ChargeHistories",
                column: "Creater");

            migrationBuilder.CreateIndex(
                name: "IX_GameHistories_Creater",
                table: "GameHistories",
                column: "Creater");

            migrationBuilder.CreateIndex(
                name: "IX_LoginHistories_Creater",
                table: "LoginHistories",
                column: "Creater");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargeHistories");

            migrationBuilder.DropTable(
                name: "GameHistories");

            migrationBuilder.DropTable(
                name: "GameInstractions");

            migrationBuilder.DropTable(
                name: "Grand");

            migrationBuilder.DropTable(
                name: "jackbotWinner");

            migrationBuilder.DropTable(
                name: "LoginHistories");

            migrationBuilder.DropTable(
                name: "Mainer");

            migrationBuilder.DropTable(
                name: "Major");

            migrationBuilder.DropTable(
                name: "Mini");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
