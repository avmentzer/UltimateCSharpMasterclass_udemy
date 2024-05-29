Console.WriteLine("Hello, what do you want to do?");
PrintAllOptions();

List<string> todoList = new List<string>();

while (true)
{
    string userChoice = Console.ReadLine().ToUpper();

    switch (userChoice)
    {
        case "S":
            PrintSelectedOption("See all TODOs");
            PrintTodos();
            continue;

        case "A":
            PrintSelectedOption("Add a TODO");

            while (true)
            {
                System.Console.WriteLine("Enter the TODO description:");
                string addTodo = Console.ReadLine();

                if (todoList.Contains(addTodo))
                {
                    Console.WriteLine("The description must be unique.");
                }

                else if (!string.IsNullOrWhiteSpace(addTodo))
                {
                    todoList.Add(addTodo);
                    System.Console.WriteLine($"TODO successfully added: {addTodo}");
                    PrintAllOptions();
                    break;
                }
                else
                {
                    System.Console.WriteLine("The description cannot be empty.");
                }
                continue;
            }
            continue;

        case "R":
            PrintSelectedOption("Remove a TODO");
            System.Console.WriteLine("Select the index of the TODO you want to remove:");

            PrintTodos(false);

            string userInput = Console.ReadLine();

            while (true)
            {
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Selected index cannot be empty. Select the index of the TODO you want to remove:");
                    PrintTodos(false);
                    userInput = Console.ReadLine();
                }
                else
                {
                    int index;
                    bool readIndex = int.TryParse(userInput, out index);
                    if (readIndex)
                    {
                        try
                        {
                            System.Console.WriteLine($"TODO removed: {todoList[index - 1]}");
                            RemoveTodo(index);
                            PrintAllOptions();
                            break;
                        }
                        catch (ArgumentOutOfRangeException ex)
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
            continue;

        case "E":
            PrintSelectedOption("Exit");
            return;

        default:
            Console.WriteLine("Invalid choice. Please enter S, A, R, or E.");
            continue; // Repeat the loop
    }
}

void PrintSelectedOption(string option)
{
    Console.WriteLine("Selected option: " + option);
}

void PrintAllOptions()
{
    Console.WriteLine("What else do you want to do?");
    Console.WriteLine("[S]ee all Todos");
    Console.WriteLine("[A]dd a Todo");
    Console.WriteLine("[R]emove a Todo");
    Console.WriteLine("[E]xit");
}

void PrintTodos(bool printOptions = true)
{
    for (int i = 0; i < todoList.Count; i++)
    {
        System.Console.WriteLine($"{i + 1}. " + todoList[i]);

    }
    if (printOptions && todoList.Count > 0)
    {
        PrintAllOptions();
    }
    if (todoList.Count == 0)
    {
        System.Console.WriteLine("No TODOs have been added yet.");
        PrintAllOptions();
    }
}

void RemoveTodo(int index)
{
    todoList.RemoveAt(index - 1);
}

void handleException()
{
    System.Console.WriteLine("The given index is not valid. Select the index of the TODO you want to remove:");
    PrintTodos(false);

}
