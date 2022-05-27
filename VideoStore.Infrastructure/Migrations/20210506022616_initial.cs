using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoStore.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    VoteAvarage = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Popularity = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieActor",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActor", x => new { x.MovieId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_MovieActor_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActor_Person_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieDirector",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirector", x => new { x.MovieId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_MovieDirector_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDirector_Person_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieProductionCompany",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ProductionCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieProductionCompany", x => new { x.MovieId, x.ProductionCompanyId });
                    table.ForeignKey(
                        name: "FK_MovieProductionCompany_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieProductionCompany_ProductionCompanies_ProductionCompanyId",
                        column: x => x.ProductionCompanyId,
                        principalTable: "ProductionCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Romance" },
                    { 2, "Terror" },
                    { 3, "Comedia" },
                    { 4, "Action" },
                    { 5, "Fiction" },
                    { 6, "Adventure" },
                    { 7, "Documentary" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DeletedAt", "Overview", "Popularity", "Title" },
                values: new object[,]
                {
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1.0, "Movie Best 9" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2.0, "Movie Best 8" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5.0, "Movie Best 7" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2.0, "Movie Best 6" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8.0, "Movie Best 5" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2.0, "Movie Best 4" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1.0, "Movie Best 3" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4.0, "Movie Best 2" },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3.0, "Movie Best 1" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Biography", "Birthday", "CreatedAt", "Gender", "Name" },
                values: new object[,]
                {
                    { 14, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Emma" },
                    { 13, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Liam" },
                    { 12, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Olivia" },
                    { 11, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Oliver" },
                    { 10, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Elijah" },
                    { 9, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Benjamin" },
                    { 8, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Sophia" },
                    { 5, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Charlotte" },
                    { 6, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Harper" },
                    { 4, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Lucas" },
                    { 3, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "James" },
                    { 2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Noah" },
                    { 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Tom Wall" },
                    { 7, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Ava" }
                });

            migrationBuilder.InsertData(
                table: "ProductionCompanies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "606 Films" },
                    { 8, "Three Mills Studios" },
                    { 7, "Shepperton Studios" },
                    { 6, "Pinewood Studios" },
                    { 3, "Paramount" },
                    { 4, "Pixar" },
                    { 2, "Fox" },
                    { 1, "NetFlix" },
                    { 5, "Marv Films" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "DeletedAt", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "6f2cb9dd8f4b65e24e1c3f3fa5bc57982349237f11abceacd45bbcb74d621c25", "admin" },
                    { 2, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@user.com", "User", "e7f5c00bfc7067a49da98fa9b1eacd8d428a4632197edaa84c9dacd40ca35050", "user" }
                });

            migrationBuilder.InsertData(
                table: "MovieActor",
                columns: new[] { "MovieId", "PeopleId" },
                values: new object[,]
                {
                    { 4, 4 },
                    { 6, 2 },
                    { 1, 2 },
                    { 7, 3 },
                    { 6, 1 },
                    { 5, 1 },
                    { 3, 1 },
                    { 1, 1 },
                    { 7, 6 },
                    { 5, 6 },
                    { 3, 8 },
                    { 4, 8 },
                    { 5, 3 },
                    { 1, 5 },
                    { 4, 9 },
                    { 4, 5 },
                    { 2, 10 },
                    { 2, 11 },
                    { 8, 11 },
                    { 2, 12 },
                    { 9, 12 },
                    { 2, 13 },
                    { 8, 13 },
                    { 2, 14 },
                    { 9, 14 },
                    { 3, 9 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "MovieDirector",
                columns: new[] { "MovieId", "PeopleId" },
                values: new object[,]
                {
                    { 3, 3 },
                    { 6, 6 },
                    { 1, 1 },
                    { 4, 5 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 2, 2 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenre",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 7, 9 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenre",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 2, 5 },
                    { 5, 5 },
                    { 7, 6 },
                    { 5, 4 },
                    { 1, 6 },
                    { 6, 7 },
                    { 4, 7 },
                    { 4, 8 },
                    { 3, 8 },
                    { 2, 9 },
                    { 5, 9 },
                    { 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "MovieProductionCompany",
                columns: new[] { "MovieId", "ProductionCompanyId" },
                values: new object[,]
                {
                    { 7, 7 },
                    { 6, 6 },
                    { 5, 5 },
                    { 1, 1 },
                    { 3, 3 },
                    { 2, 2 },
                    { 8, 8 },
                    { 4, 5 },
                    { 9, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_PeopleId",
                table: "MovieActor",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirector_PeopleId",
                table: "MovieDirector",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreId",
                table: "MovieGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieProductionCompany_ProductionCompanyId",
                table: "MovieProductionCompany",
                column: "ProductionCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Title",
                table: "Movies",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Name",
                table: "Person",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanies_Name",
                table: "ProductionCompanies",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActor");

            migrationBuilder.DropTable(
                name: "MovieDirector");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "MovieProductionCompany");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "ProductionCompanies");
        }
    }
}
