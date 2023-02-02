using FluentValidation;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Validators
{
    public class UserValidator :AbstractValidator<User>
    {
        public UserValidator () 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Please enter the name")
                .NotNull().WithMessage("Please enter the name");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Please enter the email.")
                .NotNull().WithMessage("Please enter the email.");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Please enter the password.")
                .NotNull().WithMessage("Please enter the password.");
        }
    }
}
