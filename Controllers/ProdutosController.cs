using CatalogoProdutos.API.Context;
using CatalogoProdutos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.ToList();


            if (produtos.Any())
            {
                return produtos;
            }
            else
            {
                return NotFound("Nenhum produto encontrado!");
            }
        }
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto == null)
            {
                return NotFound("Nenhum produto encontrado!");
            }

            return produto;


        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {

            if (produto is null)
            {
                return BadRequest();
            }
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {

            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(produto);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {

            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto == null)
            {
                return NotFound("Nenhum produto encontrado!");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok();

        }


    }
}