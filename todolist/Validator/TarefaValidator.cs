using FluentValidation;
using todolist.Model;

namespace todolist.Validator
{
    public class TarefaValidator : AbstractValidator<Tarefa>
    {
        public TarefaValidator() 
        {
            RuleFor(t => t.Texto)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(1000);

            RuleFor(t => t.Urgencia)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(t => t.Status)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);
        }
    }

}
