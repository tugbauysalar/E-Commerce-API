using ETradeAPI.Application.DTOs;
using FluentValidation;


namespace ETradeAPI.Application.Validations
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        //Kategori için name alanının zorunlu olması sağlandı.Boş veya null olduğunda gerekli hata mesajı verildi.
        public CategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required");
        }
        
    }
}
