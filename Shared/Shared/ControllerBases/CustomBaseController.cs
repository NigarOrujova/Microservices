using CodeAcademy.Shared.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodeAcademy.Shared.ControllerBases
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}