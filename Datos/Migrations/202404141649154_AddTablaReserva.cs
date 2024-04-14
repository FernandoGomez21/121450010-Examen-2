namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablaReserva : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reserva",
                c => new
                    {
                        ReservaId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        TeatroId = c.Int(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReservaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .ForeignKey("dbo.Teatros", t => t.TeatroId)
                .Index(t => t.ClienteId)
                .Index(t => t.TeatroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserva", "TeatroId", "dbo.Teatros");
            DropForeignKey("dbo.Reserva", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Reserva", new[] { "TeatroId" });
            DropIndex("dbo.Reserva", new[] { "ClienteId" });
            DropTable("dbo.Reserva");
        }
    }
}
