namespace Telemedicine.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changestringlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "Password", c => c.String(maxLength: 256));
            AlterColumn("dbo.Doctors", "Email", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "Email", c => c.String());
            AlterColumn("dbo.Doctors", "Password", c => c.String(maxLength: 16));
        }
    }
}
