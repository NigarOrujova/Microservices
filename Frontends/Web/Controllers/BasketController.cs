using CodeAcademy.Web.Models.Baskets;
using CodeAcademy.Web.Models.Discounts;
using CodeAcademy.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademy.Web.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;

        public BasketController(ICatalogService catalogService, IBasketService basketService)
        {
            _catalogService = catalogService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _basketService.Get());
        }

        public async Task<IActionResult> AddBasketItem(string ticketId)
        {
            var ticket = await _catalogService.GetByTicketId(ticketId);

            var basketItem = new BasketItemViewModel { TicketId = ticket.Id, TicketName = ticket.Name, Price = ticket.Price, Quantity = 1 };

            await _basketService.AddBasketItem(basketItem);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveBasketItem(string ticketId)
        {
            var result = await _basketService.RemoveBasketItem(ticketId);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ApplyDiscount(DiscountApplyInput discountApplyInput)
        {
            if (!ModelState.IsValid)
            {
                TempData["discountError"] = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).First();
                return RedirectToAction(nameof(Index));
            }
            var discountStatus = await _basketService.ApplyDiscount(discountApplyInput.Code);

            TempData["discountStatus"] = discountStatus;
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CancelApplyDiscount()
        {
            await _basketService.CancelApplyDiscount();
            return RedirectToAction(nameof(Index));
        }
        //[HttpPost]
        //public async Task<IActionResult> QuantityUpdate(QtyData qtyData)
        //{
        //    var product = await _catalogService.GetByTicketId(qtyData.productId);
        //    var basketItem = new BasketItemViewModel
        //    {
        //        ProductId = product.Id,
        //        ProductName = product.Name,
        //        Price = product.Price,
        //        Quantity = qtyData.qty,
        //        Picture = product.Picture,
        //        StockPictureUrl = product.StockPictureUrl
        //    };

        //    await _basketService.AddBasketItem(basketItem);
        //    return Json(qtyData);
        //}
    }
}