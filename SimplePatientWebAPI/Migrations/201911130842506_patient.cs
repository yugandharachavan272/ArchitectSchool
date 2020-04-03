namespace SimplePatientWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HospitalName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Patients", "hospitalID", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Patients", "hospitalID");
            AddForeignKey("dbo.Patients", "hospitalID", "dbo.Hospitals", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "hospitalID", "dbo.Hospitals");
            DropIndex("dbo.Patients", new[] { "hospitalID" });
            AlterColumn("dbo.Patients", "Name", c => c.String());
            DropColumn("dbo.Patients", "hospitalID");
            DropTable("dbo.Hospitals");
        }
    }
}
