using System.ComponentModel.DataAnnotations;

namespace SQLDatabaseTemplate.Models
{
  public class ModelTwo
  {
    [Required]
    public int Id { get; set; }
    public bool isThereTruth { get; set; }
    public string Text { get; set; }
  }
}
