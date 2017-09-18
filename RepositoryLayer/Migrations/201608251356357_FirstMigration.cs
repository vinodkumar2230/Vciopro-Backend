namespace RepositoryLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        DOB = c.String(),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserDetails");
        }
    }
}
