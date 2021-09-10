using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessLogic.Data.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asociacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asociacion_Id = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asociacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DivisionCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionCategoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DivisionTipoAsociado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionTipoAsociado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EncargadoTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncargadoTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZonaGrupoParticipacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Glosa = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonaGrupoParticipacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comunidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comunidad_Id = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AsociacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comunidad_Asociacion_AsociacionId",
                        column: x => x.AsociacionId,
                        principalTable: "Asociacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Encargado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncargadoTipoId = table.Column<int>(type: "int", nullable: false),
                    Rut = table.Column<int>(type: "int", nullable: false),
                    Dv = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encargado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encargado_EncargadoTipo_EncargadoTipoId",
                        column: x => x.EncargadoTipoId,
                        principalTable: "EncargadoTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provincia_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZonaParticipacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZonaGrupoParticipacionId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PorcVenta = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    PorcGtoExplotacion = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    PorcUnico = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonaParticipacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZonaParticipacion_ZonaGrupoParticipacion_ZonaGrupoParticipacionId",
                        column: x => x.ZonaGrupoParticipacionId,
                        principalTable: "ZonaGrupoParticipacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comuna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comuna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comuna_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZonaParticipacionTramo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZonaParticipacionId = table.Column<int>(type: "int", nullable: false),
                    OrdenTramo = table.Column<int>(type: "int", nullable: false),
                    FinTramo = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    participacion = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonaParticipacionTramo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZonaParticipacionTramo_ZonaParticipacion_ZonaParticipacionId",
                        column: x => x.ZonaParticipacionId,
                        principalTable: "ZonaParticipacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Division_Id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ComunidadId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombre_BI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZonaPArticipacionId = table.Column<int>(type: "int", nullable: false),
                    DivisionCategoriaId = table.Column<int>(type: "int", nullable: false),
                    DivisionTipoAsociadoId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComunaId = table.Column<int>(type: "int", nullable: false),
                    EncargadoId = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Division_Comuna_ComunaId",
                        column: x => x.ComunaId,
                        principalTable: "Comuna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Division_Comunidad_ComunidadId",
                        column: x => x.ComunidadId,
                        principalTable: "Comunidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Division_DivisionCategoria_DivisionCategoriaId",
                        column: x => x.DivisionCategoriaId,
                        principalTable: "DivisionCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Division_DivisionTipoAsociado_DivisionTipoAsociadoId",
                        column: x => x.DivisionTipoAsociadoId,
                        principalTable: "DivisionTipoAsociado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Division_Encargado_EncargadoId",
                        column: x => x.EncargadoId,
                        principalTable: "Encargado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Division_ZonaParticipacion_ZonaPArticipacionId",
                        column: x => x.ZonaPArticipacionId,
                        principalTable: "ZonaParticipacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comuna_ProvinciaId",
                table: "Comuna",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comunidad_AsociacionId",
                table: "Comunidad",
                column: "AsociacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_ComunaId",
                table: "Division",
                column: "ComunaId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_ComunidadId",
                table: "Division",
                column: "ComunidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_DivisionCategoriaId",
                table: "Division",
                column: "DivisionCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_DivisionTipoAsociadoId",
                table: "Division",
                column: "DivisionTipoAsociadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_EncargadoId",
                table: "Division",
                column: "EncargadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_ZonaPArticipacionId",
                table: "Division",
                column: "ZonaPArticipacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Encargado_EncargadoTipoId",
                table: "Encargado",
                column: "EncargadoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Provincia_RegionId",
                table: "Provincia",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaParticipacion_ZonaGrupoParticipacionId",
                table: "ZonaParticipacion",
                column: "ZonaGrupoParticipacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaParticipacionTramo_ZonaParticipacionId",
                table: "ZonaParticipacionTramo",
                column: "ZonaParticipacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "Meet");

            migrationBuilder.DropTable(
                name: "ZonaParticipacionTramo");

            migrationBuilder.DropTable(
                name: "Comuna");

            migrationBuilder.DropTable(
                name: "Comunidad");

            migrationBuilder.DropTable(
                name: "DivisionCategoria");

            migrationBuilder.DropTable(
                name: "DivisionTipoAsociado");

            migrationBuilder.DropTable(
                name: "Encargado");

            migrationBuilder.DropTable(
                name: "ZonaParticipacion");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "Asociacion");

            migrationBuilder.DropTable(
                name: "EncargadoTipo");

            migrationBuilder.DropTable(
                name: "ZonaGrupoParticipacion");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
