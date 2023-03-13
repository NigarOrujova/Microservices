using Catalog.Models;

namespace Catalog.Dtos;

public class BaseCategoryDto {
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? Picture { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? UserId { get; set; }
    public string CategoryId { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public BookInfo? BookInfo { get; set; }
}
public class CategoryDto: BaseCategoryDto { public string Id { get; set; } }
public class CategoryCreateDto: BaseCategoryDto { }
public class CategoryUpdateDto: BaseCategoryDto {
    public string Id { get; set; }
}
public class BaseBookDto {}
public class BookDto: BaseBookDto { public string Id { get; set; } }
public class BookCreateDto: BaseBookDto { }
public class BookUpdateDto: BaseBookDto { public string Id { get; set; } }
public class BookInfoDto { public int? PageCount { get; set; } }

