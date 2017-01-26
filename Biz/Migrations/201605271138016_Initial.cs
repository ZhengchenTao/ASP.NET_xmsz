namespace Biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostLists", "Forums_Id", "dbo.Forums");
            DropForeignKey("dbo.PostLists", "Post_Id", "dbo.Posts");
            DropIndex("dbo.PostLists", new[] { "Forums_Id" });
            DropIndex("dbo.PostLists", new[] { "Post_Id" });
            AddColumn("dbo.Posts", "Title", c => c.String(nullable: false));
            DropTable("dbo.PostLists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PostLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Forums_Id = c.Int(nullable: false),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Posts", "Title");
            CreateIndex("dbo.PostLists", "Post_Id");
            CreateIndex("dbo.PostLists", "Forums_Id");
            AddForeignKey("dbo.PostLists", "Post_Id", "dbo.Posts", "Id");
            AddForeignKey("dbo.PostLists", "Forums_Id", "dbo.Forums", "Id", cascadeDelete: true);
        }
    }
}
