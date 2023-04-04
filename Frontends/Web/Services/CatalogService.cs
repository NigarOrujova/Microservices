using CodeAcademy.Web.Services.Interfaces;
using CodeAcademy.Shared.Results;
using CodeAcademy.Web.Helpers;
using CodeAcademy.Web.Models;
using CodeAcademy.Web.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CodeAcademy.Web.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;
        private readonly IPhotoStockService _photoStockService;
        private readonly PhotoHelper _photoHelper;

        public CatalogService(HttpClient client, IPhotoStockService photoStockService, PhotoHelper photoHelper)
        {
            _client = client;
            _photoStockService = photoStockService;
            _photoHelper = photoHelper;
        }

        public async Task<bool> CreateTicketAsync(TicketCreateInput ticketCreateInput)
        {
            var resultPhotoService = await _photoStockService.UploadPhoto(ticketCreateInput.PhotoFormFile);

            if (resultPhotoService != null)
            {
                ticketCreateInput.Picture = resultPhotoService.Url;
            }

            var response = await _client.PostAsJsonAsync<TicketCreateInput>("tickets", ticketCreateInput);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTicketAsync(string ticketId)
        {
            var response = await _client.DeleteAsync($"tickets/{ticketId}");

            return response.IsSuccessStatusCode;
        }
        public async Task<List<ConcertViewModel>> GetAllConcertAsync()
        {
            var response = await _client.GetAsync("http://localhost:5014/api/Concerts");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ConcertViewModel>>>();

            return responseSuccess.Data;
        }

        public async Task<List<TicketViewModel>> GetAllTicketAsync()
        {
            //http:localhost:5000/services/catalog/tickets
            var response = await _client.GetAsync("tickets");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<TicketViewModel>>>();
            responseSuccess.Data.ForEach(x =>
            {
                x.StockPictureUrl = _photoHelper.GetPhotoStockUrl(x.Picture);
            });
            return responseSuccess.Data;
        }

        public async Task<List<TicketViewModel>> GetAllTicketByUserIdAsync(string userId)
        {
            //[controller]/GetAllByUserId/{userId}

            var response = await _client.GetAsync($"tickets/GetAllByUserId/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<TicketViewModel>>>();

            responseSuccess.Data.ForEach(x =>
            {
                x.StockPictureUrl = _photoHelper.GetPhotoStockUrl(x.Picture);
            });

            return responseSuccess.Data;
        }

        public async Task<TicketViewModel> GetByTicketId(string ticketId)
        {
            var response = await _client.GetAsync($"tickets/{ticketId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<TicketViewModel>>();

            responseSuccess.Data.StockPictureUrl = _photoHelper.GetPhotoStockUrl(responseSuccess.Data.Picture);

            return responseSuccess.Data;
        }

        public async Task<bool> UpdateTicketAsync(TicketUpdateInput ticketUpdateInput)
        {
            var resultPhotoService = await _photoStockService.UploadPhoto(ticketUpdateInput.PhotoFormFile);

            if (resultPhotoService != null)
            {
                await _photoStockService.DeletePhoto(ticketUpdateInput.Picture);
                ticketUpdateInput.Picture = resultPhotoService.Url;
            }

            var response = await _client.PutAsJsonAsync<TicketUpdateInput>("tickets", ticketUpdateInput);

            return response.IsSuccessStatusCode;
        }
    }
}