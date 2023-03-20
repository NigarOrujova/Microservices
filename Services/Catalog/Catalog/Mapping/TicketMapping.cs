namespace CodeAcademy.Catalog.Mapping;

public class TicketMapping : Profile {

    public TicketMapping() {
        CreateMap<Ticket, TicketDto>().ReverseMap();
        CreateMap<Ticket, TicketCreateDto>().ReverseMap();
        CreateMap<Ticket, TicketUpdateDto>().ReverseMap();
    }
}