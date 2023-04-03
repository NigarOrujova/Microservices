using CodeAcademy.Web.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademy.Web.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<List<TicketViewModel>> GetAllTicketAsync();

        Task<List<CategoryViewModel>> GetAllCategoryAsync();

        Task<List<TicketViewModel>> GetAllTicketByUserIdAsync(string userId);

        Task<TicketViewModel> GetByTicketId(string ticketId);

        Task<bool> CreateTicketAsync(TicketCreateInput ticketCreateInput);

        Task<bool> UpdateTicketAsync(TicketUpdateInput ticketUpdateInput);

        Task<bool> DeleteTicketAsync(string ticketId);
    }
}