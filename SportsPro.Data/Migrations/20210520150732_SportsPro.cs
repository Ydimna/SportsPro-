using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsPro.Data.Migrations
{
    public partial class SportsPro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authentication",
                columns: table => new
                {
                    AuthenticationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication", x => x.AuthenticationID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    YearlyPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Technician",
                columns: table => new
                {
                    TechnicianID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technician", x => x.TechnicianID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    CountryID = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customer_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    IncidentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    TechnicianID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DateOpened = table.Column<DateTime>(nullable: false),
                    DateClosed = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.IncidentID);
                    table.ForeignKey(
                        name: "FK_Incident_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incident_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incident_Technician_TechnicianID",
                        column: x => x.TechnicianID,
                        principalTable: "Technician",
                        principalColumn: "TechnicianID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    RegistrationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.RegistrationID);
                    table.ForeignKey(
                        name: "FK_Registration_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authentication",
                columns: new[] { "AuthenticationID", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "P@ssw0rd", "admin" },
                    { 2, "tech", "tech" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryID", "Name" },
                values: new object[,]
                {
                    { "NZ", "New Zealand" },
                    { "NG", "Nigeria" },
                    { "PT", "Portugal" },
                    { "PR", "Puerto Rico" },
                    { "QA", "Qatar" },
                    { "SG", "Singapore" },
                    { "ES", "Spain" },
                    { "SE", "Sweden" },
                    { "CH", "Switzerland" },
                    { "TH", "Thailand" },
                    { "TR", "Turkey" },
                    { "UA", "Ukraine" },
                    { "AE", "United Arab Emirates" },
                    { "GB", "United Kingdom" },
                    { "US", "United States" },
                    { "VN", "Vietnam" },
                    { "ZW", "Zimbabwe" },
                    { "NL", "Netherlands" },
                    { "MX", "Mexico" },
                    { "PH", "Philippines" },
                    { "LR", "Liberia" },
                    { "AU", "Australia" },
                    { "AT", "Austria" },
                    { "BE", "Belgium" },
                    { "BR", "Brazil" },
                    { "MY", "Malaysia" },
                    { "CN", "China" },
                    { "DK", "Denmark" },
                    { "FI", "Finland" },
                    { "FR", "France" },
                    { "CA", "Canada" },
                    { "GL", "Greenland" },
                    { "HK", "Hong Kong" },
                    { "IS", "Iceland" },
                    { "IN", "India" },
                    { "IE", "Ireland" },
                    { "IL", "Israel" },
                    { "IT", "Italy" },
                    { "JP", "Japan" },
                    { "GR", "Greece" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "Name", "ProductCode", "ReleaseDate", "YearlyPrice" },
                values: new object[,]
                {
                    { 7, "Tournament Master 2.0", "TRNY20", new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.99m },
                    { 6, "Tournament Master 1.0", "TRNY10", new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 5, "Team Manager 1.0", "TEAM10", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 2, "Draft Manager 2.0", "DRAFT20", new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.99m },
                    { 3, "League Scheduler 1.0", "LEAG10", new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 1, "Draft Manager 1.0", "DRAFT10", new DateTime(2017, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 4, "League Scheduler Deluxe 1.0", "LEAGD10", new DateTime(2016, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.99m }
                });

            migrationBuilder.InsertData(
                table: "Technician",
                columns: new[] { "TechnicianID", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 14, "gunter@sportsprosoftware.com", "Gunter Wendt", "800-555-0400" },
                    { 11, "alison@sportsprosoftware.com", "Alison Diaz", "800-555-0443" },
                    { 12, "jason@sportsprosoftware.com", "Jason Lee", "800-555-0444" },
                    { 13, "awilson@sportsprosoftware.com", "Andrew Wilson", "800-555-0449" },
                    { 15, "gfiori@sportsprosoftware.com", "Gina Fiori", "800-555-0459" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "Address", "City", "CountryID", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1002, "PO Box 96621", "Washington", "US", "ania@mma.nidc.com", "Ania", "Irvin", "(301) 555-8950", "20090", "DC" },
                    { 1004, "1990 Westwood Blvd Ste 260", "Los Angeles", "US", "kenzie@mma.jobtrak.com", "Kenzie", "Quinn", "(800) 555-8725", "90025", "CA" },
                    { 1006, "3255 Ramos Cir", "Sacramento", "US", "amauro@yahoo.org", "Anton", "Mauro", "(916) 555-6670", "95827", "CA" },
                    { 1008, "Box 52001", "San Francisco", "US", "kanthoni@pge.com", "Kaitlyn", "Anthoni", "(800) 555-6081", "94152", "CA" },
                    { 1010, "PO Box 2069", "Fresno", "US", "kmayte@fresno.ca.gov", "Kendall", "Mayte", "(559) 555-9999", "93718", "CA" },
                    { 1012, "4420 N. First Street, Suite 108", "Fresno", "US", "marvin@expedata.com", "Marvin", "Quintin", "(559) 555-9586", "93726", "CA" },
                    { 1015, "27371 Valderas", "Mission Viejo", "US", "", "Gonzalo", "Keeton", "(214) 555-3647", "92691", "CA" }
                });

            migrationBuilder.InsertData(
                table: "Incident",
                columns: new[] { "IncidentID", "CustomerID", "DateClosed", "DateOpened", "Description", "ProductID", "TechnicianID", "Title" },
                values: new object[,]
                {
                    { 2, 1002, null, new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Received error message 415 while trying to import data from previous version.", 4, 14, "Error importing data" },
                    { 1, 1010, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media appears to be bad.", 1, 11, "Could not install" },
                    { 4, 1010, null, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Program fails with error code 510, unable to open database.", 3, null, "Error launching program" },
                    { 3, 1015, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Setup failed with code 104.", 6, 15, "Could not install" }
                });

            migrationBuilder.InsertData(
                table: "Registration",
                columns: new[] { "RegistrationID", "CustomerID", "ProductID" },
                values: new object[,]
                {
                    { 2, 1010, 3 },
                    { 1, 1015, 6 },
                    { 3, 1015, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CountryID",
                table: "Customer",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_CustomerID",
                table: "Incident",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_ProductID",
                table: "Incident",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_TechnicianID",
                table: "Incident",
                column: "TechnicianID");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_CustomerID",
                table: "Registration",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_ProductID",
                table: "Registration",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authentication");

            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Technician");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
