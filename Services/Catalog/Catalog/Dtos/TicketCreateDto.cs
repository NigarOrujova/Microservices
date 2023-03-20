namespace CodeAcademy.Catalog.Dtos;

public class TicketCreateDto {
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? Picture { get; set; }
    /* Navigation Properties */
    public string? UserId { get; set; }
    public string ArtistId { get; set; } = null!;
}
