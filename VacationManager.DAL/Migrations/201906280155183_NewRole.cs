using System.Data;

namespace VacationManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Roles (Id, Name) VALUES ('AAAABBBB-CCCC-DDDD-EEEE-FFFFFFFFFFFF', 'Padawan')");
        }
        
        public override void Down()
        {
        }
    }
}
