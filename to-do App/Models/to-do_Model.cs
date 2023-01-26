using System.ComponentModel.DataAnnotations;

namespace to_do_App.Models;

public class to_do_Model
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    [Required]
    public string Task { get; set; }
    public bool isDone { get; set; } = false;
}
