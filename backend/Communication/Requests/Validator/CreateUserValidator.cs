using Communication.Requests.DTO.Users;
using FluentValidation;

namespace Communication.Requests.Validator
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator() 
        { 
           RuleFor(user => user.UserName)
                .NotEmpty().WithMessage("O username não pode ser vazio")
                .MinimumLength(5).WithMessage("Nome inválido");

           RuleFor(user => user.Email)  
                .NotEmpty().WithMessage("O email não pode ser vazio")
                .EmailAddress().WithMessage("Email inválido");

           RuleFor(user => user.Password).NotEmpty()
                .MinimumLength(8).WithMessage("A senha deve ter no mínimo 8 caracteres.")
                .Matches("[A-Z]").WithMessage("A senha deve conter ao menos uma letra maiúscula.")
                .Matches("[a-z]").WithMessage("A senha deve conter ao menos uma letra minúscula.")
                .Matches("[0-9]").WithMessage("A senha deve conter ao menos um número.")
                .Matches("[^a-zA-Z0-9]").WithMessage("A senha deve conter ao menos um caractere especial.");
        }    
    }
}
