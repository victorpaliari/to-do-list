using FluentValidation;

using Microsoft.AspNetCore.Mvc;
using todolist.Model;
using todolist.Service;

namespace todolist.Controller
{
    [Route("~/tarefas")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        private readonly IValidator<Tarefa> _tarefaValidator;

        public TarefaController (
            
            ITarefaService tarefaService, 
            IValidator<Tarefa> tarefaValidator)
        {
            _tarefaService = tarefaService;
            _tarefaValidator = tarefaValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _tarefaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _tarefaService.GetById(id);

            if (Resposta is null) 
            { 
                return NotFound();
            }
            return Ok(Resposta);
        }

        [HttpGet("texto/{texto}")]
        public async Task<ActionResult> GetTexto(string texto)
        {
            return Ok(await _tarefaService.GetTexto(texto));
        }

        [HttpGet("urgencia/{urgencia}")]
        public async Task<ActionResult> GetUrgencia(string urgencia)
        {
            return Ok(await _tarefaService.GetUrgencia(urgencia));
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult> GetStatus(string status)
        {
            return Ok(await _tarefaService.GetStatus(status));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Tarefa tarefa)
        {
            var validarTarefa = await _tarefaValidator.ValidateAsync(tarefa);

            if (!validarTarefa.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarTarefa);

            await _tarefaService.Create(tarefa);

            return CreatedAtAction(nameof(GetById), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Tarefa tarefa)
        {
            if (tarefa.Id == 0)
                return BadRequest("Id da Tarefa é inválido.");

            var validarTarefa = await _tarefaValidator.ValidateAsync(tarefa);

            if (!validarTarefa.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarTarefa);

            var Resposta = await _tarefaService.Update(tarefa);

            if (Resposta is null)
                return NotFound("Tarefa não encontrada");

            return Ok(Resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var buscaTarefa = await _tarefaService.GetById(id);

            if (buscaTarefa is null)
                return NotFound("Tarefa não encontrada.");

            await _tarefaService.Delete(buscaTarefa);

            return Ok("Tarefa apagada com sucesso.");
        }
    }
}
