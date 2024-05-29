Console.WriteLine("Hello");

Console.WriteLine("Input the first number");
int input1 = int.Parse(Console.ReadLine());

Console.WriteLine("Input the second number");
int input2 = int.Parse(Console.ReadLine());

Console.WriteLine("What do you want to do?");

Console.WriteLine("[A]dd numbers");
Console.WriteLine("[S]ubtract numbers");
Console.WriteLine("[M]ultiply numbers");

string userChoice = Console.ReadLine().ToUpper();

if (userChoice == "A")
{
    calculate(input1, input2, "+");
}

else if (userChoice == "S")
{
    calculate(input1, input2, "-");
}

else if (userChoice == "M")
{
    calculate(input1, input2, "*");
}

else
{
    System.Console.WriteLine("Invalid operation.");
}

Console.WriteLine("Press any key to close.");
Console.ReadKey();

void calculate(int input1, int input2, string operand)
{
    switch (operand)
    {
        case "+":
            System.Console.WriteLine($"{input1} {operand} {input2} = {input1 + input2}");
            break;
        case "-":
            System.Console.WriteLine($"{input1} {operand} {input2} = {input1 - input2}");
            break;
        case "*":
            System.Console.WriteLine($"{input1} {operand} {input2} = {input1 * input2}");
            break;
        default:
            break;
    }

}
