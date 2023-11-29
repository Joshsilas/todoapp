// See https://aka.ms/new-console-template for more information


class Task
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}

class TaskManager
{
    private List<Task> tasks;

    public TaskManager()
    {
        tasks = new List<Task>();
    }

    public void AddTask(string description)
    {
        Task newTask = new Task { Description = description, IsCompleted = false };
        tasks.Add(newTask);
        Console.WriteLine("Task added successfully!");
    }

    public void MarkAsCompleted(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index].IsCompleted = true;
            Console.WriteLine("Task marked as completed!");
        }
        else
        {
            Console.WriteLine("Invalid task index");
        }
    }

    public void DisplayTasks()
    {
        Console.WriteLine("Tasks:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. [{(tasks[i].IsCompleted ? "X" : " ")}] {tasks[i].Description}");
        }
    }
}

class Program
{
    static void Main()
    {
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            Console.WriteLine("\nTask Management System");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Mark Task as Completed");
            Console.WriteLine("3. Display Tasks");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter task description: ");
                    string description = Console.ReadLine();
                    taskManager.AddTask(description);
                    break;

                case "2":
                    Console.Write("Enter task index to mark as completed: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        taskManager.MarkAsCompleted(index - 1); // Subtract 1 to match the displayed index
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    break;

                case "3":
                    taskManager.DisplayTasks();
                    break;

                case "4":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}