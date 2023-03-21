namespace CodeAcademy.Catalog.Mapping;

public class ConcertMapping : Profile {

    public ConcertMapping() {
        CreateMap<Concert, ConcertDto>().ReverseMap();
        CreateMap<Concert, ConcertCreateDto>().ReverseMap();
        CreateMap<Concert, ConcertUpdateDto>().ReverseMap();
    }
}