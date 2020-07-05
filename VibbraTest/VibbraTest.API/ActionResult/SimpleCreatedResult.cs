using Microsoft.AspNetCore.Mvc;

namespace VibbraTest.API.ActionResult
{
    public class SimpleCreatedResult : ObjectResult
    {
        public SimpleCreatedResult(object value) : base(value)
        {
            StatusCode = 201;
        }
    }
}
