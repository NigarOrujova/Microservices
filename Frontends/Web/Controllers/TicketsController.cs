using CodeAcademy.Shared.Services;
using CodeAcademy.Web.Models.Catalogs;
using CodeAcademy.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodeAcademy.Web.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public TicketsController(ICatalogService catalogService, ISharedIdentityService sharedIdentityService)
        {
            _catalogService = catalogService;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _catalogService.GetAllTicketByUserIdAsync(_sharedIdentityService.GetUserId));
        }

        public async Task<IActionResult> Create()        
        {
            var concerts = await _catalogService.GetAllConcertAsync();

            ViewBag.concertList = new SelectList(concerts, "Id", "Artist");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketCreateInput ticketCreateInput)
        {
            var concerts = await _catalogService.GetAllConcertAsync();
            ViewBag.concertList = new SelectList(concerts, "Id", "Artist");
            if (!ModelState.IsValid)
            {
                return View();
            }
            ticketCreateInput.UserId = _sharedIdentityService.GetUserId;

            await _catalogService.CreateTicketAsync(ticketCreateInput);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var ticket = await _catalogService.GetByTicketId(id);
            var concerts = await _catalogService.GetAllConcertAsync();

            if (ticket == null)
            {
                //mesaj göster
                RedirectToAction(nameof(Index));
            }
            ViewBag.concertList = new SelectList(concerts, "Id", "Artist", ticket.Id);
            TicketUpdateInput ticketUpdateInput = new()
            {
                Id = ticket.Id,
                Name = ticket.Name,
                Description = ticket.Description,
                Price = ticket.Price,
                Feature = ticket.Feature,
                ConcertId = ticket.ConcertId,
                UserId = ticket.UserId,
                Picture = ticket.Picture
            };

            return View(ticketUpdateInput);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketUpdateInput ticketUpdateInput)
        {
            var concerts = await _catalogService.GetAllConcertAsync();
            ViewBag.concertList = new SelectList(concerts, "Id", "Artist", ticketUpdateInput.Id);
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _catalogService.UpdateTicketAsync(ticketUpdateInput);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _catalogService.DeleteTicketAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}