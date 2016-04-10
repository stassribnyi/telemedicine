namespace Telemedicine.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Analyzes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Temp = c.Double(nullable: false),
                        HartRate = c.Int(nullable: false),
                        Pressure_Sys = c.Int(nullable: false),
                        Pressure_Dia = c.Int(nullable: false),
                        LastMeasurement = c.DateTime(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        LastModified = c.DateTime(nullable: false),
                        Patient_Id = c.Int(),
                        Doctor_Id = c.Int(),
                        Analyze_Id = c.Int(),
                        ECG_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id)
                .ForeignKey("dbo.Analyzes", t => t.Analyze_Id)
                .ForeignKey("dbo.ECGs", t => t.ECG_Id)
                .Index(t => t.Patient_Id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Analyze_Id)
                .Index(t => t.ECG_Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(maxLength: 16),
                        Password = c.String(maxLength: 16),
                        FirstName = c.String(maxLength: 16),
                        LastName = c.String(maxLength: 16),
                        Patronimic = c.String(maxLength: 16),
                        Email = c.String(),
                        Phone = c.String(),
                        MedicalSpecialization = c.String(),
                        IsArchive = c.Boolean(nullable: false),
                        Hospital_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.Hospital_Id)
                .Index(t => t.Hospital_Id);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HospitalName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        INN = c.Long(nullable: false),
                        FirstName = c.String(maxLength: 16),
                        LastName = c.String(maxLength: 16),
                        Patronimic = c.String(maxLength: 16),
                        Gender = c.Int(nullable: false),
                        Birth = c.DateTime(nullable: false, storeType: "date"),
                        Phone = c.String(),
                        DeviceId = c.Guid(nullable: false),
                        IsArchive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ECGs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LastMeasurement = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Analyzes", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ECGDatas",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RR = c.Int(nullable: false),
                        Time = c.Int(nullable: false),
                        ECG_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ECGs", t => t.ECG_Id, cascadeDelete: true)
                .Index(t => t.ECG_Id);
            
            CreateTable(
                "dbo.PatientDoctors",
                c => new
                    {
                        Patient_Id = c.Int(nullable: false),
                        Doctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Patient_Id, t.Doctor_Id })
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id)
                .Index(t => t.Doctor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Analyzes", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.ECGDatas", "ECG_Id", "dbo.ECGs");
            DropForeignKey("dbo.Comments", "ECG_Id", "dbo.ECGs");
            DropForeignKey("dbo.ECGs", "Id", "dbo.Analyzes");
            DropForeignKey("dbo.Comments", "Analyze_Id", "dbo.Analyzes");
            DropForeignKey("dbo.Comments", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.PatientDoctors", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.PatientDoctors", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Comments", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Doctors", "Hospital_Id", "dbo.Hospitals");
            DropIndex("dbo.PatientDoctors", new[] { "Doctor_Id" });
            DropIndex("dbo.PatientDoctors", new[] { "Patient_Id" });
            DropIndex("dbo.ECGDatas", new[] { "ECG_Id" });
            DropIndex("dbo.ECGs", new[] { "Id" });
            DropIndex("dbo.Doctors", new[] { "Hospital_Id" });
            DropIndex("dbo.Comments", new[] { "ECG_Id" });
            DropIndex("dbo.Comments", new[] { "Analyze_Id" });
            DropIndex("dbo.Comments", new[] { "Doctor_Id" });
            DropIndex("dbo.Comments", new[] { "Patient_Id" });
            DropIndex("dbo.Analyzes", new[] { "Patient_Id" });
            DropTable("dbo.PatientDoctors");
            DropTable("dbo.ECGDatas");
            DropTable("dbo.ECGs");
            DropTable("dbo.Patients");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Doctors");
            DropTable("dbo.Comments");
            DropTable("dbo.Analyzes");
        }
    }
}
