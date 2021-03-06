﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetcoreidentityserver.Migrations
{
    public partial class InitialIdentityServerOperationalContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consents",
                columns: table => new
                {
                    SubjectId = table.Column<string>(maxLength: 200, nullable: false),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    Scopes = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consents", x => new { x.SubjectId, x.ClientId });
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    TokenType = table.Column<short>(nullable: false),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    Expiry = table.Column<DateTime>(nullable: false),
                    JsonCode = table.Column<string>(nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => new { x.Key, x.TokenType });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consents");

            migrationBuilder.DropTable(
                name: "Tokens");
        }
    }
}
