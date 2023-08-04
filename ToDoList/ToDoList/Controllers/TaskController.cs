using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;


namespace ToDoList.Controllers;
using ToDoList.Models;

public class HomeController : Controller
{
    private static int idCounter = 3;
    private readonly ILogger<HomeController> _logger;
    private static readonly List<Task> _tasks = new()
    
    
    {
        new Task(){Id = 1,Name = "Сделать TODO", Description = "Шаг за шагом"},
        new Task(){Id = 2,Name = "Дз", Description = "Проверить"}
    };
 
   

    [HttpPost]
    public IActionResult Insert([FromForm] Task task)
    {
        if(String.IsNullOrEmpty(task.Name))
        {
            return RedirectToAction("Index");
        }

        task.Id = idCounter;
        idCounter++;
        _tasks.Add(task);
        
        return RedirectToAction("Index");
    }


    [HttpDelete ("{id}")]

    public IActionResult Delete([FromRoute] int id)
    {
        var model = _tasks.Find(x => x.Id == (id));
        _tasks.Remove(model);
        return RedirectToAction("Index");

    }
   
    public IActionResult Index()
    {
        var model = new Tasks()
        {
            Base = _tasks
        };
        return View(model);
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateTask ([FromRoute] int id, [FromBody] Task updatedTask)
    {
        var task = _tasks.Find(x => x.Id == (id));
        task.Name = updatedTask.Name;
        task.Description = updatedTask.Description;
        return RedirectToAction("Index");

    }
    
   
}