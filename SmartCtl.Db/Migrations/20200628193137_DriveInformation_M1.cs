using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartCtl.Db.Migrations
{
    public partial class DriveInformation_M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriveInformation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SerialNumber = table.Column<string>(nullable: true),
                    ModelName = table.Column<string>(nullable: true),
                    ModelFamily = table.Column<string>(nullable: true),
                    FormFactor = table.Column<string>(nullable: true),
                    BlockCount = table.Column<long>(nullable: false),
                    BytesCount = table.Column<long>(nullable: false),
                    FirmwareVersion = table.Column<string>(nullable: true),
                    RPM = table.Column<int>(nullable: false),
                    ATAVersionMinor = table.Column<int>(nullable: false),
                    ATAVersionMajor = table.Column<int>(nullable: false),
                    ATAVersionName = table.Column<string>(nullable: true),
                    SATASpeed = table.Column<string>(nullable: true),
                    SmartOK = table.Column<bool>(nullable: false),
                    HasErrorRecovery = table.Column<bool>(nullable: false),
                    PowerOnHours = table.Column<int>(nullable: false),
                    PowerCycleCount = table.Column<int>(nullable: false),
                    Temperature = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveInformation", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriveInformation");
        }
    }
}
