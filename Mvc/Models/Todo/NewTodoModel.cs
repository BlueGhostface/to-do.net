using System.ComponentModel.DataAnnotations;
using Domain.Todos;

namespace Mvc.Models.Todo;

public class NewTodoModel
{
    
    [Required (ErrorMessage = "voeg een beschrijving toe")] public string Description { get; set; } = "no description";
    [Required (ErrorMessage = "voeg een status toe")] public StatusItem StatusItem { get; set; } = StatusItem.UKNOWN;
    [Required (ErrorMessage = "voeg een user toe indien bestaand")] public string UserId { get; set; } = "N/A";
    
    
    
}