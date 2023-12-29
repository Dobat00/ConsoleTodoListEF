using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ConsoleTodoListEF.Models;

public class ToDoTask
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; } = null!;

}