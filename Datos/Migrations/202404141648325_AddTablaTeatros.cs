namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablaTeatros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teatros",
                c => new
                    {
                        TeatroId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 75),
                        Capacidad = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TeatroId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teatros");
        }
    }
}
