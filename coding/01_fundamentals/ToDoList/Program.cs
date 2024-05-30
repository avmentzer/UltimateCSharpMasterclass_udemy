Console.WriteLine("Start of Program");
List<string> todoList = [];

while (true)
{
    PrintAllOptions();

    string userChoice = Console.ReadLine().ToUpper();

    switch (userChoice)
    {
        case "S":
            PrintSelectedOption("See all TODOs");
            PrintTodos();
            break;

        case "A":
            PrintSelectedOption("Add a TODO");
            addTodo();
            break;

        case "R":
            PrintSelectedOption("Remove a TODO");
            removeTado();
            break;

        case "E":
            PrintSelectedOption("Exit");
            return;

        default:
            Console.WriteLine("Invalid choice. Please enter S, A, R, or E.");
            break;
    }
}

void PrintSelectedOption(string option)
{
    Console.WriteLine("Selected option: " + option);
}

void PrintAllOptions()
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all Todos");
    Console.WriteLine("[A]dd a Todo");
    Console.WriteLine("[R]emove a Todo");
    Console.WriteLine("[E]xit");
}

void PrintTodos()
{
    if (todoList.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
    }
    else
    {
        for (int i = 0; i < todoList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. " + todoList[i]);
        }
    }

}

void handleException()
{
    Console.WriteLine("The given index is not valid. Select the index of the TODO you want to remove:");
    PrintTodos();
}

void addTodo()
{
    while (true)
    {
        Console.WriteLine("Enter the TODO description:");
        string addTodo = Console.ReadLine();

        if (todoList.Contains(addTodo))
        {
            Console.WriteLine("The description must be unique.");
        }

        else if (!string.IsNullOrWhiteSpace(addTodo))
        {
            todoList.Add(addTodo);
            Console.WriteLine($"TODO successfully added: {addTodo}");
            break;
        }
        else
        {
            Console.WriteLine("The description cannot be empty.");
        }
    }
}

void removeTado()
{
    if (todoList.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
        return;
    }

    Console.WriteLine("Select the index of the TODO you want to remove:");
    PrintTodos();

    string userInput = Console.ReadLine();

    while (true)
    {
        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("Selected index cannot be empty. Select the index of the TODO you want to remove:");
            PrintTodos();
            userInput = Console.ReadLine();
        }
        else
        {
            bool readIndex = int.TryParse(userInput, out int index);
            if (readIndex)
            {
                try
                {
                    Console.WriteLine($"TODO removed: {todoList[index - 1]}");
                    todoList.RemoveAt(index - 1);
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    handleException();
                    userInput = Console.ReadLine();
                }

            }
            else
            {
                handleException();
                userInput = Console.ReadLine();
            }
        }
    }
}