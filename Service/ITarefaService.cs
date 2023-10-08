
using todolist.Model;

namespace todolist.Service
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> GetAll();
        Task<Tarefa?> GetById(long id);
        Task<IEnumerable<Tarefa>> GetTexto(string texto);
        Task<IEnumerable<Tarefa>> GetUrgencia(string urgencia);
        Task<IEnumerable<Tarefa>> GetStatus(string status);
        Task<Tarefa?> Create(Tarefa tarefa);
        Task<Tarefa?> Update(Tarefa tarefa);
        Task Delete(Tarefa tarefa);

    }
}
