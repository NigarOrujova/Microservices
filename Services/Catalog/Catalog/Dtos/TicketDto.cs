namespace CodeAcademy.Catalog.Dtos;

public class TicketDto {
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? Picture { get; set; }
    public DateTime CreatedDate { get; set; }





    /* Navigation Properties */
    public string? UserId { get; set; }
    public string ArtistId { get; set; } = null!;
    public ArtistDto Artist { get; set; } = null!;
}
