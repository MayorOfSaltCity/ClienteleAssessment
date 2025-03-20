
// use the factorial extension method on an array to generate factorials for a demo "hello world screen"
using Assessment.Factorial;

var factorials = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var factorialsResult = await factorials.FactorAsync();

// output to console window with a message saying "welcome to factorial world" and the factorials and then a line saying enter the numbers you want to calculate the factorial of
Console.WriteLine("Welcome to Factorial World!");
Console.WriteLine("Example:" + string.Join(", ", factorials));
Console.WriteLine("Factorials: " + string.Join(", ", factorialsResult));
Console.WriteLine("Enter the numbers you want to calculate the factorial of, 'G' to exit:");

var userInputs = new List<int>();
while (true)
{
    var input = Console.ReadLine();
    if (string.Compare(input, "g", true) == 0) // case insensitive comparison
    {
        break;
    }

    if (int.TryParse(input, out var number))
    {
        userInputs.Add(number);
    }
}

var userInputsArray = userInputs.ToArray();
var userInputsResult = await userInputsArray.FactorAsync();
Console.WriteLine("Here are the factorials:");
Console.WriteLine(string.Join(", ", userInputsResult));
Console.WriteLine("Goodbye!");

