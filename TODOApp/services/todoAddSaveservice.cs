using System.Text.Json;
namespace TODOApp;

public class todoAddSaveservies
{
    private readonly IWebHostEnvironment env ; 
    private readonly String filePath ; 

    public todoAddSaveservies(IWebHostEnvironment environment)
    {
        this.env = environment ; 
        filePath = Path.Combine(env.WebRootPath , "todos.json");
    }
    public async Task<List<TodoItem>> loadTodoAsync(){

        if (!File.Exists(filePath))
        {
            return new List<TodoItem>();
        } 
        var json = await File.ReadAllTextAsync(filePath);
        var daten = JsonSerializer.Deserialize<List<TodoItem>>(json) ; 

        return daten ?? new List<TodoItem>();  
    }



}


public class TodoItem
{
    public string name { get; set; } = "";
    public bool isDone { get; set; }
}