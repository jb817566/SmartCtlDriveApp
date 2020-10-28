using System;
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
                    Temperature = table.Column<int>(nullable: false),
                    DateLastUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveInformation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ZFSPool",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PoolName = table.Column<string>(nullable: true),
                    RaidLevel = table.Column<int>(nullable: false),
                    MountPoint = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    MemberCount = table.Column<int>(nullable: false),
                    Capacity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZFSPool", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ZFSPoolInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RaidLevel = table.Column<int>(nullable: false),
                    DriveID = table.Column<int>(nullable: false),
                    Capacity = table.Column<double>(nullable: false),
                    PoolID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZFSPoolInfo", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriveInformation");

            migrationBuilder.DropTable(
                name: "ZFSPool");

            migrationBuilder.DropTable(
                name: "ZFSPoolInfo");
        }
    }
}
