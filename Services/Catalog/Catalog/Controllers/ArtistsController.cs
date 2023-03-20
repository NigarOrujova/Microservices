using CodeAcademy.Catalog.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeAcademy.Catalog.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ArtistsController : CustomBaseController {
    private readonly IArtistService _artistService;

    public ArtistsController(IArtistService artistService) {
        _artistService = artistService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var artists = await _artistService.GetAllAsync();

        return CreateActionResultInstance(artists);
    }
     
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id) {
        var artist = await _artistService.GetByIdAsync(id);

        return CreateActionResultInstance(artist);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ArtistCreateDto artistDto) {
        var response = await _artistService.CreateAsync(artistDto);

        return CreateActionResultInstance(response);
    }
}
