using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators{
    public class UserValidator : AbstractValidator<User>{
          public UserValidator()
          {
                RuleFor(user => user)
                .NotEmpty()
                .WithMessage("The entity cannot be empty.")

                .NotNull()
                .WithMessage("The entity cannot be null.");

                RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty.")

                .NotNull()
                .WithMessage("Name cannot be null.")
        
                .MinimumLength(3)
                .WithMessage("Name must have at least 3 characters.")

                .MaximumLength(80)
                .WithMessage("Name must have at most 80 characters.");

                RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty")

                .NotNull()
                .WithMessage("Password cannot be null")

                .MinimumLength(8)
                .WithMessage("Password must have at least 8 characters")

                .MaximumLength(30)
                .WithMessage("Password must have at most 30 characters");
      
                RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("E-mail cannot be empty")

                .NotNull()
                .WithMessage("E-mail cannot be null")

                .MinimumLength(11)
                .WithMessage("E-mail must have at least 11 characters")

                .MaximumLength(40)
                .WithMessage("E-mail must have at most 40 characters")
        
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("E-mail it's not valid");
          }
    }
}