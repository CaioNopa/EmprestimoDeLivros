using EmprestimoDeLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoDeLivros.Data
{
 
        //AppDbContext representaçao do bd
        public class AppDbContext : DbContext
        {
            //Db Set representação de uma tabela

            public DbSet<EmprestimoModel> Emprestimos { get; set; }



            // string de conexão
            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                options.UseSqlite("DataSource=app.db; Cache=Shared");
            }
        }

}
