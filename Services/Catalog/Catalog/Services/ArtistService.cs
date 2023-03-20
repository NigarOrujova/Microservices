using CodeAcademy.Catalog.Models;

namespace CodeAcademy.Catalog.Services;
public class ArtistService : IArtistService {
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Artist> _artistCollection;

    public ArtistService(
        IMapper mapper,
        IDatabaseSettings databaseSettings
        ) {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        this._artistCollection = database.GetCollection<Artist>(databaseSettings.ArtistCollectionName);
        this._mapper = mapper;
    }

    public async Task<Response<List<ArtistDto>>> GetAllAsync() {
        var artists = await _artistCollection.Find(artist => true).ToListAsync();

        return Response<List<ArtistDto>>.Success(_mapper.Map<List<ArtistDto>>(artists), 200);
    }

    public async Task<Response<ArtistDto>> CreateAsync(ArtistCreateDto artistDto) {
        var artist = _mapper.Map<Artist>(artistDto);
        await _artistCollection.InsertOneAsync(artist);

        return Response<ArtistDto>.Success(_mapper.Map<ArtistDto>(artist), 200);
    }

    public async Task<Response<ArtistDto>> GetByIdAsync(string id) {
        var artist = await _artistCollection.Find<Artist>(x => x.Id == id).FirstOrDefaultAsync();

        if (artist == null) {
            return Response<ArtistDto>.Fail("artist not found", 404);
        }

        return Response<ArtistDto>.Success(_mapper.Map<ArtistDto>(artist), 200);
    }
}
