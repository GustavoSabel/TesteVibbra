using Microsoft.AspNetCore.Mvc;
using VibbraTest.API.ActionResult;

namespace VibbraTest.API.Controllers
{
    public abstract class ControllerBaseVibbra : ControllerBase
    {
        protected SimpleCreatedResult Created(object obj)
        {
            return new SimpleCreatedResult(obj);
        }
    }
}
