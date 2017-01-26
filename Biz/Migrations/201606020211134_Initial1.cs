namespace Biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replies", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Replies", "Users_Id", "dbo.Users");
            DropIndex("dbo.Replies", new[] { "Post_Id" });
            DropIndex("dbo.Replies", new[] { "Users_Id" });
            AlterColumn("dbo.Replies", "Users_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Replies", "Users_Id");
            AddForeignKey("dbo.Replies", "Users_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "Users_Id", "dbo.Users");
            DropIndex("dbo.Replies", new[] { "Users_Id" });
            AlterColumn("dbo.Replies", "Users_Id", c => c.Int());
            CreateIndex("dbo.Replies", "Users_Id");
            CreateIndex("dbo.Replies", "Post_Id");
            AddForeignKey("dbo.Replies", "Users_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Replies", "Post_Id", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
