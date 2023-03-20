namespace CodeAcademy.Catalog.Services; 
public interface IArtistService {

    Task<Response<List<ArtistDto>>> GetAllAsync(); 
    Task<Response<ArtistDto>> CreateAsync(ArtistCreateDto artist); 
    Task<Response<ArtistDto>> GetByIdAsync(string id);
}
