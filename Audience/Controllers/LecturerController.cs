using Audience.BLL.DTO;
using Audience.BLL.Interfaces;
using Audience.BLL.Services;
using Audience.DAL.Entities;
using Audience.Infrastructure.Services;
using Audience.Models.Class;
using Audience.Models.Lecturer;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Audience.Controllers
{
    public class LecturerController : ApiController
    {
        ILecturerServices services;

        public LecturerController(ILecturerServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public async Task<ActionResult> All()
        {
            return Ok(await new LecturerBuilder(this.services).BuildAll());
        }

        [HttpPost]
        public async Task<ActionResult> Add(LecturerAddRequestModel model)
        {
            if(ModelState.IsValid)
            {
                var modelDTO = await new LecturerBuilder(this.services).BuildAdd(model);
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
