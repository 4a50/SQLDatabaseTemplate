using System.ComponentModel.DataAnnotations;

namespace SQLDatabaseTemplate.Models
{
  public class ModelOne
  {
    [Required]
    public int Id { get; set; }
    public string Text { get; set; }
  }
}
