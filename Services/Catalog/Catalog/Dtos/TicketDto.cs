namespace CodeAcademy.Catalog.Dtos;

public class TicketDto {
    public string Id { get; set; } = null!;
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? Picture { get; set; }
    public DateTime CreatedDate { get; set; }



    public FeatureDto? Feature { get; set; }

    /* Navigation Properties */
    public string? UserId { get; set; }
    public string ConcertId { get; set; } 
    public ConcertDto Concert { get; set; }
}
