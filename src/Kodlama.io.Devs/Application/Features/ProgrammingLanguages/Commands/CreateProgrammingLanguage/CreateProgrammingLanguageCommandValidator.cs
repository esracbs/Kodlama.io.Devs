using Application.Features.ProgrammingLanguages.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandValidator : AbstractValidator<CreatedProgrammingLanguageDto>
    {
        public CreateProgrammingLanguageCommandValidator()
        {
            RuleFor(f => f.Name).NotNull();
            RuleFor(f => f.Name).NotEmpty();
        }
    }
}
