using FluentValidation;
using OnlineCourse.Web.Models.Catalog;

namespace OnlineCourse.Web.Validators
{
    public class CourseUpdateInputValidator : AbstractValidator<CourseUpdateInput>
    {
        public CourseUpdateInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kurs ismi boş olamaz!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz!");
            RuleFor(x => x.Feature.Duration).InclusiveBetween(1, int.MaxValue).WithMessage("Süre alanı boş olamaz!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat alanı boş olamaz!").ScalePrecision(2, 6).WithMessage("Hatalı Para Birimi!");
        }
    }
}
