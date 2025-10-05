using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutebolApi.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Idade = table.Column<int>(type: "INTEGER", nullable: false),
                    Nacionalidade = table.Column<string>(type: "TEXT", nullable: false),
                    UltimoClube = table.Column<string>(type: "TEXT", nullable: false),
                    Posicao = table.Column<string>(type: "TEXT", nullable: false),
                    Qtde_Gols = table.Column<int>(type: "INTEGER", nullable: false),
                    SalarioMensal = table.Column<decimal>(type: "TEXT", nullable: false),
                    Altura = table.Column<double>(type: "REAL", nullable: false),
                    Peso = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Pais = table.Column<string>(type: "TEXT", nullable: false),
                    Fundacao = table.Column<string>(type: "TEXT", nullable: false),
                    Estadio = table.Column<string>(type: "TEXT", nullable: false),
                    Capacidade = table.Column<int>(type: "INTEGER", nullable: false),
                    Tecnico = table.Column<string>(type: "TEXT", nullable: false),
                    Alcunha = table.Column<string>(type: "TEXT", nullable: false),
                    Liga = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogador");

            migrationBuilder.DropTable(
                name: "Time");
        }
    }
}
