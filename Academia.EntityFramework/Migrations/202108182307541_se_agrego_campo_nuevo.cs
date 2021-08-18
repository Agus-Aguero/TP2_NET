namespace Academia.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class se_agrego_campo_nuevo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.usuarios", "usuariov2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.usuarios", "usuariov2");
        }
    }
}
