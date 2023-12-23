using System.ComponentModel.DataAnnotations;

namespace domain.Entities;
public class BaseEntity
{
    [Key]
    public long? Id { get; set; }
}
