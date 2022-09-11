
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetListTechnology;
using Application.Features.Technologies.Queries.GetListTechnologyByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand request)
        {

            CreatedTechnologyDto result = await Mediator.Send(request);
            return Created("Created successfully.", result);
        }
        [HttpGet]

        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery  getListModelQuery = new GetListTechnologyQuery { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(getListModelQuery);
            return Ok(result);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListTechnologyByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListTechnologyByDynamicQuery getListByDynamicModelQuery = new GetListTechnologyByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            TechnologyListModel result = await Mediator.Send(getListByDynamicModelQuery);
            return Ok(result);
        }
        [HttpPost("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            await Mediator.Send(deleteTechnologyCommand);
            return Ok();
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdatedTechnologyDto result = await Mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }
    }
}
