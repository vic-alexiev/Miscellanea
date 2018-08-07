using System;
using BiscuitMachine.Engine;
using BiscuitMachine.Engine.Enums;
using BiscuitMachine.Utils.Extensions;
using BiscuitMachine.Web.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BiscuitMachine.Web.Controllers
{
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private IMachine _machine;

        public DashboardController(IMachine machine)
        {
            _machine = machine;
        }

        [HttpPost("[action]")]
        public Response SwitchOn()
        {
            return Execute(_machine.Start);
        }

        [HttpPost("[action]")]
        public Response SwitchOff()
        {
            return Execute(_machine.Stop);
        }

        [HttpPost("[action]")]
        public Response Pause()
        {
            return Execute(_machine.Pause);
        }

        private Response Execute(Func<MachineState> command)
        {
            MachineState state = command();
            return CreateResponse(state);
        }

        private static Response CreateResponse(MachineState state)
        {
            return new Response
            {
                MachineState = $"[{DateTime.UtcNow.Iso8601Formatted()}] {state.ToString()}"
            };
        }
    }
}
