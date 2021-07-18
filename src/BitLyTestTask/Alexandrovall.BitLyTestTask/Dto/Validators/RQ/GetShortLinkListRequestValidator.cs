using Alexandrovall.BitLyTestTask.Dto.RQ;
using FluentValidation;

namespace Alexandrovall.BitLyTestTask.Dto.Validators.RQ
{
    public class GetShortLinkListRequestValidator : AbstractValidator<GetShortLinkListRequest>
    {
        public GetShortLinkListRequestValidator()
        {
            RuleFor(i => i.Offset)
                .GreaterThanOrEqualTo(0)
                    .WithMessage(request =>  $"Поле {nameof(request.Offset)} должно быть больше или равно 0");
            RuleFor(i => i.Limit)
                .GreaterThan(0)
                    .WithMessage(request =>  $"Поле {nameof(request.Limit)} должно быть больше 0");
        }
    }
}