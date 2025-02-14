using System.ComponentModel.DataAnnotations;
using Domain.Todos;

namespace Mvc.Models.Dto;

public class NewTodoDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public StatusItem StatusItem { get; set; }
    public string UserId { get; set; }
    
}