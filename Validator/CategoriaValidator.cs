using FluentValidation;
using todolist.Model;

namespace todolist.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(t => t.Titulo)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);
        }
    }
}
