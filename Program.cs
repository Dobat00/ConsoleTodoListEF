using Spectre.Console;
using ConsoleTodoListEF.Models;
using ConsoleTodoListEF.Data;
using System.Security.Cryptography.X509Certificates;

using var context = new ToDoTaskContext(); 

bool appIsRunning = true;
int a = 0;

List<string> tasksList = new List<string>();
List<ToDoTask> tasksListTodo = new List<ToDoTask>();

/* ToDoTask DisplayDeleteMenu()
{
    var tasks = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("Choose a task to be deleted.")
        .AddChoices(tasksList));

    return tasks;

}
static void DeleteTask(ToDoTask task)
{
    using var context = new ToDoTaskContext();
    context.Remove(task);
    context.SaveChanges();
}
*/

while (appIsRunning)
{

    var tasks = context.Tasks;

    tasksList.Clear();

    foreach (var task in tasks)
    {
        tasksList.Add(task.Name);
    }

    var menu = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("Use the arrow keys to navigate, [green]Enter[/] or [green]Space[/] to select.")
        .AddChoices(new[]
        {
            "Add a task", "[underline red]Remove[/] a task", "See tasks", "[red]Exit the app[/]"
        })
        );

    switch (menu)
    {
        case "Add a task":
            var task = AnsiConsole.Ask<string>("What is the task that you would like to add?");
            ToDoTask toDoTask = new ToDoTask()
            {
                Name = task
            };
            tasksListTodo.Add(toDoTask);
            context.Add(toDoTask);
            context.SaveChanges(); 
            
            break;

        case "[red]Exit the app[/]":
            appIsRunning = false;
            break;

        case "See tasks":

            foreach (ToDoTask t in tasks)
            {
                Console.WriteLine($"Task Name: {t.Name}");
            }
            break;

        case "[underline red]Remove[/] a task":
            var taskDeleteMenu = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Choose which task do you want to delete.")
                .AddChoices(tasksList)
                );
            /*            var result = context.Tasks.SingleOrDefault(model => model.Name == taskDeleteMenu);*/
            var result = context.Tasks.Where(model => model.Name == taskDeleteMenu).FirstOrDefault();
            Console.WriteLine(result);
            /*            var teste1 = from t5 in context.Tasks
                                     where t5.Name == taskDeleteMenu
                                     select t5;*/
            context.Remove(result);
            context.SaveChanges();
            Console.WriteLine("Task successfully deleted");



            break;
    }
    
}



