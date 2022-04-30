using CasaDoCodigo.Data;
using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{


    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly AppDbContext _context;
        
        public ProdutoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IList<Produto> GetProdutos()
        {
            return _context.Set<Produto>().ToList();
        }

        public void SaveLivros(List<Livro> livros)
        {
            foreach (var livro in livros)
            {


                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {

                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }
            _context.SaveChanges();
        }
        public class Livro
        {
            public string Codigo { get; set; }
            public string Nome { get; set; }
            public decimal Preco { get; set; }
        }
    }
}
