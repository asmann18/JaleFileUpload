using System.ComponentModel.DataAnnotations.Schema;

namespace FileUpload.Models;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? ImagePath { get; set; }
    [NotMapped]
    public IFormFile Image { get; set; }
}
