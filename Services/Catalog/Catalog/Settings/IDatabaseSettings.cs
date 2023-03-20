namespace CodeAcademy.Catalog.Settings;

public interface IDatabaseSettings {
    public string? ArtistCollectionName { get; set; }
    public string? TicketCollectionName { get; set; }
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
}
