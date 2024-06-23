using Leads.SharedKernel.Mediator.Messages;
using Microsoft.AspNetCore.Mvc;

namespace leads_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(BaseHandlerResponse response)
        {
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
