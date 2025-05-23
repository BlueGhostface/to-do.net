using System.ComponentModel.DataAnnotations;
using Domain.Todos;


namespace Mvc.Models.Todo;

public class EditTodoViewModel()
{
    [Required] public Guid Id { get; set; } = Guid.Empty;
    [Required] public string Title { get; set; } = "no title found";
    [Required] public string Description { get; set; } = "no description found";
    [Required] public StatusItem StatusItem { get; set; } = StatusItem.UKNOWN;
    [Required] public string UserId { get; set; } = "no User Id found";
    [Required] public string Name { get; set; } = "no assigned User found";
}