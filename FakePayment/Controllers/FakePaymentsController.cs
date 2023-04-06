using CodeAcademy.Services.FakePayment.Models;
using CodeAcademy.Shared.Results;
using CodeAcademy.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentsController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> ReceivePaymnet(PaymentDto paymentDto)
        {
            return CreateActionResultInstance(CodeAcademy.Shared.Results.Response<NoContent>.Success(200));
        }
    }
}
