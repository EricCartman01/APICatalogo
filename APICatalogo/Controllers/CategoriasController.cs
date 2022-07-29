using APICatalogo.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;
using APICatalogo.Services;

namespace APICatalogo.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public CategoriasController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("/autor")]
        public ActionResult<string> Autor()
        {
            return _configuration["version"];
        }

        [HttpGet("welcome/{nome}")]
        public ActionResult<String> Welcome([FromServices] IMeuServico meuServico, string nome)
        {
            //return meuServico.Message(nome);

            return meuServico.TestaMessage(nome);
        }
     
        [HttpGet]
        [HttpGet("EndPoint")]
        [HttpGet("/primeiro")]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            try
            {
                //throw new DataMisalignedException();
                var categorias = _context.Categorias.ToList();
                if (!categorias.Any())
                    return NotFound("Sem categorias na base");

                return categorias;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar o DB");
            }
            
        }

        [HttpGet("Special")]
        public ActionResult<IEnumerable<Categoria>> Special()
        {
            return _context.Categorias.AsNoTracking().ToList();
        }

        [HttpGet("{id:int:min(1)}", Name ="ObterCategoria")]
        //[HttpGet("{valor:alpha:length(5)}")]
        public ActionResult<Categoria> Categoria(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
            
            if (categoria == null)
                return NotFound("Categoria não encontrada!");

            return Ok(categoria);
        }

        [HttpGet("CategoriasProdutos")]
        public ActionResult<IEnumerable<Categoria>> CategoriasProdutos()
        {
            //return _context.Categorias.Include(p => p.Produtos).ToList();
            return _context.Categorias.Include(p => p.Produtos).Where(c => c.CategoriaId <= 5).ToList();
        }

        [HttpPost]
        public ActionResult Insert(Categoria categoria)
        {
            if (categoria is null)
                return BadRequest("A Categoria veio vazia");

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId, categoria });
        }

        [HttpPut("{id}")]
        public ActionResult<Categoria> Update(int id, Categoria categoria)
        {
            if (! _context.Categorias.Any(p => p.CategoriaId == id))
                return BadRequest("Essa categoria não existe");

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
            if (categoria == null)
                return NotFound("Categoria não Encontrada!");

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }
        
    }
}
