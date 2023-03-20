using CodeAcademy.Shared.Results;

namespace CodeAcademy.Catalog.Services;

public interface ITicketService {
    Task<Response<List<TicketDto>>> GetAllAsync();

    Task<Response<TicketDto>> GetByIdAsync(string id);

    Task<Response<List<TicketDto>>> GetAllByUserIdAsync(string userId);

    Task<Response<TicketDto>> CreateAsync(TicketCreateDto ticketCreateDto);

    Task<Response<NoContent>> UpdateAsync(TicketUpdateDto ticketUpdateDto);

    Task<Response<NoContent>> DeleteAsync(string id);
}
