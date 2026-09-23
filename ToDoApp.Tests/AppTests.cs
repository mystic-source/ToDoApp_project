using Xunit;
using ToDoApp;
using ToDoApp.Services;
using ToDoApp.Models;

namespace ToDoApp.Tests;

public class AppTests
{
    [Fact]
    public void List_All_ToDos_Test()
    {
        Console.WriteLine(AppContext.BaseDirectory);
        ToDoService service = new ToDoService(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "todos_tests_listing.json")));
        List<ToDo> result = service.ListAll();


        Assert.NotEmpty(result); // Verifica se a lista não está vazia
        
        var todo1 = result.Find(t => t.Id == 1);
        var todo2 = result.Find(t => t.Id == 2);

        Assert.NotNull(todo1);
        Assert.NotNull(todo2);
        
        // Verifica se returnou a lista correta de ToDos do ficheiro todos_tests.json
        Assert.Equal("Todo 1", todo1.Title);
        Assert.True(todo1.IsCompleted);

        Assert.Equal("Todo 2", todo2.Title);
        Assert.False(todo2.IsCompleted);
    }

    [Fact]
    public void Add_ToDo_Test()
    {
        ToDoService service = new ToDoService(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "todos_tests.json")));
        service.Add("Todo 3", true);

        List<ToDo> result = service.ListAll();
        var todo3 = result.Find(t => t.Id == 3);

        // Verifica se o novo ToDo foi adicionado corretamente
        Assert.NotNull(todo3);
        Assert.Equal("Todo 3", todo3.Title);
        Assert.True(todo3.IsCompleted);
    }
    
    [Fact]
    public void Update_ToDo_Title_Test()
    {
        ToDoService service = new ToDoService(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "todos_tests.json")));

        service.Add("Todo title to update test", true);

        List<ToDo> result = service.ListAll();
        var todo3 = result.Find(t => t.Title == "Todo title to update test");
        Assert.NotNull(todo3);
        
        service.UpdateTitle(todo3.Id, "Updated Todo title test");
        result = service.ListAll();
        var updatedTodo = result.Find(t => t.Id == todo3.Id);

        // Verifica se o título do ToDo foi atualizado corretamente
        Assert.NotNull(updatedTodo);
        Assert.Equal("Updated Todo title test", updatedTodo.Title);
    }

    [Fact]
    public void Update_ToDo_Status_Test()
    {
        ToDoService service = new ToDoService(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "todos_tests.json")));
        service.UpdStatus(2, true);

        List<ToDo> result = service.ListAll();
        var todo2 = result.Find(t => t.Id == 2);

        // Verifica se o status do ToDo foi atualizado corretamente
        Assert.NotNull(todo2);
        Assert.Equal("Todo 2", todo2.Title);
        Assert.True(todo2.IsCompleted);
    }

    [Fact]
    public void Remove_ToDo_Test()
    {
        ToDoService service = new ToDoService(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "todos_tests.json")));
        service.Remove(1);

        List<ToDo> result = service.ListAll();
        var removedTodo = result.Find(t => t.Id == 1);

        // Verifica se o ToDo foi removido corretamente
        Assert.Null(removedTodo);
    }
}
