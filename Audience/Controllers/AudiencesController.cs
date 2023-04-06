using Audience.BLL.DTO;
using Audience.BLL.Interfaces;
using Audience.DAL.Entities;
using Audience.Models.Audiences;
using Audience.Models.Lecturer;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Audience.Controllers
{
    public class AudiencesController : ApiController
    {
        IAudiencesServices services;

        public AudiencesController(IAudiencesServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public async Task<ActionResult> All()
        {
            return Ok(await new AudiencesBuilder(this.services).BuildAll());
        }

        [HttpPost]
        public async Task<ActionResult> Add(AudiencesAddRequestModel model)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(model.Number))
            {
                var modelDTO = await new AudiencesBuilder(this.services).BuildAdd(model);
                var result = await services.Create(modelDTO);
                if (result.Failure)
                {
                    return BadRequest(result.Message);
                }

                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await services.Delete(id);
                if (result.Failure)
                {
                    return BadRequest(result.Message);
                }

                return Ok(result);
            }
            return BadRequest();
        }
    }
}
