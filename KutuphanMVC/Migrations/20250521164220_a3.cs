using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphanMVC.Migrations
{
    /// <inheritdoc />
    public partial class a3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ADminAd = table.Column<string>(type: "TEXT", nullable: true),
                    AdminSifre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "emanetKitaps",
                columns: table => new
                {
                    EmanetKitapId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KitapId = table.Column<int>(type: "INTEGER", nullable: false),
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emanetKitaps", x => x.EmanetKitapId);
                });

            migrationBuilder.CreateTable(
                name: "kitaps",
                columns: table => new
                {
                    KitapId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KitapAd = table.Column<string>(type: "TEXT", nullable: true),
                    YazarAd = table.Column<string>(type: "TEXT", nullable: true),
                    Yayinevi = table.Column<string>(type: "TEXT", nullable: true),
                    KitapTuru = table.Column<string>(type: "TEXT", nullable: true),
                    KitapSayfaSayisi = table.Column<string>(type: "TEXT", nullable: true),
                    Kresimad = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitaps", x => x.KitapId);
                });

            migrationBuilder.CreateTable(
                name: "kullanicis",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciAd = table.Column<string>(type: "TEXT", nullable: true),
                    KullaniciSifre = table.Column<string>(type: "TEXT", nullable: true),
                    KullaniciEmail = table.Column<string>(type: "TEXT", nullable: true),
                    KullaniciTel = table.Column<string>(type: "TEXT", nullable: true),
                    Resimadi = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanicis", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "mesajs",
                columns: table => new
                {
                    MesajId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MesajGonderen = table.Column<string>(type: "TEXT", nullable: true),
                    MesajKonu = table.Column<string>(type: "TEXT", nullable: true),
                    MesajMesaj = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mesajs", x => x.MesajId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "emanetKitaps");

            migrationBuilder.DropTable(
                name: "kitaps");

            migrationBuilder.DropTable(
                name: "kullanicis");

            migrationBuilder.DropTable(
                name: "mesajs");
        }
    }
}
