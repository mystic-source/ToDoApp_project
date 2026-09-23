using System;
using System.Collections.Generic;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp;

public class Program
{
    private static ToDoService ToDoService = new ToDoService();
    private static bool running = false;

    public static void Main()
    {
        Init();
        Run();
    }

    private static void Init()
    {
        // Messagem inicial
        Console.Clear();
        Console.WriteLine("Aplicação to-do inicializada");

        running = true; // Inicializa a variavel de controle do loop principal usado na Main()
    }
    
    private static void Run()
    {
        // Loop principal
        while (running)
        {
            // Display das selecoes disponiveis
            Console.WriteLine("================");
            Console.WriteLine("Seleciona uma das opções abaixo:");
            Console.WriteLine("1. Ver to-dos");
            Console.WriteLine("2. Adicionar to-do");
            Console.WriteLine("3. Remover to-do");
            Console.WriteLine("4. Atualizar título de um to-do");
            Console.WriteLine("5. Mudar o estado de um to-do");
            Console.WriteLine("6. Sair");
            Console.Write("> ");

            var option = Console.ReadLine(); // Le o input do user
            switch (option)
            {
                case "1": // 1. Ver to-dos
                    ListToDos(ToDoService);
                    break;
                case "2": // 2. Adicionar to-do
                    AddToDo(ToDoService);
                    break;
                case "3": // 3. Remover to-do
                    RemoveToDo(ToDoService);
                    break;
                case "4": // 4. Atualizar título de um to-do
                    UpdateToDoTitle(ToDoService);
                    break;
                case "5": // 5. Mudar o estado de um to-do
                    ChangeToDoStatus(ToDoService);
                    break;
                case "6": // 6. Exit
                    running = false;
                    Console.WriteLine("A fechar aplicação.");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tenta novamente.");
                    break;
            }
        }
    }

    static void ListToDos(ToDoService service)
    {
        Console.WriteLine("\n--- Os teus to-dos ---");
        List<ToDo> todos = service.ListAll();

        if (todos.Count == 0) // A verificar se a lista não está vazia
        {
            Console.WriteLine("Nenhum to-do encontrado.");
            return;
        }

        // Da display de todos os to-dos
        // O formato display é: <Estado do to-do> <Id do to-do>: <Titulo do to-do>
        foreach (var todo in todos)
        {
            string status = todo.IsCompleted ? "[X]" : "[ ]";
            Console.WriteLine($"{status} {todo.Id}: {todo.Title}");
        }
    }

    static void AddToDo(ToDoService service)
    {
        Console.Write("\nDigite o título do novo ToDo: ");
        string titulo = Console.ReadLine() ?? "";

        service.Add(titulo, false);
    }

    static void ChangeToDoStatus(ToDoService service)
    {
        Console.Write("\nDigite o Id do ToDo: ");
        string inputId = Console.ReadLine() ?? "";

        int id = Convert.ToInt32(inputId);

        Console.Write("\nDigite o estado (true or false): ");
        string inputStatus = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(inputId))
        {
            Console.WriteLine("O Id não pode estar vazio.");
            return;
        }
        else if (string.IsNullOrWhiteSpace(inputStatus))
        {
            Console.WriteLine("O estado não pode estar vazio.");
            return;
        } 
        else if (inputStatus != "true" && inputStatus != "false")
        {
            Console.WriteLine("O estado só pode ser true ou false.");
            return;
        }

        bool status;
        if(inputStatus == "true")
        {
            status = true;
        } else
        {
            status = false;
        }

        service.UpdStatus(id, status);
        Console.WriteLine("Estado do to-do atualizado com sucesso.");
    }
    static void RemoveToDo(ToDoService service)
    {
        Console.Write("\nDigite o Id do to-do a remover: ");
        string inputId = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(inputId))
        {
            Console.WriteLine("O Id não pode estar vazio.");
            return;
        }

        int id = Convert.ToInt32(inputId);
        service.Remove(id);
        Console.WriteLine("To-do removido com sucesso.");
    }

    static void UpdateToDoTitle(ToDoService service)
    {
        Console.Write("\nDigite o Id do to-do a atualizar: ");
        string inputId = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(inputId))
        {
            Console.WriteLine("O Id não pode estar vazio.");
            return;
        }

        int id = Convert.ToInt32(inputId);

        Console.Write("\nDigite o novo título do to-do: ");
        string newTitle = Console.ReadLine() ?? "";

        service.UpdateTitle(id, newTitle);
        Console.WriteLine("Título do to-do atualizado com sucesso.");
    }
}
