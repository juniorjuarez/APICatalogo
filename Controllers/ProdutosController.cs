using CatalogoProdutos.API.Context;
using CatalogoProdutos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

            var produtos = _context.Produtos.AsNoTracking().ToList();



            try
            {
                if (produtos.Any())
                {
                    return produtos;
                }
                else
                {
                    return NotFound("Nenhum produto encontrado!");
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao realizar a requisição");
            }
        }
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

                if (produto == null)
                {
                    return NotFound("Nenhum produto encontrado!");
                }

                return produto;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao realizar a requisição");
            }

        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {

            try
            {
                if (produto is null)
                {
                    return BadRequest();
                }
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao realizar a requisição");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {

            try
            {
                if (id != produto.ProdutoId)
                {
                    return BadRequest();
                }

                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(produto);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao realizar a requisição");
            }
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {

            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            try
            {
                if (produto == null)
                {
                    return NotFound("Nenhum produto encontrado!");
                }

                _context.Produtos.Remove(produto);
                _context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao realizar a requisição");
            }

        }


    }
}