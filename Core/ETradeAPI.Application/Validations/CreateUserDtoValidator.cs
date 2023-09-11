using ETradeAPI.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Validations
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        // kullanıcı oluştururken alanların gerekli olması ve olmadığında hata mesajının verilmesi sağlandı.
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required").EmailAddress().WithMessage("{PropertyName} is wrong");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName}is required");
            RuleFor(x => x.ConfirmPassword).NotEqual(x => x.Password).WithMessage("{PropertyName} is not equal");
        }
    }
}
