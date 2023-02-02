using FluentValidation;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Please enter the product name")
               .NotNull().WithMessage("Please enter the product name");

            RuleFor(c => c.Description)
                .MaximumLength(250).WithMessage("Maximum lenght exceeded. Insert a short description");

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Please enter the product price.")
                .NotNull().WithMessage("Please enter the product price.")
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
       
    }
}
