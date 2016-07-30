﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class addCmsModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cms_Page",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    MetaDescription = table.Column<string>(nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PublishedOn = table.Column<DateTime>(nullable: true),
                    SeoTitle = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cms_Page", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cms_Page_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cms_Page_Core_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cms_Widget",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    CreateUrl = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EditUrl = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ViewComponentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cms_Widget", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cms_WidgetZone",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cms_WidgetZone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cms_WidgetInstance",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false),
                    HtmlData = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PublishEnd = table.Column<DateTime>(nullable: true),
                    PublishStart = table.Column<DateTime>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    WidgetId = table.Column<long>(nullable: false),
                    WidgetZoneId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cms_WidgetInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cms_WidgetInstance_Cms_Widget_WidgetId",
                        column: x => x.WidgetId,
                        principalTable: "Cms_Widget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cms_WidgetInstance_Cms_WidgetZone_WidgetZoneId",
                        column: x => x.WidgetZoneId,
                        principalTable: "Cms_WidgetZone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cms_Page_CreatedById",
                table: "Cms_Page",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cms_Page_UpdatedById",
                table: "Cms_Page",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cms_WidgetInstance_WidgetId",
                table: "Cms_WidgetInstance",
                column: "WidgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Cms_WidgetInstance_WidgetZoneId",
                table: "Cms_WidgetInstance",
                column: "WidgetZoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cms_Page");

            migrationBuilder.DropTable(
                name: "Cms_WidgetInstance");

            migrationBuilder.DropTable(
                name: "Cms_Widget");

            migrationBuilder.DropTable(
                name: "Cms_WidgetZone");
        }
    }
}