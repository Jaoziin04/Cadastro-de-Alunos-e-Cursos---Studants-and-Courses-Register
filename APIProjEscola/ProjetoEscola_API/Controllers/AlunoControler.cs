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
    public class AlunoController : ControllerBase
    {
        private EscolaContext _context;
        public AlunoController(EscolaContext context)
        {
            // construtor
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<Aluno>> GetAll() 
        {
            return _context.Aluno.ToList();
        }

        [HttpGet("{AlunoId}")]

        public ActionResult<List<Aluno>> Get(int AlunoId)
        {
            try
            {
                var result = _context.Aluno.Find(AlunoId);
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
        public async Task<ActionResult> post(Aluno model)
        {
            try
            {   
                             
                _context.Aluno.Add(model);
                
                if(await _context.SaveChangesAsync() == 1)
                {
                    //return OK();
                    Console.WriteLine("oi");
                    return Created($"/api/aluno/{model.ra}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso do banco de dados");
            }
            //retorna a BadRequest se não conseguiu incluir
            return BadRequest();
        }

        [HttpPut("{AlunoID}")]
        public async Task<ActionResult> put(int AlunoID, Aluno dadoAlunoAlt)
        {
            try
            {
                //verifica se existe aluno a ser alterado
                var result = await _context.Aluno.FindAsync(AlunoID);
                if(AlunoID != result?.id)
                    return BadRequest();
                    
                result.ra = dadoAlunoAlt.ra;
                result.nome = dadoAlunoAlt.nome;
                result.codCurso = dadoAlunoAlt.codCurso;
                await _context.SaveChangesAsync();
                return Created($"api/aluno/{dadoAlunoAlt.ra}", dadoAlunoAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados");
            }
        }

        [HttpDelete("{AlunoID}")]
        public async Task<ActionResult> delete(int AlunoId)
        {
            try
            {
                //verifica se existe aluno a ser excluido
                var aluno = await _context.Aluno.FindAsync(AlunoId);
                if(aluno == null)
                    //Método do EF
                    return NotFound();
                _context.Remove(aluno);
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