using FluentValidation;
using todolist.Model;

namespace todolist.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(t => t.Nome)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);
        }
    }
}
