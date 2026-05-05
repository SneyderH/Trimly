using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Trimly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RedisenioDominio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Barberos_BarberId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuarios_UserId",
                table: "Citas");

            migrationBuilder.DropTable(
                name: "Barberos");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Citas",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "BarberId",
                table: "Citas",
                newName: "BarberoId");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_UserId",
                table: "Citas",
                newName: "IX_Citas_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_BarberId",
                table: "Citas",
                newName: "IX_Citas_BarberoId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Usuarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Usuarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Rol",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Servicios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHora",
                table: "Citas",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "Barberias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    AdminId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barberias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barberias_Usuarios_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pefiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FotoUrl = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pefiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pefiles_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarberiasBarberos",
                columns: table => new
                {
                    BarberoId = table.Column<int>(type: "integer", nullable: false),
                    BarberiaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberiasBarberos", x => new { x.BarberoId, x.BarberiaId });
                    table.ForeignKey(
                        name: "FK_BarberiasBarberos_Barberias_BarberiaId",
                        column: x => x.BarberiaId,
                        principalTable: "Barberias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BarberiasBarberos_Usuarios_BarberoId",
                        column: x => x.BarberoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barberias_AdminId",
                table: "Barberias",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_BarberiasBarberos_BarberiaId",
                table: "BarberiasBarberos",
                column: "BarberiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pefiles_UsuarioId",
                table: "Pefiles",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuarios_BarberoId",
                table: "Citas",
                column: "BarberoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuarios_ClienteId",
                table: "Citas",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuarios_BarberoId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuarios_ClienteId",
                table: "Citas");

            migrationBuilder.DropTable(
                name: "BarberiasBarberos");

            migrationBuilder.DropTable(
                name: "Pefiles");

            migrationBuilder.DropTable(
                name: "Barberias");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Citas",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "BarberoId",
                table: "Citas",
                newName: "BarberId");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_ClienteId",
                table: "Citas",
                newName: "IX_Citas_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_BarberoId",
                table: "Citas",
                newName: "IX_Citas_BarberId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Servicios",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHora",
                table: "Citas",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.CreateTable(
                name: "Barberos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barberos", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Barberos_BarberId",
                table: "Citas",
                column: "BarberId",
                principalTable: "Barberos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuarios_UserId",
                table: "Citas",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
