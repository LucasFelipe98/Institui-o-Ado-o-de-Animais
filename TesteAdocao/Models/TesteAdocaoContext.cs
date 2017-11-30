using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TesteAdocao.Models
{
    public class TesteAdocaoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TesteAdocaoContext() : base("name=TesteAdocaoContext")
        {
            Database.SetInitializer<TesteAdocaoContext>(new DropCreateDatabaseIfModelChanges<TesteAdocaoContext>());
        }

        public System.Data.Entity.DbSet<TesteAdocao.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<TesteAdocao.Models.Animal> Animals { get; set; }

        public System.Data.Entity.DbSet<TesteAdocao.Models.Instituicao> Instituicaos { get; set; }
    }
}
