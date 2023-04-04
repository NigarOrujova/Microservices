namespace CodeAcademy.Catalog.Services;
public class ConcertService : IConcertService {
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Concert> _concertCollection;

    public ConcertService(
        IMapper mapper,
        IDatabaseSettings databaseSettings
        ) {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        this._concertCollection = database.GetCollection<Concert>(databaseSettings.ConcertCollectionName);
        this._mapper = mapper;
    }

    public async Task<Response<List<ConcertDto>>> GetAllAsync() {
        var concerts = await _concertCollection.Find(concert => true).ToListAsync();

        return Response<List<ConcertDto>>.Success(_mapper.Map<List<ConcertDto>>(concerts), 200);
    }

    public async Task<Response<ConcertDto>> CreateAsync(ConcertDto concertDto) {
        var concert = _mapper.Map<Concert>(concertDto);
        await _concertCollection.InsertOneAsync(concert);

        return Response<ConcertDto>.Success(_mapper.Map<ConcertDto>(concert), 200);
    }

    public async Task<Response<ConcertDto>> GetByIdAsync(string id) {
        var concert = await _concertCollection.Find<Concert>(x => x.Id == id).FirstOrDefaultAsync();

        if (concert == null) {
            return Response<ConcertDto>.Fail("concert not found", 404);
        }

        return Response<ConcertDto>.Success(_mapper.Map<ConcertDto>(concert), 200);
    }
}
