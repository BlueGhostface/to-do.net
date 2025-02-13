using System.ComponentModel.DataAnnotations;
using Domain.Todos;
using Domain.User;

namespace Mvc.Models.Todo;

public class TodoIndexViewModel()
{
    [Required] public long Id { get; set; } = 0;
    [Required] public string Description { get; set; } = "no description";
    [Required] public StatusItem StatusItem { get; set; } = StatusItem.UKNOWN;
    [Required] public Guid userId { get; set; } = Guid.Empty;
    [Required] public string Name { get; set; } = "no assigned user";


    // public TodoIndexViewModel(long id, string description, StatusItem statusItem, string name):this()
    // {
    //     
    //     Id = id;
    //     Description = description;
    //     StatusItem = statusItem;
    //     Name = name;
    // }
}