namespace CodeAcademy.Catalog.Mapping;

public class ConcertMapping : Profile {

    public ConcertMapping() {
        CreateMap<Concert, ConcertDto>().ReverseMap();
    }
}