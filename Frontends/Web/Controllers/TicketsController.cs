using CodeAcademy.Shared.Services;
using CodeAcademy.Web.Models.Catalogs;
using CodeAcademy.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var categories = await _catalogService.GetAllCategoryAsync();

            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketCreateInput ticketCreateInput)
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");
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
            var categories = await _catalogService.GetAllCategoryAsync();

            if (ticket == null)
            {
                //mesaj göster
                RedirectToAction(nameof(Index));
            }
            ViewBag.categoryList = new SelectList(categories, "Id", "Name", ticket.Id);
            TicketUpdateInput ticketUpdateInput = new()
            {
                Id = ticket.Id,
                Name = ticket.Name,
                Description = ticket.Description,
                Price = ticket.Price,
                Feature = ticket.Feature,
                CategoryId = ticket.CategoryId,
                UserId = ticket.UserId,
                Picture = ticket.Picture
            };

            return View(ticketUpdateInput);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketUpdateInput ticketUpdateInput)
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name", ticketUpdateInput.Id);
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