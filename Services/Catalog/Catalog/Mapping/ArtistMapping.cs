namespace CodeAcademy.Catalog.Mapping;

public class ArtistMapping : Profile {

    public ArtistMapping() {
        CreateMap<Artist, ArtistDto>().ReverseMap();
        CreateMap<Artist, ArtistCreateDto>().ReverseMap();
        CreateMap<Artist, ArtistUpdateDto>().ReverseMap();
    }
}