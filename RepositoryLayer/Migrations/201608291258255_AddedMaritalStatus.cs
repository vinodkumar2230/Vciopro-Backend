namespace RepositoryLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMaritalStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "MaritalStatus", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDetails", "MaritalStatus");
        }
    }
}
