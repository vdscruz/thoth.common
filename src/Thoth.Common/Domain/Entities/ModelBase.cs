using System.ComponentModel.DataAnnotations;

namespace Thoth.Common.Domain.Entities;

public abstract class ModelBase
{
    [Key, Required]
    public Guid Id { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }

    public ModelBase()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;

    }
}
