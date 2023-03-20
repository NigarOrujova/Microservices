namespace CodeAcademy.Catalog.Services;

public class TicketService : ITicketService
{
    private readonly IMongoCollection<Ticket> _ticketCollection;
    private readonly IMongoCollection<Artist> _artistCollection;
    private readonly IMapper _mapper;

    public TicketService(IMapper mapper, IDatabaseSettings databaseSettings)
    {

        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);

        this._ticketCollection = database.GetCollection<Ticket>(databaseSettings.TicketCollectionName);
        this._artistCollection = database.GetCollection<Artist>(databaseSettings.ArtistCollectionName);
        this._mapper = mapper;
    }

    public async Task<Response<List<TicketDto>>> GetAllAsync()
    {
        var Tickets = await _ticketCollection.Find(Ticket => true).ToListAsync();

        if (Tickets.Any())
        {
            foreach (var Ticket in Tickets)
            {
                Ticket.Artist = await _artistCollection.Find<Artist>(x => x.Id == Ticket.ArtistId).FirstAsync();
            }
        }
        else
        {
            Tickets = new List<Ticket>();
        }

        return Response<List<TicketDto>>.Success(_mapper.Map<List<TicketDto>>(Tickets), 200);
    }

    public async Task<Response<TicketDto>> GetByIdAsync(string id)
    {
        var Ticket = await _ticketCollection.Find<Ticket>(x => x.Id == id).FirstOrDefaultAsync();

        if (Ticket == null)
        {
            return Response<TicketDto>.Fail("Ticket not found", 404);
        }
        Ticket.Artist = await _artistCollection.Find<Artist>(x => x.Id == Ticket.ArtistId).FirstAsync();

        return Response<TicketDto>.Success(_mapper.Map<TicketDto>(Ticket), 200);
    }

    public async Task<Response<List<TicketDto>>> GetAllByUserIdAsync(string userId)
    {
        var Tickets = await _ticketCollection.Find<Ticket>(x => x.UserId == userId).ToListAsync();

        if (Tickets.Any())
        {
            foreach (var Ticket in Tickets)
            {
                Ticket.Artist = await _artistCollection.Find<Artist>(x => x.Id == Ticket.ArtistId).FirstAsync();
            }
        }
        else
        {
            Tickets = new List<Ticket>();
        }

        return Response<List<TicketDto>>.Success(_mapper.Map<List<TicketDto>>(Tickets), 200);
    }

    public async Task<Response<TicketDto>> CreateAsync(TicketCreateDto TicketCreateDto)
    {
        var newTicket = _mapper.Map<Ticket>(TicketCreateDto);

        newTicket.CreatedDate = DateTime.Now;
        await _ticketCollection.InsertOneAsync(newTicket);

        return Response<TicketDto>.Success(_mapper.Map<TicketDto>(newTicket), 200);
    }

    public async Task<Response<NoContent>> UpdateAsync(TicketUpdateDto TicketUpdateDto)
    {
        var updateTicket = _mapper.Map<Ticket>(TicketUpdateDto);

        var result = await _ticketCollection.FindOneAndReplaceAsync(x => x.Id == TicketUpdateDto.Id, updateTicket);

        if (result == null)
        {
            return Response<NoContent>.Fail("Ticket not found", 404);
        }

        return Response<NoContent>.Success(204);
    }

    public async Task<Response<NoContent>> DeleteAsync(string id)
    {

        var result = await _ticketCollection.DeleteOneAsync(x => x.Id == id);

        if (result.DeletedCount > 0)
        {
            return Response<NoContent>.Success(204);
        }
        else
        {
            return Response<NoContent>.Fail("Ticket not found", 404);
        }
    }
}