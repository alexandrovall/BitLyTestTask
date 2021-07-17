using System;
using Alexandrovall.BitLyTestTask.Dto.RQ;
using FluentValidation;

namespace Alexandrovall.BitLyTestTask.Dto.Validators.RQ
{
    public class GetShortLinkRequestValidator : AbstractValidator<GetShortLinkRequest>
    {
        public GetShortLinkRequestValidator()
        {
            RuleFor(i => i.Link)
                .NotEmpty()
                .Must(IsValidUrl)
                    .WithMessage(request => $"Поле {nameof(request.Link)} должно быть валидной ссылкой с http или https схемой");
        }

        private static bool IsValidUrl(string link)
        {
            return Uri.TryCreate(link, UriKind.Absolute, out var uri) &&
                   (uri.Scheme == "http" || uri.Scheme == "https");
        }
    }
}