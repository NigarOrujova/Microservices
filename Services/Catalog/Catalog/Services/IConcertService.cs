namespace CodeAcademy.Catalog.Services; 
public interface IConcertService {

    Task<Response<List<ConcertDto>>> GetAllAsync(); 
    Task<Response<ConcertDto>> CreateAsync(ConcertDto concert); 
    Task<Response<ConcertDto>> GetByIdAsync(string id);
}
