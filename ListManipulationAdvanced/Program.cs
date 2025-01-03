/*
 * Next, we are going to implement more complicated list commands, extending the previous task. Again, read a list and keep reading commands until you receive "end":

· Contains {number} – check if the list contains the number and if so - print "Yes", otherwise print "No such number".

· PrintEven – print all the even numbers, separated by a space.

· PrintOdd – print all the odd numbers, separated by a space.

· GetSum – print the sum of all the numbers.

· Filter {condition} {number} – print all the numbers that fulfill the given condition. The condition will be either '<', '>', ">=", "<=".

After the end command, print the list only if you have made some changes to the original list. Changes are made only from the commands from the previous task.
 */

List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

string line = string.Empty;

while ((line = Console.ReadLine()) != "end")
{
    string[] lineTokens = line.Split().ToArray();
    string command = lineTokens[0];

    if (command == "Contains")
    {
        int number = int.Parse(lineTokens[1]);
        if (numbers.Contains(number))
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No such number");
        }
    }
    else if (command == "PrintEven")
    {
        PrintEven(numbers);
    }
    else if (command == "PrintOdd")
    {
        PrintOdd(numbers);
    }
    else if (command=="GetSum")
    {
        Console.WriteLine(numbers.Sum());
    }
    else if (command=="Filter")
    {
        string condition = lineTokens[1];
        int filterNumber = int.Parse(lineTokens[2]);
        
        List<int> filteredNumbers = new List<int>();
        if (condition == "<")
        {
            filteredNumbers = numbers.Where(num => num < filterNumber).ToList();
        }
        else if (condition == ">")
        {
            filteredNumbers = numbers.Where(num => num > filterNumber).ToList();
        }
        else if (condition == ">=")
        {
            filteredNumbers = numbers.Where(num => num >= filterNumber).ToList();
        }
        else if (condition == "<=")
        {
            filteredNumbers = numbers.Where(num => num <= filterNumber).ToList();
        }

        Console.WriteLine(string.Join(" ", filteredNumbers));
    }

}

static void PrintEven(List<int> numbers)
{
    List<int> evenList = new List<int>();

    for (int i = 0; i < numbers.Count; i++)
    {
        if (numbers[i]%2==0)
        {
            evenList.Add(numbers[i]);
        }
    }

    Console.WriteLine(string.Join(" ",evenList));

}

static void PrintOdd(List<int> numbers)
{
    List<int> oddList = new List<int>();

    for (int i = 0; i < numbers.Count; i++)
    {
        if (numbers[i]%2!=0)
        {
            oddList.Add(numbers[i]);
        }
    }

    Console.WriteLine(string.Join(" ",oddList));
}