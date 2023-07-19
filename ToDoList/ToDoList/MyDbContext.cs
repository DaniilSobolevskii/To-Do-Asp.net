using System.Data.Entity;

namespace ToDoList;

public class MyDbContext : DbContext
{
    protected MyDbContext() : base("")
    {
        
    }
}