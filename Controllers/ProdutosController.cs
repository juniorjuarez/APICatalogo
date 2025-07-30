using CatalogoProdutos.API.Context;
using CatalogoProdutos.API.Models;
using Microsoft.AspNetCore.Mvc;

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

                return NotFound("Nenhum produto encontrado.");
            }
        }


    }
}