using System.ComponentModel.DataAnnotations;
using Domain.Todos;
using Domain.User;

namespace Mvc.Models.Todo;

public class TodoIndexViewModel
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public StatusItem StatusItem { get; set; }
    [Required]
    public User User { get; set; }
}