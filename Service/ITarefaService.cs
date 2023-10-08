
using todolist.Model;

namespace todolist.Service
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> GetAll();
        Task<IEnumerable<Tarefa>> GetById();
        Task<IEnumerable<Tarefa>> GetTexto(string texto);
        Task<IEnumerable<Tarefa>> GetUrgencia(string urgencia);
        Task<IEnumerable<Tarefa>> GetStatus(string status);
        Task<IEnumerable<Tarefa>> Create(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> Update(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> Delete(Tarefa tarefa);

    }
}
