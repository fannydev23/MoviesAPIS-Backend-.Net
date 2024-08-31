using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesAPIS.Migrations
{
    /// <inheritdoc />
    public partial class tableRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    ActorsidActor = table.Column<int>(type: "int", nullable: false),
                    MoviesidMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.ActorsidActor, x.MoviesidMovie });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorsidActor",
                        column: x => x.ActorsidActor,
                        principalTable: "Actors",
                        principalColumn: "idActor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MoviesidMovie",
                        column: x => x.MoviesidMovie,
                        principalTable: "Movies",
                        principalColumn: "idMovie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    GendersidGender = table.Column<int>(type: "int", nullable: false),
                    MoviesidMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.GendersidGender, x.MoviesidMovie });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genders_GendersidGender",
                        column: x => x.GendersidGender,
                        principalTable: "Genders",
                        principalColumn: "idGender",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_MoviesidMovie",
                        column: x => x.MoviesidMovie,
                        principalTable: "Movies",
                        principalColumn: "idMovie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_MoviesidMovie",
                table: "MovieActors",
                column: "MoviesidMovie");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_MoviesidMovie",
                table: "MovieGenres",
                column: "MoviesidMovie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieGenres");
        }
    }
}
