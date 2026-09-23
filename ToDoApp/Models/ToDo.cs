namespace ToDoApp.Models;

public class ToDo
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } = false;

    public ToDo(int Id, string Title, bool IsCompleted)
    {
        this.Id = Id;
        this.Title = Title;
        this.IsCompleted = IsCompleted;
    }
}