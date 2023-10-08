using Microsoft.EntityFrameworkCore;
using todolist.Data;
using todolist.Model;

namespace todolist.Service.Implements
{
    public class TarefaService : ITarefaService
    {
        private readonly AppDbContext _context;

        public TarefaService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Tarefa>> GetAll()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task <IEnumerable<Tarefa>> GetById()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tarefa>> GetStatus(string status)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tarefa>> GetTexto(string texto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tarefa>> GetUrgencia(string urgencia)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tarefa>> Create(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tarefa>> Update(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tarefa>> Delete(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }
    }
}
