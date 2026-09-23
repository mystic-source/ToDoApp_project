using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ToDoApp.Models;

namespace ToDoApp.Services;

public class ToDoService
{
    private readonly string _filePath;
    private readonly List<ToDo> _todos = new List<ToDo>();

    public ToDoService(string filePath = "")
    {
        if (!string.IsNullOrEmpty(filePath))
        {
            _filePath = filePath;
        }
        else
        {
            _filePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "todos.json"));
        }

        Load();
    }

    public List<ToDo> ListAll()
    {
        return _todos;
    }

    public void Add(string titulo = "", bool IsCompleted = false)
    {
        if (string.IsNullOrEmpty(titulo))
        {
            Console.WriteLine("O título não pode estar vazio.");
            return;
        }

        var newToDo = new ToDo
        (
            _todos.Count > 0 ? _todos.Max(t => t.Id) + 1 : 1, // Obter o máximo e usa-lo para gerar o próximo Id
            titulo,
            IsCompleted
        );

        _todos.Add(newToDo);
        Save();
        Console.WriteLine("To-do adicionado com sucesso.");
    }

    public void UpdStatus(int Id, bool status)
    {
        var todo = _todos.Find(t => t.Id == Id);

        if (todo == null)
        {
            Console.WriteLine("Não existe nenhum task associada a este Id.");
            return;
        }

        todo.IsCompleted = status;
        Save();
    }

    public void Remove(int Id)
    {
        var todo = _todos.Find(t => t.Id == Id);

        if (todo == null)
        {
            Console.WriteLine("Não existe nenhum to-do associado a este Id.");
            return;
        }

        _todos.Remove(todo);
        Save();
    }

    public void UpdateTitle(int Id, string newTitle)
    {
        var todo = _todos.Find(t => t.Id == Id);

        if (todo == null)
        {
            Console.WriteLine("Não existe nenhum to-do associado a este Id.");
            return;
        }

        if (string.IsNullOrEmpty(newTitle))
        {
            Console.WriteLine("O título não pode estar vazio.");
            return;
        }

        todo.Title = newTitle;
        Save();
    }

    private void Load()
    {
        _todos.Clear();

        try
        {
            if (File.Exists(_filePath))
            {
                string jsonString = File.ReadAllText(_filePath);

                var data = JsonSerializer.Deserialize<List<ToDo>>(jsonString);

                if (data != null)
                {
                    _todos.AddRange(data);
                }
            }            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar os dados: {ex.Message}");
        }
    }

    private void Save()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(_todos, options);

            File.WriteAllText(_filePath, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao gravar os dados: {ex.Message}");
        }
    }
}