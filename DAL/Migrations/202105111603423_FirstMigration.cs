namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Birth = c.DateTime(nullable: false),
                        First = c.DateTime(),
                        Second = c.DateTime(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        PointId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        VaccineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Points", t => t.PointId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Vaccines", t => t.VaccineId, cascadeDelete: true)
                .Index(t => t.PointId)
                .Index(t => t.PersonId)
                .Index(t => t.DoctorId)
                .Index(t => t.VaccineId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        HospitalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.HospitalId, cascadeDelete: true)
                .Index(t => t.HospitalId);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Points",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HospitalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.HospitalId, cascadeDelete: false)
                .Index(t => t.HospitalId);
            
            CreateTable(
                "dbo.Vaccines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "VaccineId", "dbo.Vaccines");
            DropForeignKey("dbo.Vaccines", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Producers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Records", "PersonId", "dbo.People");
            DropForeignKey("dbo.Records", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Records", "PointId", "dbo.Points");
            DropForeignKey("dbo.Points", "HospitalId", "dbo.Hospitals");
            DropForeignKey("dbo.Doctors", "HospitalId", "dbo.Hospitals");
            DropForeignKey("dbo.Hospitals", "CityId", "dbo.Cities");
            DropForeignKey("dbo.People", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Producers", new[] { "CountryId" });
            DropIndex("dbo.Vaccines", new[] { "CountryId" });
            DropIndex("dbo.Points", new[] { "HospitalId" });
            DropIndex("dbo.Hospitals", new[] { "CityId" });
            DropIndex("dbo.Doctors", new[] { "HospitalId" });
            DropIndex("dbo.Records", new[] { "VaccineId" });
            DropIndex("dbo.Records", new[] { "DoctorId" });
            DropIndex("dbo.Records", new[] { "PersonId" });
            DropIndex("dbo.Records", new[] { "PointId" });
            DropIndex("dbo.People", new[] { "CategoryId" });
            DropTable("dbo.Producers");
            DropTable("dbo.Countries");
            DropTable("dbo.Vaccines");
            DropTable("dbo.Points");
            DropTable("dbo.Cities");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Doctors");
            DropTable("dbo.Records");
            DropTable("dbo.People");
            DropTable("dbo.Categories");
        }
    }
}
