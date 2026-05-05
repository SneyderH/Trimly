using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trimly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Barberos_BarberoId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Servicios_ServicioId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuarios_UsuarioId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_BarberoId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_ServicioId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_UsuarioId",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "BarberoId",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "ServicioId",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Citas");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_BarberId",
                table: "Citas",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_ServiceId",
                table: "Citas",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_UserId",
                table: "Citas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Barberos_BarberId",
                table: "Citas",
                column: "BarberId",
                principalTable: "Barberos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Servicios_ServiceId",
                table: "Citas",
                column: "ServiceId",
                principalTable: "Servicios",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Barberos_BarberId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Servicios_ServiceId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuarios_UserId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_BarberId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_ServiceId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_UserId",
                table: "Citas");

            migrationBuilder.AddColumn<int>(
                name: "BarberoId",
                table: "Citas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServicioId",
                table: "Citas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Citas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_BarberoId",
                table: "Citas",
                column: "BarberoId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_ServicioId",
                table: "Citas",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_UsuarioId",
                table: "Citas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Barberos_BarberoId",
                table: "Citas",
                column: "BarberoId",
                principalTable: "Barberos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Servicios_ServicioId",
                table: "Citas",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuarios_UsuarioId",
                table: "Citas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
