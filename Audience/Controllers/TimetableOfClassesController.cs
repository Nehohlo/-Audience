using Audience.BLL.Interfaces;
using Audience.Models.Lecturer;
using Audience.Models.TimetableOfClasses;
using Microsoft.AspNetCore.Mvc;

namespace Audience.Controllers
{

        public class TimetableOfClassesController : ApiController
        {
            ITimetableOfClasseServices services;

            public TimetableOfClassesController(ITimetableOfClasseServices services)
            {
                this.services = services;
            }

            [HttpGet]
            public async Task<ActionResult> All()
            {
                return Ok(await new TimetableOfClassesBuilder(this.services).BuildAll());
            }
        }
}
