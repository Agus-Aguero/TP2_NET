namespace Academia.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eliminacionCampo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.usuarios", "usuariov2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.usuarios", "usuariov2", c => c.String());
        }
    }
}
