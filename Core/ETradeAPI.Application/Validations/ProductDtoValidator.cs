using ETradeAPI.Application.DTOs;
using FluentValidation;

namespace ETradeAPI.Application.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            // ürünle ilgili alanların gerekli olması ve olmadığında hata mesajının verilmesi sağlandı.
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Stock).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            RuleFor(x => x.Price).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            RuleFor(x => x.CategoryId).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
        }
    }
}
