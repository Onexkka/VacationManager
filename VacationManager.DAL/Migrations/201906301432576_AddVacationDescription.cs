namespace VacationManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVacationDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vacations", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vacations", "Description");
        }
    }
}
