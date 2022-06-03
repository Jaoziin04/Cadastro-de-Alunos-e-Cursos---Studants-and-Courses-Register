using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscola_API.Data;
using ProjetoEscola_API.Models;
namespace ProjetoEscola_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private EscolaContext _context;
        public CursoController(EscolaContext context)
        {
            // construtor
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<Curso>> GetAll() 
        {
            return _context.Curso.ToList();
        }

        [HttpGet("{CursoId}")]

        public ActionResult<List<Curso>> Get(int CursoId)
        {
            try
            {
                var result = _context.Curso.Find(CursoId);
                if(result == null)
                    return NotFound();
                return Ok(result);  
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados");
            }
        }
        [HttpPost]
        public async Task<ActionResult> post(Curso model)
        {
            try
            {   
                             
                _context.Curso.Add(model);
                
                if(await _context.SaveChangesAsync() == 1)
                {
                    //return OK();
                    Console.WriteLine("oi");
                    return Created($"/api/curso/{model.codCurso}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso do banco de dados");
            }
            //retorna a BadRequest se não conseguiu incluir
            return BadRequest();
        }

        [HttpPut("{CursoID}")]
        public async Task<ActionResult> put(int CursoID, Curso dadoCursoAlt)
        {
            try
            {
                //verifica se existe Curso a ser alterado
                var result = await _context.Curso.FindAsync(CursoID);
                if(CursoID != result?.id)
                    return BadRequest();
                    
                result.nome = dadoCursoAlt.nome;
                result.codCurso = dadoCursoAlt.codCurso;
                await _context.SaveChangesAsync();
                return Created($"api/Curso/{dadoCursoAlt.codCurso}", dadoCursoAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados");
            }
        }

        [HttpDelete("{CursoID}")]
        public async Task<ActionResult> delete(int CursoId)
        {
            try
            {
                //verifica se existe Curso a ser excluido
                var Curso = await _context.Curso.FindAsync(CursoId);
                if(Curso == null)
                    //Método do EF
                    return NotFound();
                _context.Remove(Curso);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados");
            }
        }
    }
}