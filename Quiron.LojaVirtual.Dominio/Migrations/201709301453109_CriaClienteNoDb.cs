namespace Quiron.LojaVirtual.Dominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriaClienteNoDb : DbMigration
    {
        public override void Up()
        {            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SubGrupo",
                c => new
                    {
                        SubGrupoId = c.Int(nullable: false, identity: true),
                        GrupoCodigo = c.String(),
                        SubGrupoCodigo = c.String(),
                        SubGrupoDescricao = c.String(),
                    })
                .PrimaryKey(t => t.SubGrupoId);
            
            CreateTable(
                "dbo.Tamanho",
                c => new
                    {
                        TamanhoId = c.Int(nullable: false, identity: true),
                        TamanhoCodigo = c.String(),
                        TamanhoDescricaoResumida = c.String(),
                        TamanhoDescricao = c.String(),
                    })
                .PrimaryKey(t => t.TamanhoId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentoCliente", t => t.Id)
                .ForeignKey("dbo.EnderecoCliente", t => t.Id)
                .ForeignKey("dbo.TelefoneCliente", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DocumentoCliente",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Tipo = c.Int(nullable: false),
                        Valor = c.Long(nullable: false),
                        DtNasc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EnderecoCliente",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Pais = c.String(),
                        Estado = c.String(),
                        Cidade = c.String(),
                        Cep = c.String(),
                        Bairro = c.String(),
                        Logradouro = c.String(),
                        Rua = c.String(),
                        Numero = c.String(),
                        Complemento = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TelefoneCliente",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CodigoArea = c.String(),
                        Numero = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.TelefoneCliente");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.EnderecoCliente");
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.DocumentoCliente");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.TelefoneCliente");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.EnderecoCliente");
            DropTable("dbo.DocumentoCliente");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tamanho");
            DropTable("dbo.SubGrupo");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.QuironProduto");
            DropTable("dbo.ProdutoVitrine");
            DropTable("dbo.Produtos");
            DropTable("dbo.ProdutoModelo");
            DropTable("dbo.Modalidade");
            DropTable("dbo.MarcaVitrine");
            DropTable("dbo.Marca");
            DropTable("dbo.Grupo");
            DropTable("dbo.Genero");
            DropTable("dbo.FaixaEtaria");
            DropTable("dbo.Estoque");
            DropTable("dbo.Cor");
            DropTable("dbo.ClubesNacionais");
            DropTable("dbo.ClubesInternacionais");
            DropTable("dbo.Categoria");
            DropTable("dbo.Administradores");
        }
    }
}
