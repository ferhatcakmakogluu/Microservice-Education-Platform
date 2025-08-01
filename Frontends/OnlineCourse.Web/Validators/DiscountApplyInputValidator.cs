using FluentValidation;
using OnlineCourse.Web.Models.Discounts;

namespace OnlineCourse.Web.Validators
{
    public class DiscountApplyInputValidator : AbstractValidator<DiscountApplyInput>
    {
        public DiscountApplyInputValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("İndirim kupon alanı boş olamaz!");
        }
    }
}
