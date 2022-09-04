using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController:BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createBrandCommand)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createBrandCommand);
            return Created("", result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(
        [FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            var result = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            var result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Ok(result);
        }
    }
}
