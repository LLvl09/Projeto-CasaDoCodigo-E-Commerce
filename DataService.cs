using CasaDoCodigo.Data;
using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using static CasaDoCodigo.Repositories.ProdutoRepository;

namespace CasaDoCodigo
{
    class DataService : IDataService
    {
        private readonly AppDbContext _context;
        private readonly IProdutoRepository _produtoRepository;
        public DataService(AppDbContext context, IProdutoRepository produtoRepository)
        {
            _context = context;
            _produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            _context.Database.Migrate();

            List<Livro> livros = GetLivros();
            _produtoRepository.SaveLivros(livros);
            _context.SaveChanges();
        }

       

        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
       
    }
}