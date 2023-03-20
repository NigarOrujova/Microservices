using CodeAcademy.Catalog.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeAcademy.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : CustomBaseController {

    private readonly ITicketService _ticketService; 
    public TicketsController(ITicketService ticketService) {
        _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var response = await _ticketService.GetAllAsync();

        return CreateActionResultInstance(response);
    }
     
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id) {
        var response = await _ticketService.GetByIdAsync(id);

        return CreateActionResultInstance(response);
    }

    [HttpGet]
    [Route("/api/[controller]/GetAllByUserId/{userId}")]
    public async Task<IActionResult> GetAllByUserId(string userId) {
        var response = await _ticketService.GetAllByUserIdAsync(userId);

        return CreateActionResultInstance(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TicketCreateDto ticketCreateDto) {
        var response = await _ticketService.CreateAsync(ticketCreateDto);

        return CreateActionResultInstance(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(TicketUpdateDto ticketUpdateDto) {
        var response = await _ticketService.UpdateAsync(ticketUpdateDto);

        return CreateActionResultInstance(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        var response = await _ticketService.DeleteAsync(id);

        return CreateActionResultInstance(response);
    }
}