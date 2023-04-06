namespace CodeAcademy.Catalog.Dtos;

public class TicketUpdateDto {
    public string Id { get; set; } = null!;
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? Picture { get; set; }
    /* Navigation Properties */
    public FeatureDto? Feature { get; set; }
    public string? UserId { get; set; }
    public string ConcertId { get; set; }
}