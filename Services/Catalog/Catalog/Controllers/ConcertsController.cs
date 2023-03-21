using CodeAcademy.Catalog.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeAcademy.Catalog.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ConcertsController : CustomBaseController {
    private readonly IConcertService _concertService;

    public ConcertsController(IConcertService concertService) {
        _concertService = concertService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var concerts = await _concertService.GetAllAsync();

        return CreateActionResultInstance(concerts);
    }
     
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id) {
        var concert = await _concertService.GetByIdAsync(id);

        return CreateActionResultInstance(concert);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ConcertCreateDto concertDto) {
        var response = await _concertService.CreateAsync(concertDto);

        return CreateActionResultInstance(response);
    }
}
